import socket

SERVER_PORT = 8826
BYTES_SIZE = 1024 

def main():
    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as client:
        # connect to the server
        client.connect(('localhost', SERVER_PORT))
        # receive the message from the server and print it
        msg = client.recv(BYTES_SIZE)
        print(msg.decode())
        # send a message to the server
        client.send('Hello'.encode())

if __name__ == '__main__':
    main()