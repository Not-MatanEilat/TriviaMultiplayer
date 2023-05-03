import socket

SERVER_PORT = 8822
BYTES_SIZE = 1024 

def main():
    client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client.connect(('localhost', SERVER_PORT))
    client.send('Hello'.encode())
    msg = client.recv(BYTES_SIZE)
    print(msg.decode())
    client.close()

if __name__ == '__main__':
    main()