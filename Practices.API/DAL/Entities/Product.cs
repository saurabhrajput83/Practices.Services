using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practices.API.DAL.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public bool IsActive { get; set; }
        public decimal ListPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
        public int DepartmentId { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductUrl { get; set; }
        public Brand Brand { get; set; }
        public Department Department { get; set; }
    }
}
