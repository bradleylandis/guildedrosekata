using System;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class ApprovalTest
    {
        [Test]
        public void ThirtyDays()
        {
            var lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ThirtyDays.txt"));

            var fakeOutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeOutput));
            Console.SetIn(new StringReader(""));

            Program.Main(new string[] { });
            var output = fakeOutput.ToString();

            var outputLines = output.Split(new []{Environment.NewLine}, StringSplitOptions.None);
            for(var i = 0; i<Math.Min(lines.Length, outputLines.Length); i++) 
            {
                Assert.AreEqual(lines[i], outputLines[i]);
            }
        }
    }
}
