using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Project3Travelin.Entities
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CommentId { get; set; }
        public string HeadLine { get; set; }
        public string CommentDetail { get; set; }
        public int Score { get; set; }
        public DateTime CommentDate { get; set; }
        public bool IsStatus { get; set; }  
    }
}
