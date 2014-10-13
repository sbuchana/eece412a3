/*
* References: http://www.gurutechnologies.net/blog/aes-ctr-encryption-in-c/
*/

# include <stdio.h>
# include <stdlib.h>
# include <string.h>
# include <math.h>
# include <openssl\aes.h>
# include <openssl\rand.h>

# define AES_BLOCK_SIZE 16		// 128-bits
# define DEBUG 1				// for debugging purposes
/*	
*	struct to maintain IV, num and ecount which are used
*	by AES_ctr128_encrypt()
*/
struct aes_ctr_state{
	unsigned char iv[AES_BLOCK_SIZE];
	unsigned int num;
	unsigned char ecount[AES_BLOCK_SIZE];
};

unsigned char* encrypt(unsigned char* input, int size, int* outputSize, const unsigned char* enc_key);
unsigned char* decrypt(unsigned char* ciphertext, int size, int* outputSize, const unsigned char* dec_key);
void init_aes_ctr(struct aes_ctr_state* state);
void init_dec_ctr(struct aes_ctr_state* state, unsigned char* iv);
void printHEX(unsigned char* chars, int size);
void printASCII(unsigned char* chars, int size);
