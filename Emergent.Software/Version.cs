using System;
using System.Linq;

namespace Emergent.Software
{
    public class Version
    {
        public int Major { get; set; } = 0;
        public int Minor { get; set; } = 0;
        public int Patch { get; set; } = 0;

        public Version(int major, int minor, int patch)
        {
            Major = major;
            Minor = minor;
            Patch = patch;
        }

        public Version(string version)
        {
            if (version == null)
            {
                throw new NullReferenceException("Version string is null.");
            }

            // Dash/hyphen is a valid character for parsing integers but not valid in version numbers
            if (version.Contains("-"))
            {
                throw new InvalidVersionCharacterException(version);
            }

            // Two parses not ideal but it's cleaner to read
            var versionArray = version.Split(".", StringSplitOptions.None); // assume 0 for Version Part if blank
            if (versionArray.Any(_ => _.Trim() != "" && !int.TryParse(_, out int result)))
            {
                throw new InvalidVersionCharacterException(version);
            }
            if (versionArray.Length > 0)
            {
                Major = versionArray[0].Trim() == "" ? 0 : int.Parse(versionArray[0]);
            }
            if (versionArray.Length > 1)
            {
                Minor = versionArray[1].Trim() == "" ? 0 : int.Parse(versionArray[1]);
            }
            if (versionArray.Length > 2)
            {
                Patch = versionArray[2].Trim() == "" ? 0 : int.Parse(versionArray[2]);
            }
        }

        public override string ToString()
        {
            return $"{Major}.{Minor}.{Patch}";
        }
    }
}
