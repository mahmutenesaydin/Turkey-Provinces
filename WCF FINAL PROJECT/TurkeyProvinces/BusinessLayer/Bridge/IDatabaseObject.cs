using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Bridge
{
    public interface IDatabaseObject<T>
    {
        List<T> ShowAll();
        T Prior { get; }
        T Next { get; }
    }
}
