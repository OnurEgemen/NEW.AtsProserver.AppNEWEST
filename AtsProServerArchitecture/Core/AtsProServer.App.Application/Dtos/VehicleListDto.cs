namespace AtsProServer.App.Application.Dtos
{
    public class VehicleListDto
    {
        public int VehicleId { get; set; }
        public string? VehicleName { get; set; }
        public string? VehicleMake { get; set; }
        public string? VehicleBrand { get; set; }

        public int CategoryId { get; set; }
    }
}
