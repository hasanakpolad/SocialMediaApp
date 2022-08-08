using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Data.Models
{
    public class PostModel
    {
        [BsonId(IdGenerator = typeof(BsonObjectIdGenerator))]
        public ObjectId Id { get; set; }

        public string PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostMessage { get; set; }
        public string PostImage { get; set; }
        public int LikeCount { get; set; }
        public List<string> PostComment { get; set; }

    }
}
