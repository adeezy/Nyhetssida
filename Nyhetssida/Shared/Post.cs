using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyhetssida.Shared
{
    public class Post
    {
        public string Titel { get; set; }
        public string? Image { get; set; }
        public string Description { get; set; }
        public DateTime PubDate { get; set; }
        public string? Category { get; set; }
        public string Link { get; set; }
        public string Source { get; set; }
    }
}
