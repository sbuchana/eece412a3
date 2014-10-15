Required libraries:

.NET 4.0 is required for Big Integers
OpenSSL for encryption and hashing

---- integration with C stuff ----
1. build the VPN_aesEncryption_buildDLL
	* be sure to install OpenSSL first (using the default in C:\)
2. add the .dll into the SimpleVPN project
	-> properties > add > existing items -> go in Wrapper folder -> show all files 
3. compile the SimpleVPN - should work
	-> should see some HEX output after closing the 'console/window'

* i'm not quite sure how to use classes and stuff in C# so i made a test case in main itself

