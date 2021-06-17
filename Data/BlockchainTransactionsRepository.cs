
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using historial_blockchain.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace historial_blockchain.Data
{
    public class BlockchainTransactionsRepository
    {
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<TransactionBlock> transactionCollection;

        public BlockchainTransactionsRepository(IConfiguration configuration)
        {
            IMongoClient client = new MongoClient(configuration.GetConnectionString("MongoConnection"));
            this.database = client.GetDatabase("ConsultasMedicas");
            this.transactionCollection = database.GetCollection<TransactionBlock>("transactions");
        }

        /// <summary>
        /// Crear nodo génesis.
        /// </summary>
        public async Task InsertTransaction(TransactionBlock transactionBlock)
        {
            await transactionCollection.InsertOneAsync(transactionBlock);
        }


        /// <summary>
        /// Inserar una nueva transacción actualizando el último nodo.
        /// </summary>
        public async Task InsertTransaction(TransactionBlock transactionBlock, string genNodeId)
        {
            transactionBlock.Hash = await UpdateNextHash(await GetLastTransaction(genNodeId));
            await transactionCollection.InsertOneAsync(transactionBlock);
        }

        public async Task<List<TransactionBlock>> GetTransactions(string genNodeId)
        {
            var transactions = new List<TransactionBlock>();
            var filter = Builders<TransactionBlock>.Filter.Eq("Hash", genNodeId);
            string nextHash;
            while (true)
            {
                var result = await transactionCollection.Find(filter).FirstOrDefaultAsync();
                transactions.Add(result);
                if(string.IsNullOrEmpty(result.NextHash))
                    break;
                nextHash = result.NextHash;
                filter = Builders<TransactionBlock>.Filter.Eq("Hash", nextHash);
            }
            return transactions;
        }

        private async Task<TransactionBlock> GetLastTransaction(string genNodeId)
        {
            var filter = Builders<TransactionBlock>.Filter.Eq("Hash", genNodeId);
            var result = await transactionCollection.Find(filter).FirstOrDefaultAsync();
            if(string.IsNullOrEmpty(result.NextHash))
                return result;
            string nextHash = result.NextHash;
            while (true)
            {
                var filterIteration = Builders<TransactionBlock>.Filter.Eq("Hash", nextHash);
                var resultIteration = await transactionCollection.Find(filterIteration).FirstOrDefaultAsync();
                if(string.IsNullOrEmpty(resultIteration.NextHash))
                    return resultIteration;
                nextHash = resultIteration.NextHash;
            }
        }

        private async Task<string> UpdateNextHash(TransactionBlock transactionBlock)
        {
            string nextHash = Guid.NewGuid().ToString();
            var filter = Builders<TransactionBlock>.Filter.Eq("_id", transactionBlock.Id);
            var update = Builders<TransactionBlock>.Update.Set("nextHash", nextHash);
            var result = await transactionCollection.UpdateOneAsync(filter, update);
            return (result.MatchedCount != 0) ? nextHash : string.Empty;
        }
    }
}