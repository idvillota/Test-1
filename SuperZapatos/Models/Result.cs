using System.Collections.Generic;

namespace SuperZapatos.Models
{
    public class Result
    {        
        public bool Success { get; set; }

        public int Total_elements { get; set; }

        public List<Article> Articles { get; set; }

    }
}