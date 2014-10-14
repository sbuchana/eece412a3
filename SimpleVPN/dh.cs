using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleVPN
{
    public class dh
    {
        public int p { get; set; }		// Prime number
        public int g { get; set; }		// Base g
		private int a { get; set; }     // Generated secret number
        public double key { get; set; } // Shared secret key
        
        public dh(int p, int g)
        {
			this.p = p;
			this.g = g;
        }

		public double generateClientKey()
		{
			// Generate secret number a
			this.a = 6; //Random number smaller than p
												
			return Math.Pow(this.g , this.a) % this.p;
		}

		public void calculateSessionKey(double b)
		{
			// Calculate secret key from a and b
			this.key = Math.Pow(this.p, b) % this.p;
												
			// Forget everything except the key
			this.a = 0;
			this.g = 0;
			this.p = 0;
		}
    }
}
