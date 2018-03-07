using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public enum QueryType
    {
        StoredProcedure = 1 << 0,
        Query = 1 << 1
    }
}
