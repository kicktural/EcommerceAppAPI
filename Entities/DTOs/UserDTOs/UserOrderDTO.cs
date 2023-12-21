using Entities.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.UserDTOs
{
    public class UserOrderDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<OrderUserDTO>? orderUserDTOs { get; set; }
    }
}
