using Idigao.TestAuthetification.Core.Entites;
using Idigao.TestAuthetification.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Idigao.TestAuthetification.Core.Services
{
    public class AuthetificationServices : IAuthetificationServices
    {
        protected readonly IAppLogger<AuthetificationServices> logger;


        public List<User> GetTestList()
        {
            return new List<User>()
            {
                new User(){Email="karmil.omar@gmail.com",Password="P@ssw0rd" },
                new User(){Email="karmil.omar2@gmail.com",Password="P@ssw0rd" }
            };
        }

        public AuthetificationServices(IAppLogger<AuthetificationServices> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        ///  Vérifier le login et le mot de passe d'utilisé
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Authentifier(string email, string password)
        {
            try
            {
                var element = GetTestList().AsQueryable().Where(e => e.Email == email && e.Password == password).FirstOrDefault();
                if (element != null)
                {
                    logger.LogInformation("L'utilisateur " + email + "est connecter" + DateTime.Now);
                    return true;
                }
                logger.LogInformation("L'utilisateur " + email + "essayer de se connecter !!!" + DateTime.Now);
                return false;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw new Exception(ex.Message);

            }

        }




    }
}
