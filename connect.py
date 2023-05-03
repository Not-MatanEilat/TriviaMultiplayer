import socket

SERVER_PORT = 8826
BYTES_SIZE = 1024 

def main():
    client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client.connect(('localhost', SERVER_PORT))
    msg = client.recv(BYTES_SIZE)
    print(msg.decode())
    client.send('Hello'.encode())
    client.close()

if __name__ == '__main__':
    main()