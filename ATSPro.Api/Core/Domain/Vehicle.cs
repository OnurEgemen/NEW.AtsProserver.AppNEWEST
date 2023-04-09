namespace ATSPro.Api.Core.Domain
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

        public Vehicle()
        {
            Category= new Category();
        }
        
    }
}
