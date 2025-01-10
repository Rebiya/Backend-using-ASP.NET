using System.ComponentModel.DataAnnotations;

namespace HouseRental.Modules
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserPhoneNUmber { get; set; }
        public string? UserProfilePicture { get; set; }
    }
}
