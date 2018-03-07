using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum BikeKind
    {
        Mountain = 1 << 0,
        City = 1 << 1,
        Tandem = 1 << 2,
        Unicycle = 1 << 3,
        PennyFarthing = 1 << 4,
        PediCab = 1 << 5
    }
}
