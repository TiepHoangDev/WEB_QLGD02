﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF.BussinessObject.Objects;

namespace WEB_QLGD01.Models
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}