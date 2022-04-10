using backend.DTOs;
using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Helpers
{
    public class Mapper
    {
        internal List<PropertyListDTO> MapPropertiesToPropertiesDTO(IEnumerable<Property> properties)
        {
            List<PropertyListDTO> list = new List<PropertyListDTO>();

            foreach (var property in properties)
            {
                PropertyListDTO p = new PropertyListDTO();
                p.BHK = property.BHK;
                p.BuiltArea = property.BuiltArea;
                p.City = property.City.Name;
                p.Country = property.City.Country;
                p.FurnishingType = property.FurnishingType.Name;
                p.Id = property.Id;
                p.Name = property.Name;
                p.Price = property.Price;
                p.PropertyType = property.PropertyType.Name;
                p.ReadyToMove = property.ReadyToMove;
                p.EstPossessionOn = property.EstPossessionOn;

                list.Add(p);
            }

            return list;
        }

        internal List<KVPair> MapFurnishingTypesToKVPairDTO(IEnumerable<FurnishingType> furnishingTypes)
        {
            List<KVPair> list = new List<KVPair>();

            foreach (var type in furnishingTypes)
            {
                KVPair p = new KVPair();
                p.Id = type.Id;
                p.Name = type.Name;

                list.Add(p);
            }

            return list;
        }

        internal Property MapPropertyToPropertyDTO(PropertyDTO property)
        {
            Property p = new Property();
            p.Address = property.Address;
            p.Address2 = property.Address2;
            p.BHK = property.BHK;
            p.BuiltArea = property.BuiltArea;
            p.CarpetArea = property.CarpetArea;
            p.CityId = property.CityId;
            p.Description = property.Description;
            p.EstPossessionOn = property.EstPossessionOn;
            p.FloorNo = property.FloorNo;
            p.FurnishingTypeId = property.FurnishingTypeId;
            p.Gated = property.Gated;
            p.MainEntrance = property.MainEntrance;
            p.Name = property.Name;
            p.Price = property.Price;
            p.PropertyTypeId = property.PropertyTypeId;
            p.ReadyToMove = property.ReadyToMove;
            p.SellRent = property.SellRent;
            p.TotalFloors = property.TotalFloors;

            return p;
        }

        internal List<KVPair> MapPropertyTypesToKVPairDTO(IEnumerable<PropertyType> propertyTypes)
        {
            List<KVPair> list = new List<KVPair>();

            foreach (var type in propertyTypes)
            {
                KVPair p = new KVPair();
                p.Id = type.Id;
                p.Name = type.Name;

                list.Add(p);
            }

            return list;
        }

        internal PropertyDetailDTO MapPropertyToPropertyDetailDTO(Property property)
        {
            PropertyDetailDTO p = new PropertyDetailDTO();
            
            p.Address = property.Address;
            p.Address2 = property.Address2;
            p.Age = property.Age;
            p.BHK = property.BHK;
            p.BuiltArea = property.BuiltArea;
            p.CarpetArea = property.CarpetArea;
            p.City = property.City.Name;
            p.Country = property.City.Country;
            p.Description = property.Description;
            p.EstPossessionOn = property.EstPossessionOn;
            p.FloorNo = property.FloorNo;
            p.FurnishingType = property.FurnishingType.Name;
            p.Gated = property.Gated;
            p.Id = property.Id;
            p.MainEntrance = property.MainEntrance;
            p.Maintenance = property.Maintenance;
            p.Name = property.Name;
            p.Price = property.Price;
            p.PropertyType = property.PropertyType.Name;
            p.ReadyToMove = property.ReadyToMove;
            p.Security = property.Security;
            p.SellRent = property.SellRent; 
            p.TotalFloors = property.TotalFloors;

            return p;
        }
    }
}
