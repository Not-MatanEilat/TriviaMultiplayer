import socket
import json

SERVER_PORT = 8826
BYTES_SIZE = 1024

ERROR_CODE = 0
SUCCESS_CODE = 1

LOGIN_CODE = 1
SIGNUP_CODE = 2
LOGOUT_CODE = 3
ROOMS_LIST_CODE = 4
PLAYERS_IN_ROOM_CODE = 5
HIGH_SCORES_CODE = 6
PERSONAL_STATS_CODE = 7
JOIN_ROOM_CODE = 8
CREATE_ROOM_CODE = 9
CLOSE_ROOM_CODE = 10
START_GAME_CODE = 11
ROOM_STATE_CODE = 12
LEAVE_ROOM_CODE = 13
LEAVE_GAME_CODE = 14
GET_QUESTION_CODE = 15
SUBMIT_ANSWER_CODE = 16
GET_GAME_RESULTS_CODE = 17
PLAYER_RESULTS_CODE = 18


def build_message(code: int, message: str) -> bytes:
    """
    Build a message to send to the server.
    :param code: 1 byte
    :param message: string
    :return: bytes
    """
    return (
            code.to_bytes(1, "big")
            + len(message).to_bytes(4, "big")
            + message.encode()
    )


def build_message_from_dict(code: int, message: dict) -> bytes:
    """
    Build a message to send to the server.
    :param code: 1 byte
    :param message: string
    :return: bytes
    """
    return build_message(code, json.dumps(message))


def parse_message(message: bytes) -> dict:
    """
    Parse a message from the server.
    :param message: bytes
    :return: dict
    """
    code = int.from_bytes(message[:1], "big")
    msg_len = int.from_bytes(message[1:5], "big")
    msg = message[5:].decode()
    return {"code": code, "len": msg_len, "msg": msg}


def parse_message_to_dict(message: bytes) -> dict:
    """
    Parse a message from the server.
    :param message: bytes
    :return: dict
    """
    parsed_message = parse_message(message)
    parsed_message["msg"] = json.loads(parsed_message["msg"])
    return parsed_message


class TriviaClient:
    """
    A class representing a Trivia client.
    """

    def __init__(self):
        self.client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        self.client.connect(("localhost", SERVER_PORT))
        msg = self.client.recv(BYTES_SIZE)  # skip the welcome message

    def send_request_bytes(self, message: bytes) -> bytes:
        """
        Send a request to the server and return the response.
        :param message: message to send to the server
        :return: None
        """
        self.client.send(message)
        return self.client.recv(BYTES_SIZE)

    def send_request(self, code: int, message: str) -> dict:
        """
        Send a request to the server and return the response.
        :param code: 1 byte
        :param message: string
        :return: dict
        """
        return parse_message(self.send_request_bytes(build_message(code, message)))

    def send_request_dict(self, code: int, message: dict) -> dict:
        """
        Send a request to the server and return the response.
        :param code: 1 byte
        :param message: string
        :return: dict
        """
        return parse_message_to_dict(self.send_request_bytes(build_message_from_dict(code, message)))

    def login(self, username: str, password: str) -> dict:
        """
        Login to the server.
        :param username: username
        :param password: password
        :return: dict
        """
        data = {"username": username, "password": password}
        return self.send_request_dict(LOGIN_CODE, data)

    def signup(self, username: str, password: str, email: str) -> dict:
        """
        Signup to the server.
        :param username: username
        :param password: password
        :param email: email
        :return: dict
        """
        data = {"username": username, "password": password, "email": email}
        return self.send_request_dict(SIGNUP_CODE, data)

    def logout(self) -> dict:
        """
        Logout from the server.
        :return: dict
        """
        return self.send_request_dict(LOGOUT_CODE, {})

    def get_rooms_list(self) -> dict:
        """
        Get the rooms list.
        :return: dict
        """
        return self.send_request_dict(ROOMS_LIST_CODE, {})

    def get_players_in_room(self, room_id: int) -> dict:
        """
        Get the players in a room.
        :param room_id: room id
        :return: dict
        """
        return self.send_request_dict(PLAYERS_IN_ROOM_CODE, {"roomId": room_id})

    def get_high_scores(self) -> dict:
        """
        Get the high scores.
        :return: dict
        """
        return self.send_request_dict(HIGH_SCORES_CODE, {})

    def get_personal_stats(self) -> dict:
        """
        Get the personal stats.
        :return: dict
        """
        return self.send_request_dict(PERSONAL_STATS_CODE, {})

    def join_room(self, room_id: int) -> dict:
        """
        Join a room.
        :param room_id: room id
        :return: dict
        """
        return self.send_request_dict(JOIN_ROOM_CODE, {"roomId": room_id})

    def create_room(self, room_name: str, max_players: int, question_count: int, answer_timeout: int) -> dict:
        """
        Create a room.
        :param room_name: room name
        :param max_players: max players
        :param question_count: question count
        :param answer_timeout: answer timeout
        :return: dict
        """
        return self.send_request_dict(CREATE_ROOM_CODE, {
            "roomName": room_name,
            "maxUsers": max_players,
            "questionCount": question_count,
            "answerTimeout": answer_timeout
        })

    def leave_room(self) -> dict:
        """
        Leave a room.
        :return: dict
        """
        return self.send_request_dict(LEAVE_ROOM_CODE, {})

    def start_game(self) -> dict:
        """
        Start a game.
        :return: dict
        """
        return self.send_request_dict(START_GAME_CODE, {})

    def get_question(self) -> dict:
        """
        Get a question.
        :return: dict
        """
        return self.send_request_dict(GET_QUESTION_CODE, {})

    def submit_answer(self, answer_id: int) -> dict:
        """
        Submit an answer.
        :param answer_id: answer id
        :return: dict
        """
        return self.send_request_dict(SUBMIT_ANSWER_CODE, {"answerId": answer_id})

    def get_game_results(self) -> dict:
        """
        Get the game results.
        :return: dict
        """
        return self.send_request_dict(GET_GAME_RESULTS_CODE, {})

    def leave_game(self) -> dict:
        """
        Leave a game.
        :return: dict
        """
        return self.send_request_dict(LEAVE_GAME_CODE, {})


def test_signup(username: str, password: str, email: str):
    """
    Test login.
    :return: the client
    """
    client = TriviaClient()
    res = client.signup(username, password, email)
    if res["msg"]["status"] != SUCCESS_CODE:
        raise ValueError("Signup failed!")
    return client


def test_login(username: str, password: str):
    """
    Test login.
    :param username: username
    :param password: password
    :return: the client
    """
    client = TriviaClient()
    res = client.login(username, password)
    if res["code"] == ERROR_CODE:
        raise ValueError("Login failed!")
    return client


def prompt_login():
    """
    Prompt the user to login.
    :return: the client
    """
    username = input("Username: ")
    password = input("Password: ")
    return test_login(username, password)


def test():
    print("Please login to the server")
    me = prompt_login()
    print("Logged in successfully!")

    print("Testing stats...")

    print(me.get_personal_stats())
    print(me.get_high_scores())

    print("Testing rooms...")
    print(me.create_room("test", 2, 2, 2))
    print(me.get_rooms_list())

    print("Testing joining room... for this test to work, you need to login with another user and join room")
    me2 = prompt_login()
    print(me2.join_room(1))
    print(me2.get_players_in_room(1))

    print("Testing logout...")
    print(me.logout())
    print(me2.logout())


if __name__ == '__main__':
    me = prompt_login()
    me.create_room("test", 8, 8, 8)
    me.start_game()
