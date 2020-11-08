using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITGFinal.Models
{
    public class User
    {
        public string Token
        {
            get
            {
                return Token;
            }
            set
            {
                const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                StringBuilder res = new StringBuilder();
                Random rnd = new Random();
                int length = valid.Length;
                while (0 < length--)
                {
                    res.Append(valid[rnd.Next(valid.Length)]);
                    
                }
                Token = res.ToString();

            }
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
