import socket

SERVER_PORT = 8826
BYTES_SIZE = 1024

LOGIN_CODE = 1
SIGNUP_CODE = 2


def build_message(code: int, message: str) -> bytes:
    """
    Build a message to send to the server.
    :param code: 1 byte
    :type code: int
    :param message: string
    :type message: str
    :return: bytes
    """
    return (
            code.to_bytes(1, "big")
            + len(message).to_bytes(4, "big")
            + message.encode()
    )


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


def create_client_socket() -> socket.socket:
    """
    Create a client socket and connect to the server.
    :return: socket
    """
    client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client.connect(("localhost", SERVER_PORT))
    msg = client.recv(BYTES_SIZE)  # skip the welcome message
    return client


def send_request(client: socket.socket, message: bytes) -> bytes:
    """
    Send a request to the server and return the response.
    :param client: client socket
    :param message: message to send to the server
    :return: None
    """
    client.send(message)
    return client.recv(BYTES_SIZE)


def login(client: socket.socket, username: str, password: str) -> bytes:
    """
    Send a login request to the server and return the response.
    :param client: client socket
    :param username: username
    :param password: password
    :return: None
    """
    message = '{"username": "' + username + '","password": "' + password + '"}'
    bin_message = build_message(LOGIN_CODE, message)
    return send_request(client, bin_message)


def signup(client: socket.socket, username: str, password: str, email: str) -> bytes:
    """
    Send a signup request to the server and return the response.
    :param client: client socket
    :param username: username
    :param password: password
    :param email: email
    :return: None
    """
    message = '{"username": "' + username + '","password": "' + password + '","email": "' + email + '"}'
    bin_message = build_message(SIGNUP_CODE, message)
    return send_request(client, bin_message)


def main():
    # test signup
    client = create_client_socket()
    print(signup(client, "test", "test", "test@mail.com"))

    # test signup with existing username
    client.close()
    client = create_client_socket()
    print(signup(client, "test", "test", "test@mail.com"))

    # test login
    client.close()
    client = create_client_socket()
    print(login(client, "test", "test"))

    # test login with wrong password
    client.close()
    client = create_client_socket()
    print(login(client, "test", "wrong"))

    # test login with wrong username
    client.close()
    client = create_client_socket()
    print(login(client, "wrong", "test"))




if __name__ == "__main__":
    main()
