﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Serializable]
    public class QuestionList
    {
       
       
            public int ID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
        
    }
}