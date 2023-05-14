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

def main():
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as client:
        # connect to the server
        client.connect(("localhost", SERVER_PORT))
        # receive the message from the server and print it
        msg = client.recv(BYTES_SIZE)
        print(msg.decode())

        message = '{"username": "user1","password": "1234"}'

        # build the message by the format CODE(1 BYTE) | MESSAGE_LEN (4 BYTES) | MESSAGE
        bin_message = build_message(LOGIN_CODE, message)

        # send a message to the server
        client.send(bin_message)

        # get message fom the server
        msg = client.recv(BYTES_SIZE)
        print(msg)

        message = '{"username": "user1","password": "1234","email": "user1@gmail.com"}'

        # build a signup message now this time
        bin_message = build_message(SIGNUP_CODE, message)

        # send a message to the server
        client.send(bin_message)

        # get message fom the server
        msg = client.recv(BYTES_SIZE)
        print(msg)

        # build an invalid message now this time
        bin_message = build_message(123, "{NOOOOOOOOOO}")

        # send a message to the server
        client.send(bin_message)

        # get message fom the server
        msg = client.recv(BYTES_SIZE)
        print(msg)


if __name__ == "__main__":
    main()
