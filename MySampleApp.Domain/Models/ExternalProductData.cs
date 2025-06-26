using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySampleApp.Domain.Models
{
    public class ExternalProductData
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public float Price { get; set; }
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Image { get; set; } = null!;
        public Rating Rating { get; set; } = new();
    }

    public class Rating
    {
        public float Rate { get; set; }
        public int Count { get; set; }
    }

}
