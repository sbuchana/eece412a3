#include <windows.h>
#include <stdio.h>
#include <stdlib.h>

#pragma once

class sock
{
private:

	// WinSock data handles
	WSADATA sockdata;
	SOCKET s;

	//	Server data structure
	struct sockaddr_in server;

	// Connection status
	bool connected;

	// Errors
	char errors;


public:
	// Set up socket
	sock();

	// Destructor method
	~sock();

	// Connect to server at given IP address and port
	int sConnect(char ipaddr[], int port);

	//// Bind the socket to a port
	//int sBind();

	// Send data through connection
	int sSend(char *argv[]);

	// Receive data from connection
	//int sReceive(char )
};
