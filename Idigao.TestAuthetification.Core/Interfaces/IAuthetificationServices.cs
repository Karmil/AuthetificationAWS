using System;
using System.Collections.Generic;
using System.Text;

namespace Idigao.TestAuthetification.Core.Interfaces
{
    public interface IAuthetificationServices
    {
        bool Authentifier(string email, string password);
    }
}
