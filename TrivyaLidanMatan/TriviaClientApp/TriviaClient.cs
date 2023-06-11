using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TriviaClientApp
{
    public class TriviaClient
    {
        public const string SERVER_IP = "localhost";
        public const int SERVER_PORT = 8826;
        public const int BYTE_SIZE = 1024;
        public const int TIMEOUT = 60000;

        public const int ERROR_CODE = 0;
        public const int SUCCESS_CODE = 1;

        public enum RequestCodes
        {
            ERROR_CODE = 0,
            LOGIN_CODE = 1,
            SIGNUP_CODE = 2,
            LOGOUT_CODE = 3,
            ROOMS_LIST_CODE = 4,
            PLAYERS_IN_ROOM_CODE = 5,
            HIGH_SCORES_CODE = 6,
            PERSONAL_STATS_CODE = 7,
            JOIN_ROOM_CODE = 8,
            CREATE_ROOM_CODE = 9,
            CLOSE_ROOM_CODE = 10,
            START_GAME_CODE = 11,
            ROOM_STATE_CODE = 12,
            LEAVE_ROOM_CODE = 13,
            LEAVE_GAME_CODE = 14,
            GET_QUESTION_CODE = 15,
            SUBMIT_ANSWER_CODE = 16,
            GET_GAME_RESULTS_CODE = 17,
            PLAYER_RESULTS_CODE = 18,
            ADD_QUESTION_CODE = 19,
            HTH_GET_STATE_CODE = 20,
            JOIN_HTH_CODE = 21,
            LEAVE_HTH_CODE = 22,
        }

        private static TriviaClient? instance = null;

        /// <summary>
        /// Get the Client
        /// If the client is not connected it will connect it
        /// </summary>
        /// <returns>The Client</returns>
        public static TriviaClient GetClient()
        {
            if (instance == null)
            {
                instance = new TriviaClient();
                instance.Connect();
            }

            return instance;
        }

        private Socket socket;

        public string Username { get; private set; }

        public TriviaClient()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.ReceiveTimeout = TIMEOUT;
            socket.SendTimeout = TIMEOUT;
            this.Username = "";
        }

        /// <summary>
        /// Build a message to send to the server.
        /// </summary>
        /// <param name="code">message code</param>
        /// <param name="message">message</param>
        /// <returns>byte list</returns>
        public List<byte> BuildMessage(byte code, string message)
        {
            List<byte> bytes = new List<byte>(5 + message.Length); // allocate memory on the heap
            bytes.Add(code);
            byte[] lengthBytes = BitConverter.GetBytes(message.Length);
            Array.Reverse(lengthBytes);
            bytes.AddRange(lengthBytes);
            bytes.AddRange(Encoding.ASCII.GetBytes(message));
            return bytes;
        }

        /// <summary>
        /// Build a message to send to the server.
        /// </summary>
        /// <param name="code">message code</param>
        /// <param name="dict">message dict</param>
        /// <returns>byte list</returns>
        public List<byte> BuildMessageFromDict(byte code, JObject dict)
        {
            string json = JsonConvert.SerializeObject(dict);
            return BuildMessage(code, json);
        }

        /// <summary>
        /// Parse a message from the server.
        /// </summary>
        /// <param name="bytes">message bytes</param>
        /// <returns>message dict</returns>
        public JObject ParseMessage(List<byte> bytes)
        {
            byte code = bytes[0];
            List<byte> lengthBytes = bytes.GetRange(1, 4);
            lengthBytes.Reverse();
            int length = BitConverter.ToInt32(lengthBytes.ToArray());
            List<byte> messageBytes = bytes.GetRange(5, length);
            string message = Encoding.ASCII.GetString(messageBytes.ToArray());
            JObject dict = new JObject
            {
                {"code", code},
                {"length", length},
                {"message", message}
            };
            return dict;
        }

        /// <summary>
        /// Parse a message from the server.
        /// </summary>
        /// <param name="bytes">message bytes</param>
        /// <returns>message dict</returns>
        public JObject ParseMessageToDict(List<byte> bytes)
        {
            var dict = ParseMessage(bytes);
            dict["message"] = JsonConvert.DeserializeObject<JObject>((string)dict["message"]);
            return dict;
        }

        /// <summary>
        /// Connect to the server.
        /// </summary>
        public void Connect()
        {
            try
            {
                socket.Connect(SERVER_IP, SERVER_PORT);
                Span<byte> buffer = new byte[BYTE_SIZE];
                socket.Receive(buffer);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                MessageBox.Show("Failed to connect to server: " + e.Message, "Connection ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Send a request to the server and return the response.
        /// </summary>
        /// <param name="message">message to send to the server</param>
        /// <returns>response</returns>
        private List<byte> SendRequestBytes(List<byte> message)
        {
            try
            {
                socket.Send(message.ToArray());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                MessageBox.Show("Failed to send to server: " + e.Message, "Connection ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            return ReceiveResponseBytes();
        }

        /// <summary>
        /// Receive Response Bytes
        /// </summary>
        /// <returns>response</returns>
        private List<byte> ReceiveResponseBytes()
        {
            byte[] buffer = new byte[BYTE_SIZE];
            List<byte> receivedData = new List<byte>();
            try
            {
                int bytesRead = 0;

                do
                {
                    bytesRead = socket.Receive(buffer);
                    receivedData.AddRange(buffer.Take(bytesRead));
                } while (bytesRead >= BYTE_SIZE);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                MessageBox.Show("Failed to receive from server: " + e.Message, "Connection ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            return receivedData;
        }

        /// <summary>
        /// Send a request to the server and return the response.
        /// </summary>
        /// <param name="code">request code</param>
        /// <param name="message">the message</param>
        /// <returns></returns>
        private JObject SendRequest(byte code, string message = "")
        {
            return ParseMessage(SendRequestBytes(BuildMessage(code, message)));
        }

        /// <summary>
        /// Send a request to the server and return the response.
        /// </summary>
        /// <param name="code">request code</param>
        /// <param name="dict">request data</param>
        /// <returns>response</returns>
        public JObject SendRequestDict(byte code, JObject dict = null)
        {
            if (dict == null)
            {
                dict = new JObject();
            }
            return ParseMessageToDict(SendRequestBytes(BuildMessageFromDict(code, dict)));
        }

        /// <summary>
        /// Login to the server.
        /// {"status" : status}
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>response</returns>
        public JObject Login(string username, string password)
        {
            JObject data = new JObject() { { "username", username }, { "password", password } };
            JObject result = SendRequestDict((byte)RequestCodes.LOGIN_CODE, data);
            if ((int) result["code"] != ERROR_CODE)
            {
                this.Username = username;
            }
            return result;
        }

        /// <summary>
        /// Signup to the server.
        /// {"status" : status}
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <param name="email">email</param>
        /// <returns>response</returns>
        public JObject Signup(string username, string password, string email)
        {
            JObject data = new JObject() { { "username", username }, { "password", password }, { "email", email } };
            JObject result = SendRequestDict((byte)RequestCodes.SIGNUP_CODE, data);
            if ((int)result["code"] != ERROR_CODE)
            {
                this.Username = username;
            }
            return result;
        }

        /// <summary>
        /// Logout from the server.
        /// {"status" : status}
        /// </summary>
        /// <returns>response</returns>
        public JObject Logout()
        {
            Username = "";
            return SendRequestDict((byte)RequestCodes.LOGOUT_CODE);
        }

        /// <summary>
        /// Get the room list.
        /// {"status" : status, "rooms" : {"isActive" : isActive, "name" : name, "maxPlayers" : maxPlayers, "numOfQuestionsInGame" : numOfQuestionsInGame, "timePerQuestion" : timePerQuestion, "id" : id}}
        /// </summary>
        /// <returns>response</returns>
        public JObject GetRoomsList()
        {
            return SendRequestDict((byte)RequestCodes.ROOMS_LIST_CODE);
        }

        /// <summary>
        /// Get the players in a room.
        /// {"status" : status, "players" : players}
        /// </summary>
        /// <param name="roomId">room id</param>
        /// <returns>response</returns>
        public JObject GetPlayersInRoom(int roomId)
        {
            JObject data = new JObject();
            data["roomId"] = roomId;
            return SendRequestDict((byte)RequestCodes.PLAYERS_IN_ROOM_CODE, data);
        }

        /// <summary>
        /// Get the high scores.
        /// {"status" : status, "highscores" : players}
        /// </summary>
        /// <returns>response</returns>
        public JObject GetHighScores()
        {
            return SendRequestDict((byte)RequestCodes.HIGH_SCORES_CODE);
        }

        /// <summary>
        /// Get the personal stats.
        /// {status" : status, "statistics" : statistics}
        /// </summary>
        /// <returns>response</returns>
        public JObject GetPersonalStats()
        {
            return SendRequestDict((byte)RequestCodes.PERSONAL_STATS_CODE);
        }

        /// <summary>
        /// Join a room.
        /// {"status" : status}
        /// </summary>
        /// <param name="roomId">room id</param>
        /// <returns>response</returns>
        public JObject JoinRoom(int roomId)
        {
            JObject data = new JObject() { { "roomId", roomId } };
            return SendRequestDict((byte)RequestCodes.JOIN_ROOM_CODE, data);
        }

        /// <summary>
        /// Create a room.
        /// {"status" : status}
        /// </summary>
        /// <param name="roomName">room name</param>
        /// <param name="maxUsers">max players</param>
        /// <param name="questionCount">question count</param>
        /// <param name="answerTimeout">answer timeout</param>
        /// <returns>response</returns>
        public JObject CreateRoom(string roomName, int maxUsers, int questionCount, int answerTimeout)
        {
            JObject data = new JObject() { { "roomName", roomName }, { "maxUsers", maxUsers }, { "questionCount", questionCount }, { "answerTimeout", answerTimeout } };
            return SendRequestDict((byte)RequestCodes.CREATE_ROOM_CODE, data);
        }

        /// <summary>
        /// Will get room state
        ///  {"status" : status, "has
        /// Begun" : hasGameBegun, "players" : players, "questionCount" : questionCount, "answerTimeout" : answerTimeout}
        /// </summary>
        /// <returns>response</returns>
        public JObject GetRoomState()
        {
            return SendRequestDict((byte)RequestCodes.ROOM_STATE_CODE);
        }

        /// <summary>
        /// Will leave the room
        /// {"status" : status}
        /// </summary>
        /// <returns>response</returns>
        public JObject LeaveRoom(){
            return SendRequestDict((byte)RequestCodes.LEAVE_ROOM_CODE);
        }

        /// <summary>
        /// Will close the room
        /// {"status" : status}
        /// </summary>
        /// <returns>response</returns>
        public JObject CloseRoom()
        {
            return SendRequestDict((byte)RequestCodes.CLOSE_ROOM_CODE);
        }

        /// <summary>
        /// Will start the game
        /// {"status" : status}
        /// </summary>
        /// <returns>response</returns>
        public JObject StartGame()
        {
            return SendRequestDict((byte)RequestCodes.START_GAME_CODE);
        }

        /// <summary>
        /// Will get the question
        /// {"status" : status, "question" : question, "answers" : [["answerNumber", "Answer"], ["answerNumber", "Answer"], ["answerNumber", "Answer"], ["answerNumber", "Answer"]]}
        /// </summary>
        /// <returns>response</returns>
        public JObject GetQuestion()
        {
            return SendRequestDict((byte)RequestCodes.GET_QUESTION_CODE);
        }

        /// <summary>
        /// Will submit the answer
        /// {"status" : status, "correctAnswer" : correctAnswer}
        /// </summary>
        /// <param name="answerId">answer id</param>
        /// <returns>response</returns>
        public JObject SubmitAnswer(int answerId)
        {
            JObject data = new JObject() { { "answerId", answerId } };
            return SendRequestDict((byte)RequestCodes.SUBMIT_ANSWER_CODE, data);
        }

        /// <summary>
        /// Will get the game results
        /// {"status" : status, "results" :
        /// {"username" : username, "correctAnswerCount" : correctAnswerCount", "wrongAnswerCount" : wrongAnswerCount, "AverageAnswerTime" : AverageAnswerTime}}
        /// </summary>
        /// <returns>response</returns>
        public JObject GetGameResults()
        {
            return SendRequestDict((byte)RequestCodes.GET_GAME_RESULTS_CODE);
        }

        /// <summary>
        /// Will leave the game
        /// {"status" : status}
        /// </summary>
        /// <returns>response</returns>
        public JObject LeaveGame()
        {
            return SendRequestDict((byte)RequestCodes.LEAVE_GAME_CODE);
        }

        /// <summary>
        /// Will get the room state
        /// </summary>
        /// <returns>response</returns>
        public JObject GetRoomUsers()
        {
            return SendRequestDict((byte)RequestCodes.PLAYER_RESULTS_CODE);
        }

        /// <summary>
        /// Will add a question
        /// {"status" : status}
        /// </summary>
        /// <returns>response</returns>
        public JObject AddQuestion(string question, string correctAnswer, string answer2, string answer3, string answer4)
        {
            JObject data = new JObject() { { "question", question }, { "correctAns", correctAnswer }, { "ans2", answer2 }, { "ans3", answer3 }, { "ans4", answer4 } };
            return SendRequestDict((byte)RequestCodes.ADD_QUESTION_CODE, data);
        }

        /// <summary>
        /// Will join the hth
        /// {"status" : status}
        /// </summary>
        /// <returns>response</returns>
        public JObject JoinHeadToHead()
        {
            return SendRequestDict((byte)RequestCodes.JOIN_HTH_CODE);
        }

        /// <summary>
        /// Will get hth state
        /// {"status" : status, "hasGameBegun" : hasGameBegun, "questionsAmount" : questionsAmount, "players" : players, "timePerQuestion"}
        /// </summary>
        /// <returns>response</returns>
        public JObject getHeadToHeadState()
        {
            return SendRequestDict((byte)RequestCodes.HTH_GET_STATE_CODE);
        }


        /// <summary>
        /// The function will return a boolean based no if the result given was a success or not.
        /// You can set displayMessageBox to true to see the error in an error message.
        /// In addition you can change customErrorMessage to display an error message of your choice.
        /// </summary>
        /// <param name="response">The response to check</param>
        /// <param name="displayMessageBox">True if you want the error message to display in a message box</param>
        /// <param name="customErrorMessage">a string for a custom error message if needs</param>
        /// <returns>True or False</returns>
        public static bool IsSuccessResponse(JObject response, bool displayMessageBox=true, string customErrorMessage="")
        {
            if ((int)response["code"] == ERROR_CODE)
            {
                if (displayMessageBox)
                {
                    if (customErrorMessage == "")
                    {
                        MessageBox.Show(response["message"]["message"].ToString(), "ERROR", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(customErrorMessage, "ERROR", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }

                return false;
            }

            return true;
        }
    }
}
