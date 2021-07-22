using System;
using System.Collections.Generic;
using System.Text;

namespace Emergent.Software
{
    public interface ISoftwareManager
    {
        IEnumerable<Software> GetGreaterVersionNumbers(Version version);
        IEnumerable<Software> GetSoftwareList();
    }
}
