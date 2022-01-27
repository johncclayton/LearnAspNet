using Necklace.Api;
using System;
using Xunit;

namespace NecklaceApi.Tests
{
    [Collection("DataFile")]

    public class SubmitAppCastTest
    {
        private DataLocationFixture fix_location;

        public SubmitAppCastTest(DataLocationFixture f)
        {
            fix_location = f;
        }

        [Fact]
        public void TestSubmissionOfAppCast()
        {
            // will make up a simple series of binaries and changelogs - submit to system
            AppArtifact na = new AppArtifact();
            Assert.NotNull(na);

            var changelog = @"
Version 1.1.0
=============
* I did some things; they were great.
".Trim();

            Tuple<string, string> names_110 = fix_location.WriteChangelogAndRandomBinaryData("The App", "1.1.0", changelog);
            Tuple<string, string> names_111 = fix_location.WriteRandomChangelogAndRandomBinaryData("The App", "1.1.1");


        }
    }
}
