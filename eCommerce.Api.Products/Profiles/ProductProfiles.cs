﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Api.Products.Profiles
{
    public class ProductProfiles:AutoMapper.Profile
    {
        public ProductProfiles() {

            CreateMap<Db.Product, Models.Product>();
        
        }
        
    }
}
