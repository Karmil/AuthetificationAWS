using System;
using System.Collections.Generic;
using System.Text;

namespace Idigao.TestAuthetification.Core.Entites
{
    public class CustumeAutho
    {
        public CustumeAutho()
        {
           
        }

        public string Verbe { get; set; }
        public string ContentType { get; set; }
        public string ContenteMd5 { get; set; }
        public string HeaderDate  { get; set; }
        public string CanonicalizedResource { get; set; }
        public string Authorization { get; set; }
        public Dictionary<string, string> HeaderAmazon { get; set; }
        
    }
}
