using System;

namespace historial_blockchain.Models
{
    public class UserToken
    {
        public string UserId { get; set; }
        
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}