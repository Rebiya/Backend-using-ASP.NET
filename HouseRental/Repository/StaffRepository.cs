using HouseRental.Data;
using HouseRental.Modules;
using HouseRental.Interfaces;

namespace HouseRental.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly DataContext _context;

        public StaffRepository(DataContext context)
        {
            _context = context;
        }

        public Staff AuthenticateStaff(string email, string password)
        {
            var staff = _context.Staffs.FirstOrDefault(s => s.StaffEmail == email);
            if (staff != null && staff.StaffPassword == password)
            {
                return staff;
            }
            return null;
        }
    }
}