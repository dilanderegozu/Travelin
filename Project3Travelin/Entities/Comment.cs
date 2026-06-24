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
  
        public string NameSurname { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string TourId { get; set; }
        public DateTime CommentDate { get; set; }

        public bool IsStatus { get; set; }

    
    }
}
