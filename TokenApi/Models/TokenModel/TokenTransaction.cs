using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokenApi.Models.TokenModel
{
    public class TokenTransaction
    {
        public bool transactionSuccess { get; set; }
        public string transactionhash { get; set; }
    }
}