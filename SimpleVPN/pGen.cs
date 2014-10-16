using System;
using System.Security.Cryptography;

namespace SimpleVPN
{
	class pGen
	{
		// All 3 digit primes with their primitive roots
		static int[,] _3DigitPrimeList = 
			{{101,2},{103,5},{107,2},{109,6},{113,3},{127,3},
			{131,2},{137,3},{139,2},{149,2},{151,6},{157,5},
			{163,2},{167,5},{173,2},{179,2},{181,2},{191,19},
			{193,5},{197,2},{199,3},{211,2},{223,3},{227,2},
			{229,6},{233,3},{239,7},{241,7},{251,6},{257,3},
			{263,5},{269,2},{271,6},{277,5},{281,3},{283,3},
			{293,2},{307,5},{311,17},{313,10},{317,2},{331,3},
			{337,10},{347,2},{349,2},{353,3},{359,7},{367,6},
			{373,2},{379,2},{383,5},{389,2},{397,5},{401,3},
			{409,21},{419,2},{421,2},{431,7},{433,5},{439,15},
			{443,2},{449,3},{457,13},{461,3},{463,3},{467,2},
			{479,13},{487,3},{491,2},{499,7},{503,5},{509,2},
			{521,3},{523,2},{541,2},{547,2},{557,2},{563,2},
			{569,3},{571,3},{577,5},{587,2},{593,3},{599,7},
			{601,7},{607,3},{613,2},{617,3},{619,2},{631,3},
			{641,3},{643,11},{647,5},{653,2},{659,2},{661,2},
			{673,5},{677,2},{683,3},{691,3},{701,2},{709,2},
			{719,11},{727,5},{733,6},{739,3},{743,5},{751,3},
			{757,2},{761,6},{769,11},{773,2},{787,2},{797,2},
			{809,3},{811,3},{821,2},{823,3},{827,2},{829,2},
			{839,11},{853,2},{857,3},{859,2},{863,5},{877,2},
			{881,3},{883,2},{887,5},{907,2},{911,17},{919,7},
			{929,3},{937,5},{941,2},{947,2},{953,3},{967,5},
			{971,6},{977,3},{983,5},{991,6},{997,7}};

		public int prime { get; set; }		// Current prime number
		public int root { get; set; }		// Current primitive root
		private RNGCryptoServiceProvider pRand { get; set; }     // Random Number Generator
		public pGen()
		{
			this.pRand = new RNGCryptoServiceProvider();
			getNewPrime();
		}
		public void getNewPrime()
		{
			int pIndex;

			// Byte array to fill
			byte[] rand = new byte[4];

			// Fill the array
			pRand.GetBytes(rand);

			// Pick a prime from the array
			pIndex = Convert.ToInt32((BitConverter.ToUInt32(rand, 0)) % (_3DigitPrimeList.Length / 2));
			prime = _3DigitPrimeList[pIndex, 0];
			root = _3DigitPrimeList[pIndex, 1];
		}
		public void pTest()
		{
			// Test function

			// Prints off all primes available to this class
			Console.WriteLine("Prime List:");
			Console.WriteLine("List Length: " + _3DigitPrimeList.Length);
			for (int i = 0; i < (_3DigitPrimeList.Length)/2; i++)
			{
				Console.WriteLine("Prime: "+_3DigitPrimeList[i,0]+"  root: "+_3DigitPrimeList[i,1]);
			}

			// Generates 1000 random prime / root pairs
			for (int i = 0; i < 1000; i++)
			{
				getNewPrime();
				Console.WriteLine("Prime: " + this.prime + "  root: " + this.root);
			}
		}
		
	}
}
