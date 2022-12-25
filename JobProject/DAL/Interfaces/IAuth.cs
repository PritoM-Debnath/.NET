using DAL.EF;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAuth<CLASS, RESULT>
    {
        Token Authenticate (CLASS obj);
        bool IsAuthenticated(string token);
        bool Logout(string token);
    }
}
