﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSampleApp.Model
{
    public class EmployeeModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
