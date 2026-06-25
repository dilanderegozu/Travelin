namespace Project3Travelin.Dtos.AccountDtos
{
    
    public class UpdateProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string SupportEmail { get; set; }
    }


    public class ChangePasswordDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
