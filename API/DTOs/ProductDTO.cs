using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public string ProductType { get; set; }

        public string ProductBrand { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
        
        public string CreatedBy { get; set; }
        
        public DateTimeOffset UpdatedOn { get; set; }
        
        public string UpdatedBy { get; set; }
        
        public DateTimeOffset DeletedOn { get; set; }
        
        public string DeletedBy { get; set; }
    }
}
