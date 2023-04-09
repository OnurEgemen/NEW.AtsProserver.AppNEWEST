using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtsProServer.App.Domain.Entities
{
    public class Vehicle
    {
        //Küçük not: Hata olursa VehicleId Id olarak değişebilir!
        public int VehicleId { get; set; }
        public string? VehicleName { get; set; }
        public string? VehicleMake { get; set; }
        public string? VehicleBrand { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

     
    }
}
