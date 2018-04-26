Steps on how to run:

Install this first:

1. geth Ethereum = https://geth.ethereum.org/downloads/
2. Ethereum Wallet = https://www.ethereum.org/

1.Create directory for the private_net

2.Initialize the genesis using this command in the windows powershell

geth --datadir "(DIRECTORY OF THE CREATED FOLDER)" init "(DIRECTORY OF THE CREATED FOLDER)"

3.Start the geth service using this command in the powershell

geth --networkid "10" --nodiscover --datadir "C:\Ethereum\Geth\robin-chain" --rpc --rpcaddr "localhost" --rpcport "8545" --rpccorsdomain "*" --rpcapi "eth,net,web3,personal" --targetgaslimit "20000000" console

4.Create new 3x accounts in the geth console 
personal.newAccount("password")

5.Start the Ethereum Wallet

6.In the contracts tab click deploy new contract and copy paste the Sol.txt in the SOLIDITY CONTRACT SOURCE CODE

7. Copy the address of the created contract

8. In the Select Function Choose "Fixed Supply Token" and then click execute. Please provide password of the address that will execute the code.

9. In the initContract() and initContract(string address, string password) of the TokenAPI.cs Replace the address of the var TokenContract 
EX. var TokenContract = web3.Eth.GetContract(abi, "new address here");

10. Run TokenApi.sln

11. To test it use ResLet Client 

Ex. Links
http://localhost:[port provided of the visual studio]/Api/GetAllBalance
http://localhost:[port provided of the visual studio]/Api/GetBalance
+Query Parameters
-address