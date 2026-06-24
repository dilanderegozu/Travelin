namespace Project3Travelin.Dtos.CommentDtos
{
    public class UpdateCommentDto
    {
        public string CommentId { get; set; }

        public string HeadLine { get; set; }

        public string CommentDetail { get; set; }

        public int Score { get; set; }

        public string NameSurname { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public string TourId { get; set; }

        public DateTime CommentDate { get; set; }

        public bool IsStatus { get; set; }
    }
}
