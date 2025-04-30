﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BaseEntity<TKey>  
    {
        // make BaseEntity generic Because  not all entities have the same type of id
        public TKey id { get; set; } = default!;
        public string Name { get; set; } = default!;

    }

}
