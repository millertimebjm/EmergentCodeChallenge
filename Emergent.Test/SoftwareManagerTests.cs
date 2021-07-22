using Emergent.Software;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Emergent.Test
{
    public class SoftwareManagerTests
    {
        ISoftwareManager _softwareManager;

        [Test]
        public void GetSoftwareList()
        {
            var softwareList = new List<Software.Software>()
            {
                new Software.Software("a", "1.0.0"),
            };
            _softwareManager = new SoftwareManager(softwareList);
            var result = _softwareManager.GetSoftwareList();
            Assert.AreEqual(softwareList.Single(), result.Single());
        }

        [Test]
        public void GetGreaterVersionNumbers_Single()
        {
            var softwareList = new List<Software.Software>()
            {
                new Software.Software("a", "1.0.0"),
            };
            var version = new Version(0, 0, 0);
            _softwareManager = new SoftwareManager(softwareList);
            var result = _softwareManager.GetGreaterVersionNumbers(version);
            Assert.AreEqual(softwareList.Single(), result.Single());
        }

        [Test]
        public void GetGreaterVersionNumbers_NotEqual()
        {
            var softwareList = new List<Software.Software>()
            {
                new Software.Software("a", "1.0.0"),
                new Software.Software("b", "2.0.0"),
            };
            var version = new Version(1, 0, 0);
            _softwareManager = new SoftwareManager(softwareList);
            var result = _softwareManager.GetGreaterVersionNumbers(version);
            Assert.AreEqual(new Software.Software("b", "2.0.0"), result.Single());
        }

        [Test]
        public void GetGreaterVersionNumbers_Major()
        {
            var softwareList = new List<Software.Software>()
            {
                new Software.Software("a", "1.2.3"),
                new Software.Software("b", "3.0.0"),
            };
            var version = new Version(2, 0, 0);
            _softwareManager = new SoftwareManager(softwareList);
            var result = _softwareManager.GetGreaterVersionNumbers(version);
            Assert.AreEqual(new Software.Software("b", "3.0.0"), result.Single());
        }

        [Test]
        public void GetGreaterVersionNumbers_Minor()
        {
            var softwareList = new List<Software.Software>()
            {
                new Software.Software("a", "1.2.3"),
                new Software.Software("b", "2.1.0"),
            };
            var version = new Version(2, 0, 0);
            _softwareManager = new SoftwareManager(softwareList);
            var result = _softwareManager.GetGreaterVersionNumbers(version);
            Assert.AreEqual(new Software.Software("b", "2.1.0"), result.Single());
        }

        [Test]
        public void GetGreaterVersionNumbers_Batch()
        {
            var softwareList = new List<Software.Software>()
            {
                new Software.Software("a", "1.2.3"),
                new Software.Software("b", "2.1.1"),
            };
            var version = new Version(2, 1, 0);
            _softwareManager = new SoftwareManager(softwareList);
            var result = _softwareManager.GetGreaterVersionNumbers(version);
            Assert.AreEqual(new Software.Software("b", "2.1.1"), result.Single());
        }

        [Test]
        public void GetGreaterVersionNumbers_Multiple()
        {
            var softwareList = new List<Software.Software>()
            {
                new Software.Software("a", "2.2.3"),
                new Software.Software("b", "2.1.1"),
            };
            var version = new Version(2, 1, 0);
            _softwareManager = new SoftwareManager(softwareList);
            var result = _softwareManager.GetGreaterVersionNumbers(version);
            Assert.AreEqual(softwareList.Count(), result.Count());
        }

        [Test]
        public void GetGreaterVersionNumbers_MultipleDigitMajorFilter()
        {
            var softwareList = new List<Software.Software>()
            {
                new Software.Software("a", "14.3.1"),
            };
            var version = new Version(9, 1, 1);
            _softwareManager = new SoftwareManager(softwareList);
            var result = _softwareManager.GetGreaterVersionNumbers(version);
            Assert.AreEqual(new Software.Software("a", "14.3.1"), result.First());
        }

        [Test]
        public void GetGreaterVersionNumbers_MultipleDigitMinorFilter()
        {
            var softwareList = new List<Software.Software>()
            {
                new Software.Software("a", "3.14.1"),
            };
            var version = new Version(3, 9, 0);
            _softwareManager = new SoftwareManager(softwareList);
            var result = _softwareManager.GetGreaterVersionNumbers(version);
            Assert.AreEqual(new Software.Software("a", "3.14.1"), result.First());
        }

        [Test]
        public void GetGreaterVersionNumbers_MultipleDigitPatchFilter()
        {
            var softwareList = new List<Software.Software>()
            {
                new Software.Software("a", "3.1.28"),
            };
            var version = new Version(3, 1, 9);
            _softwareManager = new SoftwareManager(softwareList);
            var result = _softwareManager.GetGreaterVersionNumbers(version);
            Assert.AreEqual(new Software.Software("a", "3.1.28"), result.First());
        }
    }
}