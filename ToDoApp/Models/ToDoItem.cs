using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class ToDoTask
    {
        public int Index { set; get; }

        public string Description { set; get; }

        public bool IsCompleted { set; get; }
    }
}
