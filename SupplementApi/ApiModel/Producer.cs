﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplementApi.ApiModel
{
    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
    }
}