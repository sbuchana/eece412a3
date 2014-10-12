/*
* References: http://www.gurutechnologies.net/blog/aes-ctr-encryption-in-c/
*/

# include "encrypt.h"

int main(){
	unsigned char text[] = { "this is aes encryption test." };
	unsigned char key[] = { "thisIsMykey12345" };
	unsigned char* ciphertext;
	unsigned char* plaintext;
	int encryptedSize, plainSize;

	ciphertext = encrypt(text, 28, &encryptedSize, key);
	if (DEBUG) printHEX(ciphertext, encryptedSize);
	if (DEBUG) printASCII(ciphertext, encryptedSize);

	// -------------------------------------------------------------- \\

	plaintext = decrypt(ciphertext, encryptedSize, &plainSize, key);
	if (DEBUG) printHEX(plaintext, plainSize);
	if (DEBUG) printASCII(plaintext, plainSize);

	printf("Decrypted text of size %i: %s\n", plainSize, plaintext);

	system("PAUSE");
	return 0;
}

/*
*	Encryption using openssl-aes-ctr mode
*	Parameter:	enc_key must be 16 bytes long
*				size is the length of input in bytes
*	The function will pad the last block with 0s if block size is not a multiple of 16
*	Returns the pointer to the ciphertext and outputSize
*/
unsigned char* encrypt(unsigned char* input, int size, int* outputSize, const unsigned char* enc_key){
	AES_KEY key;
	struct aes_ctr_state state;
	unsigned char* inputHolder;
	unsigned char* ciphertext;
	int numPaddings;
	int numBlocks;

	// encryption setup
	init_aes_ctr(&state);
	if (DEBUG) printHEX(state.iv, AES_BLOCK_SIZE);
	numBlocks = (int) ceil((double)size / AES_BLOCK_SIZE);
	*outputSize = (numBlocks + 1) * AES_BLOCK_SIZE;
	ciphertext = calloc(numBlocks + 1, AES_BLOCK_SIZE);		// + 1 for IV
	inputHolder = calloc(numBlocks, AES_BLOCK_SIZE);

	// initialize encryption key
	if (AES_set_encrypt_key(enc_key, 128, &key) < 0){
		printf("Error: Could not set encryption key\n");
		exit(1);
	}

	// padding last block if not multiple of 16 bytes
	numPaddings = AES_BLOCK_SIZE - (size % AES_BLOCK_SIZE);
	if (DEBUG) printf("Size is %i, numPaddings: %i, numBlocks: %i\n", size, numPaddings, numBlocks);

	memcpy(inputHolder, input, size);
	memset(inputHolder + size, 0, numPaddings);
	if (DEBUG) printHEX(inputHolder, numBlocks * AES_BLOCK_SIZE);

	// prepend cipher with iv
	memcpy(ciphertext, state.iv, AES_BLOCK_SIZE);

	// encrypt using ctr mode
	for (int i = 0; i < numBlocks; i++){
		AES_ctr128_encrypt(inputHolder + (i * AES_BLOCK_SIZE), 
							ciphertext + ((i + 1) * AES_BLOCK_SIZE),
							AES_BLOCK_SIZE, &key,
							state.iv, state.ecount, &state.num);
	}

	free(inputHolder);
	return ciphertext;
}

/*
*	Parameter:	dec_key must be 16 bytes long
*				size is the length of ciphertext in bytes, should be a multiple of 16
*	Returns the pointer to the plaintext, null terminated
*	outputSize does not include null character
*/
unsigned char* decrypt(unsigned char* ciphertext, int size, int* outputSize, const unsigned char* dec_key){
	AES_KEY key;
	struct aes_ctr_state state;
	unsigned char* iv;
	unsigned char* plaintext;
	int numBlocks;
	int i;

	// extract iv from cipher
	iv = calloc(1, AES_BLOCK_SIZE);
	memcpy(iv, ciphertext, AES_BLOCK_SIZE);
	if (DEBUG) printHEX(iv, AES_BLOCK_SIZE);

	// decryption setup
	numBlocks = size / AES_BLOCK_SIZE - 1;
	*outputSize = numBlocks*AES_BLOCK_SIZE;
	init_dec_ctr(&state, iv);
	plaintext = calloc(numBlocks, AES_BLOCK_SIZE);

	// initialize decryption key (using encrypt func)
	if (AES_set_encrypt_key(dec_key, 128, &key) < 0){
		printf("Error: Could not set decryption key\n");
		exit(1);
	}

	// decrypt (encrypt ciphertext)
	for (int i = 0; i < numBlocks; i++){
		AES_ctr128_encrypt(ciphertext + ((i + 1) * AES_BLOCK_SIZE),
			plaintext + (i * AES_BLOCK_SIZE),
			AES_BLOCK_SIZE, &key,
			state.iv, state.ecount, &state.num);
	}

	// getting plaintext size
	i = *outputSize - 1;
	while (plaintext[i] == 0){
		(*outputSize)--;
		i--;
	}

	free(iv);
	return plaintext;
}

/*
*	Function to initialize the IV
*	First 8 bytes are random inputs from openssl rand()
*	Last 8 bytes are initialized to 0
*/
void init_aes_ctr(struct aes_ctr_state* state){
	// AES_ctr128_encrypt requires num and ecount to be initialized to 0
	state->num = 0;
	memset(state->ecount, 0, AES_BLOCK_SIZE);
	
	// init last 8 bytes of state->iv to 0
	memset(state->iv + 8, 0, 8);

	// init fist 8 bytes of state->iv to random
	if (!RAND_bytes(state->iv, 8)){
		printf("Error: Could not create random bytes\n");
		exit(1);
	}
}

/*
*	Function to initialize the IV for decryption
*	IV are from iv indicated in ciphertext
*/
void init_dec_ctr(struct aes_ctr_state* state, unsigned char* iv){
	// AES_ctr128_encrypt requires num and ecount to be initialized to 0
	state->num = 0;
	memset(state->ecount, 0, AES_BLOCK_SIZE);

	// init last 8 bytes of state->iv to 0
	memset(state->iv + 8, 0, 8);

	// init state->iv to iv
	memcpy(state->iv, iv, AES_BLOCK_SIZE);
}

/*
*	Function to print the HEX value of an array
*/
void printHEX(unsigned char* chars, int size){
	for (int i = 0; i < size; i++)
		printf("0x%X ", chars[i]);
	printf("\n\n");
}

void printASCII(unsigned char* chars, int size){
	for (int i = 0; i < size; i++)
		printf("%c", chars[i]);
	printf("\n\n");
}