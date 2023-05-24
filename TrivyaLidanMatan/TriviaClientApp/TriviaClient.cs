using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace TriviaClientApp
{
    public class TriviaClient
    {
        public const string SERVER_IP = "localhost";
        public const int SERVER_PORT = 8826;
        public const int BYTE_SIZE = 1024;


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

        private Socket socket;

        public TriviaClient()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
        }

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


        public List<byte> BuildMessageFromDict(byte code, Dictionary<string, object> dict)
        {
            string json = JsonSerializer.Serialize(dict);
            return BuildMessage(code, json);
        }

        public Dictionary<string, object> ParseMessage(List<byte> bytes)
        {
            byte code = bytes[0];
            List<byte> lengthBytes = bytes.GetRange(1, 4);
            lengthBytes.Reverse();
            int length = BitConverter.ToInt32(lengthBytes.ToArray());
            List<byte> messageBytes = bytes.GetRange(5, length);
            string message = Encoding.ASCII.GetString(messageBytes.ToArray());
            Dictionary<string, object> dict = new Dictionary<string, object>
            {
                {"code", code},
                {"length", length},
                {"message", message}
            };
            return dict;
        }


        public Dictionary<string, object> ParseMessageToDict(List<byte> bytes)
        {
            var dict = ParseMessage(bytes);
            dict["message"] = JsonSerializer.Deserialize<Dictionary<string, object>>((string)dict["message"]);
            return dict;
        }

        public void Connect()
        {
            socket.Connect(SERVER_IP, SERVER_PORT);
            Span<byte> buffer = new byte[BYTE_SIZE];
            socket.Receive(buffer);
        }

        public List<byte> SendRequestBytes(List<byte> message)
        {
            socket.Send(message.ToArray());
            return ReceiveResponseBytes();
        }

        private List<byte> ReceiveResponseBytes()
        {
            byte[] buffer = new byte[BYTE_SIZE];
            socket.Receive(buffer);
            return new List<byte>(buffer);
        }

        public Dictionary<string, object> SendRequest(byte code, string message)
        {
            return ParseMessage(SendRequestBytes(BuildMessage(code, message)));
        }

        public Dictionary<string, object> SendRequestDict(byte code, Dictionary<string, object> dict)
        {
            return ParseMessageToDict(SendRequestBytes(BuildMessageFromDict(code, dict)));
        }
    }
}
