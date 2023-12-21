﻿using Core.Entities;
using Core.Entities.Concreate;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Users
{
    public class User : AppUser, IEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Order> Orders { get; set; }
        public List<WishList> WishLists { get; set; }
    }
}
