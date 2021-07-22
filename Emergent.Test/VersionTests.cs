using Emergent.Software;
using NUnit.Framework;


namespace Emergent.Test
{
    public class VersionTests
    {
        [Test]
        public void Version_EmptyString()
        {
            var version = new Version("");
            Assert.AreEqual(version.Major, 0);
            Assert.AreEqual(version.Minor, 0);
            Assert.AreEqual(version.Patch, 0);
        }

        [Test]
        public void Version_EmptyMinor()
        {
            var version = new Version("1..1");
            Assert.AreEqual(version.Major, 1);
            Assert.AreEqual(version.Minor, 0);
            Assert.AreEqual(version.Patch, 1);
        }

        [Test]
        public void Version_ExtraSpaceOnly()
        {
            var version = new Version("1. .2");
            Assert.AreEqual(version.Major, 1);
            Assert.AreEqual(version.Minor, 0);
            Assert.AreEqual(version.Patch, 2);
        }

        [Test]
        public void Version_ExtraSpaceWithDigit()
        {
            var version = new Version("1.0. 3");
            Assert.AreEqual(version.Major, 1);
            Assert.AreEqual(version.Minor, 0);
            Assert.AreEqual(version.Patch, 3);
        }

        [Test]
        public void Version_InvalidLetter()
        {
            Assert.Throws<InvalidVersionCharacterException>(
                delegate { var version = new Version("1a.0.4"); });
        }

        [Test]
        public void Version_InvalidPunctuation()
        {
            Assert.Throws<InvalidVersionCharacterException>(
                delegate { var version = new Version("1,0.5"); });
        }

        [Test]
        public void Version_InvalidIntegerCharacter()
        {
            Assert.Throws<InvalidVersionCharacterException>(
                delegate { var version = new Version("1.0.-6"); });
        }

        [Test]
        public void Version_DefaultMinorPatch()
        {
            var version = new Version("2");
            Assert.AreEqual(version.Major, 2);
            Assert.AreEqual(version.Minor, 0);
            Assert.AreEqual(version.Patch, 0);
        }

        [Test]
        public void Version_DefaultPatch()
        {
            var version = new Version("2.1");
            Assert.AreEqual(version.Major, 2);
            Assert.AreEqual(version.Minor, 1);
            Assert.AreEqual(version.Patch, 0);
        }

        [Test]
        public void Version_ExtraValidCharacters()
        {
            var version = new Version("2.1.1.1");
            Assert.AreEqual(version.Major, 2);
            Assert.AreEqual(version.Minor, 1);
            Assert.AreEqual(version.Patch, 1);
        }
    }
}
