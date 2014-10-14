using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Numerics;


namespace SimpleVPN
{
	public class dh
	{
		public int p { get; set; }		// Prime number
		public int g { get; set; }		// Base g
		private RNGCryptoServiceProvider dhRand { get; set; }     // Random Number Generator
		private int a { get; set; }		// Secret number a
		public int key { get; set; } // Shared secret key

		public dh(int p, int g)
		{
			this.p = p;
			this.g = g;
			this.dhRand = new RNGCryptoServiceProvider();
		}

		public int generatePartialKey()
		{
			// First create a byte array to store random number
			byte[] randomNum = new byte[4];

			// Fill the array
			dhRand.GetBytes(randomNum);

			// Convert to value
			this.a = (int)(((BitConverter.ToUInt32(randomNum, 0)) % (this.p - 1)) + 1);

			// Return the partial key
			return (int)(power((BigInteger)this.g, (BigInteger)this.a) % this.p);
		}

		public void generateSessionKey(int b)
		{
			this.key = (int)(power((BigInteger)b, (BigInteger)this.a) % this.p);

			// Forget everything except the key
			this.a = 0;
			this.g = 0;
			this.p = 0;
		}

		public BigInteger power(BigInteger x, BigInteger y)
		{
			// This is a function to generate powers of large numbers
			BigInteger result = x;
			for (int i = 1; i < y; i++)
			{
				result = result * x;
			}
			return result;
		}
	}
}
