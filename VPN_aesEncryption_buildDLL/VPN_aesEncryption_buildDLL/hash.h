# include <openssl\md5.h>
# include <openssl\sha.h>

__declspec(dllexport) unsigned char* hashSHA(unsigned char* input, int size);
__declspec(dllexport) unsigned char* hashMD5(unsigned char* input, int size);
__declspec(dllexport) void printHash(int size, unsigned char* hash);