namespace ATSPro.Api.Core.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string? Definition { get; set; }

        public List<Vehicle>? Vehicles { get; set; }

        public Category()
        {
            Vehicles = new List<Vehicle>();
        }

       

    }
}
