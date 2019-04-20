using System;
using System.Threading.Tasks;
using Lykke.Bil2.Ethereum.SignService.Settings;
using Lykke.Bil2.Contract.Common;
using Lykke.Bil2.Contract.SignService.Requests;
using Lykke.Bil2.Contract.SignService.Responses;
using Lykke.Bil2.Sdk;
using Lykke.Bil2.Sdk.SignService.Models;
using Lykke.Bil2.Sdk.SignService.Services;

namespace Lykke.Bil2.Ethereum.SignService.Services
{
    public class AddressGenerator : IAddressGenerator
    {
        public AddressGenerator(/* TODO: Provide specific settings and dependencies, if necessary */)
        {
        }

        public async Task<AddressCreationResult> CreateAddressAsync()
        {
            // Create dedicated deposit wallet, or return shared deposit wallet address.
            //
            // Throw
            // - Lykke.Bil2.Sdk.Exceptions.OperationNotSupportedException:
            //     if offline address creation is not supported by the blockchain.
            //
            // For example when shared deposit wallet scheme is used:
            //
            // return new AddressCreationResult(_hotWalletAddress, null, _hotWalletPublicKey.ToBase58());


            throw new System.NotImplementedException();
        }

        public async Task<CreateAddressTagResponse> CreateAddressTagAsync(string address, CreateAddressTagRequest request)
        {
            // Create tag (new GUID, usually) for deposit wallet, if shared deposit wallet scheme is used.
            //
            // Throw
            // - Lykke.Bil2.Sdk.Exceptions.OperationNotSupportedException:
            //     if address tag creation is not supported by the blockchain.
            //
            // For example:
            //
            // return new CreateAddressTagResponse(Guid.NewGuid().ToString("N"));


            throw new System.NotImplementedException();
        }
    }
}
