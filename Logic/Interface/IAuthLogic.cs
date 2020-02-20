using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interface
{
    public interface IAuthLogic
    {
        string LoginUser(string username, string password);
    }
}
