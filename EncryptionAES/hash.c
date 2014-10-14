# include "hash.h"

/*
*	Outputs 20 bytes SHA1 hash of input
*	Param:	size of input
*	Returns pointer to the hash
*/
unsigned char* hashSHA(unsigned char* input, int size){
	unsigned char* hashOut = calloc(SHA_DIGEST_LENGTH, sizeof(char));
	SHA1(input, size, hashOut);
	return hashOut;
}

/*
*	Outputs 16 bytes MD5 hash of input
*	Param:	size of input
*	Returns pointer to the hash
*/
unsigned char* hashMD5(unsigned char* input, int size){
	unsigned char* hashOut = calloc(MD5_DIGEST_LENGTH, sizeof(char));
	MD5(input, size, hashOut);
	return hashOut;
}

/*
*	Prints hash value in hex
*	Param:	size of hash in bytes
*/
void printHash(int size, unsigned char* hash){
	for (int i = 0; i < size; i++)
		printf("%02x", (unsigned int)hash[i]);
	printf("\n");
}