using System.Collections.Generic;
using TokenApi.Models.TokenModel;
using System.Configuration;
using TokenApi.Models.Default;

namespace TokenApi.Functions
{
    public class TokenApiClass : DefaultToken
    {

        private string[] GetAccounts()
        {
            var web3 = initializeWeb3();
            var accounts = web3.Eth.Accounts.SendRequestAsync();
            accounts.Wait();
            return accounts.Result;

        }

        public TokenBalance GetBalance(string id)
        {
            var TokenContract = initContract();
            var tokenbalance = new TokenBalance();

            var TaskGetBalance = TokenContract.GetFunction("balanceOf").CallAsync<int>(id);
            TaskGetBalance.Wait();

            tokenbalance.balance = TaskGetBalance.Result;

            return tokenbalance;

        }

        public TokenBalance GetAllowance(string addressFrom, string addressTo)
        {
            var TokenContract = initContract();
            var tokenbalance = new TokenBalance();

            var TaskGetBalance = TokenContract.GetFunction("allowance").CallAsync<int>(addressFrom, addressTo);
            TaskGetBalance.Wait();

            tokenbalance.balance = TaskGetBalance.Result;

            return tokenbalance;

        }

        public TokenTransaction TransferBalance(string address, int amount)
        {
            var TokenContract = initContract();
            var tokentransaction = new TokenTransaction();

            string senderAddress = ConfigurationManager.AppSettings["SendAddress"];

            var TaskisTransactionTrue = TokenContract.GetFunction("transfer").CallAsync<bool>(address,amount);
            TaskisTransactionTrue.Wait();

            if (TaskisTransactionTrue.Result == true)
            {

                var recieptFirstAmountSend = TokenContract.GetFunction("transfer").SendTransactionAsync(senderAddress, address, amount);
                recieptFirstAmountSend.Wait();

                tokentransaction.transactionSuccess = true;
                tokentransaction.transactionhash = recieptFirstAmountSend.Result;


                return tokentransaction;
            }

            else
            {

                tokentransaction.transactionSuccess = false;
                tokentransaction.transactionhash = "error";
                return tokentransaction;
            }
        }


        public TokenBalance GetSupply()
        {
            var TokenContract = initContract();
            var tokenbalance = new TokenBalance();

            var TaskGetSupply = TokenContract.GetFunction("totalSupply").CallAsync<int>();
            TaskGetSupply.Wait();

            tokenbalance.balance = TaskGetSupply.Result;

            return tokenbalance;
        }

        public TokenTransaction Approve(string addressFrom, string password, string addressTo, int amount)
        {
            var TokenContract = initContract(addressFrom, password);
            var tokentransaction = new TokenTransaction();

            var TaskisTransactionTrue = TokenContract.GetFunction("approve").CallAsync<bool>(addressFrom, amount);
            TaskisTransactionTrue.Wait();

            if (TaskisTransactionTrue.Result == true)
            {

                var recieptFirstAmountSend = TokenContract.GetFunction("approve").SendTransactionAsync(addressFrom, addressTo, amount);
                recieptFirstAmountSend.Wait();

                tokentransaction.transactionSuccess = true;
                tokentransaction.transactionhash = recieptFirstAmountSend.Result;

                return tokentransaction;
            }

            else
            {

                tokentransaction.transactionSuccess = false;
                tokentransaction.transactionhash = "error";
                return tokentransaction;
            }

        }
      
        public TokenTransaction TransferFrom(string addressFrom, string addressTo, string password, int amount)
        {
            var TokenContract = initContract(addressTo, password);
            var tokentransaction = new TokenTransaction();


                var TaskTransferFrom = TokenContract.GetFunction("transferFrom").SendTransactionAsync(addressTo, addressFrom, addressTo, amount);
                TaskTransferFrom.Wait();

                tokentransaction.transactionSuccess = true;
                tokentransaction.transactionhash = TaskTransferFrom.Result;

                return tokentransaction;

        }

        public List<TokenBalanceV2> GetAllTokenBalance()
        {
            var TokenContract = initContract();
            var tokenbalancelist = new List<TokenBalanceV2>();

            var accountList = GetAccounts();

            foreach(string item in accountList)
            {
                var TaskGetBalance = TokenContract.GetFunction("balanceOf").CallAsync<int>(item);
                TaskGetBalance.Wait();

                tokenbalancelist.Add(new TokenBalanceV2()
                {
                    address = item,
                    balance = TaskGetBalance.Result
                });

            }

            return tokenbalancelist;
               
        }

           

    }
}