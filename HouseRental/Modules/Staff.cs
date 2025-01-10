using System.ComponentModel.DataAnnotations;

namespace HouseRental.Modules
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffEmail { get; set; }
        public string StaffPassword { get; set; }
        public string StaffPhoneNumber { get; set; }
        public string? ProfilePicture { get; set; }
        public string branch { get; set; }
        
    }
}
