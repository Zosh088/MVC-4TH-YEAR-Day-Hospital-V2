using System.ComponentModel.DataAnnotations;

namespace Surgeon__Day_Hospital_.DapperLibrary.ViewModels
{
    public class ViewAddress
    {
        // Address-Book
        //public Address_Book address { get; set; }

        public int AddressID { get; set; }
        public string StreetName { get; set; }

        // Suburb_Records
        //public Suburb_Records suburb { get; set; }

        public int SuburbID { get; set; }
        public string SuburbName { get; set; }
        public int PostalCode { get; set; }

        // City_Records
        //public City_Records city { get; set; }

        public int CityID { get; set; }
        public string CityName { get; set; }

        // Province_Records
        //public Province_Records province { get; set; }

        public int ProvinceID { get; set; }
        public string ProvinceName { get; set; }
    }
}
