using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email.Data.Enums
{
    public enum Port
    {
        SSL = 465,
        /// <warning>
        /// Can be used only on GMAIL SERVICE 
        /// </warning>
        TLS = 587
    }
}
