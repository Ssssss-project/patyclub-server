using System.Security.Cryptography;
using System.Text;

namespace patyclub_server.Core.Service
{
    public class SecurityService
    {
        public byte[] string2SHA256(string data){
            SHA256 sHA256 = SHA256.Create();
            return sHA256.ComputeHash(Encoding.ASCII.GetBytes(data));
        }
    }
}