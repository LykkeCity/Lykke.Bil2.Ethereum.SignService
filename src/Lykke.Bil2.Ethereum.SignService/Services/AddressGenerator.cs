using System.Threading.Tasks;
using Lykke.Bil2.Contract.SignService.Requests;
using Lykke.Bil2.Contract.SignService.Responses;
using Lykke.Bil2.Sdk.SignService.Models;
using Lykke.Bil2.Sdk.SignService.Services;

namespace Lykke.Bil2.Ethereum.SignService.Services
{
    public class AddressGenerator : IAddressGenerator
    {
        public AddressGenerator()
        {
        }

        public async Task<AddressCreationResult> CreateAddressAsync()
        {
            var ethEcKey = Nethereum.Signer.EthECKey.GenerateKey();
            var address = ethEcKey.GetPublicAddress();
            var privateKey = ethEcKey.GetPrivateKey();

            return new AddressCreationResult(address, privateKey, null);
        }

        public async Task<CreateAddressTagResponse> CreateAddressTagAsync(string address, CreateAddressTagRequest request)
        {
            throw new Lykke.Bil2.Sdk.Exceptions.OperationNotSupportedException();
        }
    }
}
