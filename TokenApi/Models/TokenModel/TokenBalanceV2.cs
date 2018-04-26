using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokenApi.Models.TokenModel
{
    public class TokenBalanceV2
    {
        public string address { get; set; }
        public int balance { get; set; }
    }
}