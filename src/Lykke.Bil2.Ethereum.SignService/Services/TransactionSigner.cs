using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lykke.Bil2.Contract.Common.Exceptions;
using Lykke.Bil2.Contract.Common.Extensions;
using Lykke.Bil2.Contract.SignService.Responses;
using Lykke.Bil2.Sdk.SignService.Services;
using Lykke.Bil2.SharedDomain;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Signer;

namespace Lykke.Bil2.Ethereum.SignService.Services
{
    public class TransactionSigner : ITransactionSigner
    {
        public TransactionSigner()
        {
        }

        public Task<SignTransactionResponse> SignAsync(IReadOnlyCollection<string> privateKeys, Base58String requestTransactionContext)
        {
            try
            {
                var firstKey = privateKeys.FirstOrDefault();
                string trString = requestTransactionContext.DecodeToString();
                var transaction = new Transaction(trString.HexToByteArray());
                string transactionHash = transaction.RawHash.ToHex(true);
                var secret = new EthECKey(firstKey);

                transaction.Sign(secret);
                var signedTransaction = transaction
                    .GetRLPEncoded()
                    .ToHex()
                    .ToBase58();

                return Task.FromResult(new SignTransactionResponse
                (
                    signedTransaction,
                    transactionHash
                ));
            }
            catch (FormatException ex)
            {
                throw new RequestValidationException("Invalid transaction context, must be valid Ethereum transaction",
                    ex, nameof(requestTransactionContext));
            }
        }
    }
}
