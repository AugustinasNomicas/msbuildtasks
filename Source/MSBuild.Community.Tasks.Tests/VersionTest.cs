// $Id$

using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace MSBuild.Community.Tasks.Tests
{
    /// <summary>
    /// Summary description for VersionTest
    /// </summary>
    [TestFixture]
    public class VersionTest
    {
        public VersionTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

		[Test]
		public void VersionExecute()
		{
			Version task = new Version();
			task.BuildEngine = new MockBuild();
			task.VersionFile = "number.txt";
			Assert.IsTrue(task.Execute(), "Execute Failed");

			Assert.AreEqual(1, task.Major);
			Assert.AreEqual(0, task.Minor);
			Assert.AreEqual(0, task.Build);
			Assert.AreEqual(0, task.Revision);

			task = new Version();
			task.BuildEngine = new MockBuild();
			task.VersionFile = @"version.txt";
			task.BuildType = "Increment";
			task.RevisionType = "Increment";
			Assert.IsTrue(task.Execute(), "Execute Failed");

			Assert.AreEqual(1, task.Major);
			Assert.AreEqual(0, task.Minor);


			task = new Version();
			task.BuildEngine = new MockBuild();
			task.VersionFile = @"version.txt";
			task.BuildType = "Automatic";
			task.RevisionType = "Automatic";
			Assert.IsTrue(task.Execute(), "Execute Failed");

			Assert.AreEqual(1, task.Major);
			Assert.AreEqual(0, task.Minor);

			task = new Version();
			task.BuildEngine = new MockBuild();
			task.VersionFile = @"version.txt";
			task.BuildType = "Date";
			task.RevisionType = "Increment";
			Assert.IsTrue(task.Execute(), "Execute Failed");

			Assert.AreEqual(1, task.Major);
			Assert.AreEqual(0, task.Minor);

			DateTime dDate = DateTime.Now;
			int _month = dDate.Month * 100;
			int _day = dDate.Day;
			int _year = (dDate.Year % 2000) * 10000;
			int buildDate = _year + _month + _day;

			Assert.AreEqual(buildDate, task.Build);
		}
    }
}