using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace historial_blockchain.Models
{
    public class TransactionBlock
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("timeStamp")]
        public DateTime TimeStamp { get; set; }

        [BsonElement("hash")]
        public string Hash { get; set; }

        [BsonElement("nextHash")]
        public string NextHash { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }    

        [BsonElement("consultaMedica")]
        public ConsultaMedica ConsultaMedica { get; set; }
    }
}