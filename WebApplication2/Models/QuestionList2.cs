using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [Serializable]
    public class QuestionList2
    {
       
       
            public int QuestionId { get; set; }
            public string Question { get; set; }
            public string QuestionType { get; set; }
            public string Answer { get; set; }

        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }
        public string Type4 { get; set; }

    }
}