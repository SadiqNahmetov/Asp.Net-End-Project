﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Models
{
    public class OurBlog : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
