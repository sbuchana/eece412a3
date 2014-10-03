/*
EECE 412 Assignment #3
October 15, 2014

Windows socket connection
*/

#include "sock.h"

#pragma comment(lib, "ws2_32.lib") 
#pragma once

sock::sock(){

	// Initialize winsock V2.2
	if (WSAStartup(MAKEWORD(2, 2), &sockdata) != 0){
		printf("Initialization failed. Error code: %d", WSAGetLastError());
	}

	// Attempt to create an IPv4 socket
	// AF_INET = IPv4
	// SOCK_STEAM and IPPROTO_TCP= TCP
	if ((s = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP)) == INVALID_SOCKET){
		printf("Error creating socket: %d", WSAGetLastError());
	}

	printf("Socket created\n");
}

// Destructor method
sock::~sock(){


}

// Connect to server at given IP address and port
int sock::sConnect(char ipaddr[], int port){

	// Set up the address, port, and protocol for the connection
	this->server.sin_addr.s_addr = inet_addr(ipaddr);
	this->server.sin_family = AF_INET;
	this->server.sin_port = htons(port);

	if (connect(s, (struct sockaddr *)&server, sizeof(server)) < 0){
		printf("Could not connect: %d", WSAGetLastError());
		return 1;
	}

	printf("Connected to %s\n", ipaddr);
	return 0;
}

//// Bind the socket to a port
//int sock::sBind(){
//
//
//}

// Send data through connection
int sock::sSend(char *message[]){

	if (send(s, *message, strlen(*message), 0) < 0){
		printf("Could not send message: %d", WSAGetLastError());
		return 1;
	}

	// In here for testing purposes right now
	printf("Sent: %s\n", *message);

	return 0;
}