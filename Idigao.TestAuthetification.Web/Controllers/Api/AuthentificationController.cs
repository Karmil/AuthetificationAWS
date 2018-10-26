using Idigao.TestAuthetification.Core.Entites;
using Idigao.TestAuthetification.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Idigao.TestAuthetification.Web.Controllers.Api
{
    [Produces("application/json")]
    public class AuthentificationController : BaseApiController
    {
        protected readonly IAuthetificationServices authetificationServices;
        protected readonly IAuthorisationServices authorisationServices;

        public AuthentificationController(IAuthetificationServices authetificationServices, IAuthorisationServices authorisationServices)
        {
            this.authetificationServices = authetificationServices;
            this.authorisationServices = authorisationServices;
        }

        // GET: api/Authentification/authenticate
        [HttpGet]
        [Route("authenticate")]
        public bool Get(string email, string password)
        {
            var reponse = authetificationServices.Authentifier(email, password);
            return reponse;
        }

        // GET: api/Authentification/confidentials
        [HttpGet]
        [Route("confidentials")]
        public bool Confidentials(string email)
        {
            if (HttpContext.Request.Headers.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues stringValue))
            {
                // Ressource pour le cas Get
                var canonicalizedResource = HttpContext.Request.Path.Value ?? "/";
                canonicalizedResource += "email" + email; // Concataint la chaine 

                // Recupere les informations de la requete envoyer par le client 
                var custumeAutho = new CustumeAutho
                {
                    Verbe = HttpContext.Request.Method,
                    ContentType = HttpContext.Request.ContentType ?? "",
                    ContenteMd5 = HttpContext.Request.Headers["HeaderContentMD5"].ToString() ?? "",
                    HeaderDate = HttpContext.Request.Headers["HeaderDate"].ToString() ?? "",
                    CanonicalizedResource = canonicalizedResource,
                    Authorization = stringValue
                };

                // Recuper les header values and keys. 
                foreach (var item in HttpContext.Request.Headers.Keys)
                {
                    // Crée dictionary
                    custumeAutho.HeaderAmazon.Add(item, HttpContext.Request.Headers[item].ToString());
                }

                return authorisationServices.ChekAuthorize(custumeAutho);

            }
            return false;
        }
        
    }
}
