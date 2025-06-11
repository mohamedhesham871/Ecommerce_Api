using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public  class validationError
    {
        public string faild { get; set; } = string.Empty;
        public IEnumerable<string> errors { get; set; } 
    }
}
