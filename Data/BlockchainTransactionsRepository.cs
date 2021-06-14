
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
        private readonly IMongoClient client;
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<TransactionBlock> transactionCollection;

        public BlockchainTransactionsRepository(IConfiguration configuration)
        {
            this.client = new MongoClient(configuration.GetConnectionString("MongoConnection"));
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
                if(result.NextHash.Equals(string.Empty))
                    break;
                nextHash = result.NextHash;
                filter = Builders<TransactionBlock>.Filter.Eq("Hash", nextHash);
            }
            return transactions;
        }

        private async Task<TransactionBlock> GetLastTransaction(string genNodeId)
        {
            var filter = Builders<TransactionBlock>.Filter.Eq("Hash", genNodeId);
            string nextHash;
            while (true)
            {
                var result = await transactionCollection.Find(filter).FirstOrDefaultAsync();
                if(result.NextHash.Equals(string.Empty))
                    return result;
                nextHash = result.NextHash;
                filter = Builders<TransactionBlock>.Filter.Eq("Hash", nextHash);
            }
        }

        private async Task<string> UpdateNextHash(TransactionBlock transactionBlock)
        {
            string nextHash = CreateHash(transactionBlock.Hash, transactionBlock.TimeStamp);
            var filter = Builders<TransactionBlock>.Filter.Eq("_id", transactionBlock.Id);
            var update = Builders<TransactionBlock>.Update.Set("nextHash", nextHash);
            var result = await transactionCollection.UpdateOneAsync(filter, update);
            return (result.MatchedCount != 0) ? nextHash : string.Empty;
        }

        private string CreateHash(string previousHash, DateTime timeStamp)
        {
            using(SHA256 sha256 = SHA256.Create())
            {
                string rawData = $"{previousHash}{timeStamp.ToLongTimeString()}NewTransaction";
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return Encoding.Default.GetString(bytes);
            }
        }
    }
}