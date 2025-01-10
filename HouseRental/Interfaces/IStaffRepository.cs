using HouseRental.Modules;

namespace HouseRental.Interfaces
{
    public interface IStaffRepository
    {
        Staff AuthenticateStaff(string email, string password); // Authenticate staff using email and password
    }
}
