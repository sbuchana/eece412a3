Download OpenSSL - http://slproweb.com/products/Win32OpenSSL.html
	-> use 16MB installer
Install to some directory XX
VisualStudio config
	->	Properties > Configuration Properties > C/C++ > General
		in Additional Include Directories type: XX\OpenSSL-Win32\include
	-> Properties > Configuration Properties > Linker > Command Line > Additional Options
		type: "XX\OpenSSL-Win32\lib\*.lib"
	