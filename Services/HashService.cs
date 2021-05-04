using System;
using System.Security.Cryptography;
using historial_blockchain.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace historial_blockchain.Services
{
    public class HashService
    {
        public HashResult Hash(string input)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);
            return Hash(input, salt);
        }

        public HashResult Hash(string input, byte[] salt)
        {
            //Deriva una subllave de 256 bits (HMACSHA1 con 10,000 iteraciones)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: input,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));
            return new HashResult(){
                Hash = hashed,
                Salt = salt
            };
        }
    }
}