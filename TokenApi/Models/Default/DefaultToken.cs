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
    public class DefaultToken : DefaultWeb3
    {
        public string defaultAbi = ConfigurationManager.AppSettings["TokenAbi"];
        public string defaultContractAddress = ConfigurationManager.AppSettings["ContractAddress"];

        /// <summary>
        /// Initialize Contract with the default address and password
        /// </summary>
        /// <returns></returns>
        public Contract initContract()
        {

            var web3 = initializeWeb3();

            var TokenContract = web3.Eth.GetContract(defaultAbi, defaultContractAddress);

            web3.Eth.TransactionManager.DefaultGas = 100000;

            return TokenContract;

        }

        /// <summary>
        /// Initialize Contract with the provided address and password
        /// </summary>
        /// <returns></returns>
        public Contract initContract(string address, string password)
        {

            var web3 = initializeWeb3(address, password);

            var TokenContract = web3.Eth.GetContract(defaultAbi, defaultContractAddress);

            web3.Eth.TransactionManager.DefaultGas = 100000;

            return TokenContract;
        }

    }
}