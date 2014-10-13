# include "encrypt.h"

int main(){
	unsigned char text[] = { "this is aes encryption test.12" };
	unsigned char key[] = { "thisIsMykey12345" };
	unsigned char* ciphertext;
	unsigned char* plaintext;
	int encryptedSize, plainSize;

	ciphertext = encrypt(text, strlen(text), &encryptedSize, key);
	if (DEBUG) printHEX(ciphertext, encryptedSize);
	if (DEBUG) printASCII(ciphertext, encryptedSize);

	// -------------------------------------------------------------- \\

	plaintext = decrypt(ciphertext, encryptedSize, &plainSize, key);
	if (DEBUG) printHEX(plaintext, plainSize);
	printf("Decrypted text of size %i: ", plainSize);
	if (DEBUG) printASCII(plaintext, plainSize);
		

	// ---------- hash test ----------- \\

	system("PAUSE");
	return 0;
}