using Nethereum.Contracts;
using Nethereum.Web3;
using Nethereum.Web3.Accounts.Managed;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TokenApi.Models.Default
{
    public class DefaultWeb3
    {
        public string defaultAddress = ConfigurationManager.AppSettings["SendAddress"];
        public string defaultPassword = ConfigurationManager.AppSettings["Password"];

        public Web3 initializeWeb3()
        {
            var account = new ManagedAccount(defaultAddress, defaultPassword);

            var web3 = new Web3(account);

            return web3;
        }

        public Web3 initializeWeb3(string address, string password)
        {
            var account = new ManagedAccount(address, password);

            var web3 = new Web3(account);

            return web3;
        }


    }
}