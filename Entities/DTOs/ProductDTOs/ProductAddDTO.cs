﻿using Entities.Concreate;
using Entities.DTOs.SpecificationDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ProductDTOs
{
    public class ProductAddDTO
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string PhotoUrl { get; set; }
        public int CategoryId { get; set; }
        public bool Status { get; set; }
        public List<SpecificationAddDTO> Specifications { get; set; }
    }
}
