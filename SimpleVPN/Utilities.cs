using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace SimpleVPN
{
    public class Utilities
    {
        [DllImport("VPN_aesEncryption_buildDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe static extern byte* encrypt(byte* input, int size, int* outputSize, byte* enc_key);
        [DllImport("VPN_aesEncryption_buildDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe static extern void printHEX(byte* chars, int size);
        [DllImport("VPN_aesEncryption_buildDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        unsafe static extern byte* decrypt(byte* ciphertext, int size, int* outputSize, byte* dec_key);

        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        public static byte[] Encrypt(byte[] plaintext, int inSize, int outSize, byte[] key)
        {
            unsafe
            {
                fixed (byte* plain = plaintext, keyp = key)
                {
                    byte * cipher = encrypt(plain, inSize, &outSize, keyp);
                    byte[] ciphertext = new byte[outSize];
                    Marshal.Copy((IntPtr)cipher, ciphertext, 0, outSize);
                    return ciphertext;
                }
            }
        }

        public static byte[] Decrypt(byte[] ciphertext, int inSize, int outSize, byte[] key)
        {
            unsafe
            {
                fixed (byte* cipher = ciphertext, keyp = key)
                {
                    byte* recoveredtext = decrypt(cipher, inSize, &outSize, keyp);
                    byte[] plaintext = new byte[outSize+1];
                    plaintext[outSize] = 0;
                    Marshal.Copy((IntPtr)recoveredtext, plaintext, 0, outSize);
                    return plaintext;
                }
            }
        }

        public static byte[] MD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = GetBytes(input);
            return md5.ComputeHash(inputBytes);
        }

        public static string MD5HashString(string input)
        {
            var hash = MD5Hash(input);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}

