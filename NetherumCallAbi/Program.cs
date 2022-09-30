using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System.Numerics;
using System.Security.Principal;

namespace NetherumCallAbi
{
    public class Program
    {

        static async Task Main(string[] args)
        {

            //Acá pones tu llave privada que no debes compartir con nadie!        
            string _privatekey = "tu llave privada";
            //un proveedor gratis de la testnet de BNB https://www.ankr.com/rpc/
            string _strconnection = "https://rpc.ankr.com/bsc_testnet_chapel";
            //chain ID de la BNBChain testnet 97
            //https://academy.binance.com/en/articles/connecting-metamask-to-binance-smart-chain
            Account account = new Account(_privatekey, new BigInteger(97));
            Web3 web3 = new Web3(account, _strconnection);
            string contractAdress = "0x7BcAF331B2d33Fbdc17De5dD0C3DEadb360503bb";
            //el abi lo sacamos del bnbstudio
            var abi = @"
                        [
                         {
                          ""inputs"": [],
                          ""name"": ""getResult"",
                          ""outputs"": [
                           {
                             ""internalType"": ""string"",
                             ""name"": """",
                             ""type"": ""string""
                           }
                          ],
              ""stateMutability"": ""view"",
              ""type"": ""function""
            }
          ]";
            Nethereum.Contracts.Contract contract = web3.Eth.GetContract(abi, contractAdress);
            //Invocación de la función del contrato inteligente
            var function = contract.GetFunction("getResult");
            //la función del smart contract retorna un datos tipo string
            var result = await function.CallAsync<string>();
            Console.WriteLine(result);
            Console.ReadLine();
        }

    }
}

