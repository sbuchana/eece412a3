using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SimpleVPN
{
    static class Program
    {
        [DllImport("VPN_aesEncryption_buildDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe static extern byte* encrypt(byte* input, int size, int* outputSize, byte* enc_key);
        [DllImport("VPN_aesEncryption_buildDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe static extern void printHEX(byte* chars, int size);
        [DllImport("VPN_aesEncryption_buildDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe static extern byte* decrypt(byte* ciphertext, int size, int* outputSize, byte* dec_key);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            byte[] haha = new byte[4] { 5, 2, 3, 4 };
            byte[] key = new byte[16] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5 };
            int size, outSize;
            unsafe
            {
                fixed (byte* hahap = haha, keyp = key)
                {
                    byte* temp = encrypt(hahap, 4, &size, keyp);
                    printHEX(temp, size);
                    byte* temp2 = decrypt(temp, size, &outSize, keyp);
                    printHEX(temp2, outSize);
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
           
        }
    }
}
