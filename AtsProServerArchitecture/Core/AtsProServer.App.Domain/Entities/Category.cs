using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtsProServer.App.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string? Definition { get; set; }

        public List<Vehicle>? Vehicles { get; set; }

       
    }
}
