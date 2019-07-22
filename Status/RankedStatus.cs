using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuUtil.Status
{
    public enum RankedStatus : byte
    {
        UNKNOWN = 0,
        UNSUBMITTED = 1,
        PENDING = 2,
        UNUSED = 3,
        RANKED = 4,
        APPROVED = 5,
        QUALIFIED = 6,
        LOVED = 7
    }
}
