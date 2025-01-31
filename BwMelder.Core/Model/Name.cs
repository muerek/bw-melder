using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BwMelder.Core.Model;

record Name
{
    public required string First {  get; set; }
    public required string Last { get; set; }
    public string Full => First + " " + Last;
}
