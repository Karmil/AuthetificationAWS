using Idigao.TestAuthetification.Core.Entites;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text;

namespace Idigao.TestAuthetification.Core.Interfaces
{
    public interface IAuthorisationServices
    {
        string ConstructionStringToSign(CustumeAutho custumeAutho);
        bool ChekAuthorize(CustumeAutho custumeAutho);
    }
}