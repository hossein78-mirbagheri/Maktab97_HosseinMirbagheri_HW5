using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Interfase.Exception
{
    public class CheckNameException:ApplicationException
    {
        public override string Message => "Name Of Product Is Not True";
    }
}
