using Dapper;
using HouseRental.Interfaces;
using HouseRental.Modules;
using MySqlConnector;

namespace HouseRental.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly string _connectionString;

        public PropertyRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Property> GetAllProperties()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Property>("CALL GetAllProperties()");
            }
        }

        public Property GetPropertyById(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                return connection.QuerySingleOrDefault<Property>("CALL GetPropertyById(@PropertyId)", new { PropertyId = id });
            }
        }

        public void AddProperty(Property property)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute("CALL AddProperty(@Name, @Status, @Category, @Country, @City, @Subcity, @Imgurl)", property);
            }
        }

        public void UpdatePropertyStatus(int propertyId, string newStatus)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute("CALL UpdatePropertyStatus(@PropertyId, @NewStatus)", new { PropertyId = propertyId, NewStatus = newStatus });
            }
        }

        public void DeleteProperty(int propertyId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Execute("CALL DeleteProperty(@PropertyId)", new { PropertyId = propertyId });
            }
        }
    }
}