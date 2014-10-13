# include <openssl\md5.h>
# include <openssl\sha.h>

unsigned char* hashSHA(unsigned char* input, int size);
unsigned char* hashMD5(unsigned char* input, int size);
void printHash(int size, unsigned char* hash);