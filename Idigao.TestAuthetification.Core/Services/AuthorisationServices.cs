using Idigao.TestAuthetification.Core.Entites;
using Idigao.TestAuthetification.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Idigao.TestAuthetification.Core.Services
{
    public class AuthorisationServices : IAuthorisationServices
    {

        const string SecretAccessKeyID = "upJFKIyRXhz+aOCQoc0k0RSktDNONTVeNjKesn+9";

        public AuthorisationServices()
        {
        }

        /// <summary>
        /// Construction de chaine de StringToSign
        /// </summary>
        /// <param name="custumeAutho"></param>
        /// <returns></returns>
        public string ConstructionStringToSign(CustumeAutho custumeAutho)
        {
            // Construction de la chaine canonicalizedamazon
            var canonicalizedAmzHeaders = CanonicalizedAmzHeaders(custumeAutho.HeaderAmazon);

            // construction de la chaine Stringtosing
            string stringrosign = custumeAutho.Verbe + '\n' + custumeAutho.ContenteMd5 + '\n' + custumeAutho.ContentType + '\n'
                + custumeAutho.HeaderDate + '\n' + canonicalizedAmzHeaders + custumeAutho.CanonicalizedResource;

            return stringrosign;
        }

        /// <summary>
        /// Vérifier les deux signatures
        /// </summary>
        /// <param name="custumeAutho"></param>
        /// <returns></returns>
        public bool ChekAuthorize(CustumeAutho custumeAutho)
        {
            // Construction de la stringToSign
            var StringToSign = ConstructionStringToSign(custumeAutho);

            // Cryptage du StringToSign avec la clès privée
            var signatureServer = HMACSHA1(SecretAccessKeyID, StringToSign);

            // Recupre la signature du client
            if (custumeAutho.Authorization.Split(":").Count() == 0)
            {
                return false;
            }
            return custumeAutho.Authorization.Split(":")[1].Equals(signatureServer);
        }

        /// <summary>
        /// Construction amazon
        /// </summary>
        /// <param name="hederAmazon"></param>
        /// <returns></returns>
        public static string CanonicalizedAmzHeaders(Dictionary<string, string> hederAmazon)
        {
            var listHeaderAmazon = new List<string>();
            try
            {
                foreach (var item in hederAmazon.Keys)
                {
                    // Verifier le mot clés s'il existe
                    if (item.ToLower().IndexOf("x-amz-") == 0)
                    {
                        // Init valeur d'entete et supprestion des espaces
                        var valeurHeader = hederAmazon[item].ToString().Trim();

                        // Verifier si la clé en double regroupe les valeurs
                        if (hederAmazon.TryGetValue(item, out string value))
                        {
                            hederAmazon[item.ToLower()] = string.Concat(valeurHeader, ",", value);
                        }
                        else
                        {
                            hederAmazon[item.ToLower()] = valeurHeader;
                        }
                    }
                }

                // Short dictionary and list
                foreach (KeyValuePair<string, string> item in hederAmazon.OrderBy(key => key.Key))
                {
                    listHeaderAmazon.Add(string.Join(":", item.Key, item.Value, "U+000A"));
                }

                // Chaine canonicalized
                string canonicalizedAmzHeaders = string.Concat(listHeaderAmazon);

                return canonicalizedAmzHeaders;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Encodage de la cle
        /// </summary>
        /// <param name="key"></param>
        /// <param name="dataToSign"></param>
        /// <returns></returns>
        public static string HMACSHA1(string key, string dataToSign)
        {
            Byte[] secretBytes = UTF8Encoding.UTF8.GetBytes(key);
            HMACSHA1 hmac = new HMACSHA1(secretBytes);

            Byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(dataToSign);
            Byte[] calcHash = hmac.ComputeHash(dataBytes);
            String calcHashString = Convert.ToBase64String(calcHash);
            return calcHashString;
        }
    }
}
