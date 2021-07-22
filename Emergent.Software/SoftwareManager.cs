using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emergent.Software
{
    public class SoftwareManager : ISoftwareManager
    {
        private IEnumerable<Software> _softwareList; // I don't like the name, but _softwares doesn't look great either, other option _allSoftware
        public SoftwareManager()
        {
            _softwareList = LoadAllSoftware();
        }
        public SoftwareManager(IEnumerable<Software> softwareList)
        {
            _softwareList = softwareList;
        }

        // Version should be validated on front-end, not here
        public IEnumerable<Software> GetGreaterVersionNumbers(Version version)
        {
            return _softwareList.Where(_ => _.Version.Major > version.Major
                || (_.Version.Major == version.Major && _.Version.Minor > version.Minor)
                || (_.Version.Major == version.Major && _.Version.Minor == version.Minor && _.Version.Patch > version.Patch));
        }

        public IEnumerable<Software> GetSoftwareList()
        {
            return _softwareList;
        }

        private static IEnumerable<Software> LoadAllSoftware()
        {
            return new List<Software>
            {
                new Software("MS Word", "13.2.1."),
                new Software("AngularJS", "1.7.1"),
                new Software("Angular", "8.1.13"),
                new Software("React", "0.0.5"),
                new Software("Vue.js", "2.6"),
                new Software("Visual Studio", "2017.0.1"),
                new Software("Visual Studio", "2019.1"),
                new Software("Visual Studio Code", "1.35"),
                new Software("Blazor", "0.7"),
            };
        }
    }
}
