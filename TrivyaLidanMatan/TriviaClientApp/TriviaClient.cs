﻿using System;
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
        public const int TIMEOUT = 5000;

        public const int ERROR_CODE = 0;
        public const int SUCCESS_CODE = 1;

        public enum RequestCodes
        {
            LOGIN_CODE = 1,
            SIGNUP_CODE = 2,
            LOGOUT_CODE = 3,
            ROOMS_LIST_CODE = 4,
            PLAYERS_IN_ROOM_CODE = 5,
            HIGH_SCORES_CODE = 6,
            PERSONAL_STATS_CODE = 7,
            JOIN_ROOM_CODE = 8,
            CREATE_ROOM_CODE = 9
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
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>response</returns>
        public JObject Login(string username, string password)
        {
            JObject data = new JObject() { { "username", username }, { "password", password } };
            JObject result = SendRequestDict((byte)RequestCodes.LOGIN_CODE, data);
            if ((int) result["message"]["status"] == SUCCESS_CODE)
            {
                this.Username = username;
            }
            return result;
        }

        /// <summary>
        /// Signup to the server.
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <param name="email">email</param>
        /// <returns>response</returns>
        public JObject Signup(string username, string password, string email)
        {
            JObject data = new JObject() { { "username", username }, { "password", password }, { "email", email } };
            JObject result = SendRequestDict((byte)RequestCodes.SIGNUP_CODE, data);
            if ((int)result["message"]["status"] == SUCCESS_CODE)
            {
                this.Username = username;
            }
            return result;
        }

        /// <summary>
        /// Logout from the server.
        /// </summary>
        /// <returns>response</returns>
        public JObject Logout()
        {
            Username = "";
            return SendRequestDict((byte)RequestCodes.LOGOUT_CODE);
        }

        /// <summary>
        /// Get the room list.
        /// </summary>
        /// <returns>response</returns>
        public JObject GetRoomsList()
        {
            return SendRequestDict((byte)RequestCodes.ROOMS_LIST_CODE);
        }

        /// <summary>
        /// Get the players in a room.
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
        /// </summary>
        /// <returns>response</returns>
        public JObject GetHighScores()
        {
            return SendRequestDict((byte)RequestCodes.HIGH_SCORES_CODE);
        }

        /// <summary>
        /// Get the personal stats.
        /// </summary>
        /// <returns>response</returns>
        public JObject GetPersonalStats()
        {
            return SendRequestDict((byte)RequestCodes.PERSONAL_STATS_CODE);
        }

        /// <summary>
        /// Join a room.
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
    }
}
