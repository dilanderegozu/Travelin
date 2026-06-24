namespace Project3Travelin.Dtos.CommentDtos
{
    public class CreateCommentDto
    {
        public string HeadLine { get; set; }

        public string CommentDetail { get; set; }

        public int Score { get; set; }

        public string NameSurname { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public string TourId { get; set; }
    }
}
