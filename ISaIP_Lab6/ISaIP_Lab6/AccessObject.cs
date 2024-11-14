using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISaIP_Lab6
{
    [Flags]
    public enum AccessRights
    {
        None = 0,
        Read = 1,
        Write = 2,
        DelegateRights = 4,
        Full = 8
    }

    internal class AccessObject
    {
        public string Name { get; }
        public AccessObject(string name)
        {
            Name = name;
        }
    }
}
