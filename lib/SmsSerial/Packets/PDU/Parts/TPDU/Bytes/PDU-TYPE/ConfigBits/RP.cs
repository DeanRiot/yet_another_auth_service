using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sms.Payload.Parts.TPDU.PDU_TYPE.ConfigBits
{
    /// <summary>
    /// Reply path bit
    /// </summary>
    internal enum RP
    {
        NONE = 0b00000000,
        SMSC = 0b10000000
    }
}
