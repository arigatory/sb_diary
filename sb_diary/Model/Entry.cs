using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sb_diary.Model
{
    public class Entry
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsImportant { get; set; }
    }
}
