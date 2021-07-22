using System;
using System.Collections.Generic;
using System.Linq;

namespace Emergent.Software
{
    public class Software
    {
        public string Name { get; set; }
        public string VersionString { 
            get
            {
                return Version.ToString();
            }
        }
        public Version Version { get; set; }

        public Software(string name, string version)
        {
            Name = name;
            Version = new Version(version);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Software))
            {
                return this.Equals((Software)obj);
            }
            return false;
        }

        private bool Equals(Software s)
        {
            return this.Name == s.Name 
                && this.Version.Major == s.Version.Major
                && this.Version.Minor == s.Version.Minor
                && this.Version.Patch == s.Version.Patch;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
