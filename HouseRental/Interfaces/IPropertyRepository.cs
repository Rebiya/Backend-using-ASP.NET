using System.Collections.Generic;
using HouseRental.Modules;

namespace HouseRental.Interfaces
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAllProperties();
        Property GetPropertyById(int id);
        void AddProperty(Property property);
        void UpdatePropertyStatus(int propertyId, string newStatus);
        void DeleteProperty(int propertyId);
    }
}