using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyhetssida.Shared
{
   
    public class Source
    { 
        public int SourceId { get; set; }
        [Required]
        public string? NewsSource { get; set; }
    }

}
