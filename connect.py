import socket

SERVER_PORT = 8826
BYTES_SIZE = 1024 

LOGIN_CODE = 1
SIGNUP_CODE = 2

def main():
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as client:

        message = '{username: “user1”, password: “1234”}'

        # build the message by the format CODE(1 BYTE) | MESSAGE_LEN (4 BYTES) | MESSAGE
        bin_message = LOGIN_CODE.to_bytes(1, 'big') + len(message).to_bytes(4, 'big') + message.encode()

        # connect to the server
        client.connect(('localhost', SERVER_PORT))
        # receive the message from the server and print it
        msg = client.recv(BYTES_SIZE)
        print(msg.decode())
        # send a message to the server
        client.send(message.encode())

        # get message fom the server
        msg = client.recv(BYTES_SIZE)

        message = '{username: “user1”, password: “1234”, mail:user1@gmail.com}'

        # build a signup message now this time
        bin_message = SIGNUP_CODE.to_bytes(1, 'big') + len(message).to_bytes(4, 'big') + message.encode()

        # send a message to the server
        client.send(message.encode())

        # get message fom the server
        msg = client.recv(BYTES_SIZE)


        




if __name__ == '__main__':
    main()