using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransFastWCF.TransFastRespopnse
{
    public class TokenResponse
    {
        public int ReturnResult { get; set; }
        public int ReturnCode { get; set; }
        public string ReturnDescription { get; set; }
        public string ReturnToken { get; set; }
    }
}
