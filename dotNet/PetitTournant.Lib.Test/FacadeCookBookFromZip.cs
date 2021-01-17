using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PetitTournant.Lib.Test
{
    [TestClass]
    public class FacadeCookBookFromZip
    {
        private static TestContext context;
        [ClassInitialize]
        public static void SetupTests(TestContext testContext) { context = testContext; }

        [TestMethod]
        public void DocBookLink()
        {
            PetitTournant.Lib.PetitTournantFacade lib = new PetitTournant.Lib.PetitTournantFacade();

            string path = Path.GetFullPath(Path.Combine(context.TestRunDirectory, @"..\..\..\doc\ExampleCookBook\BasicExampleBook"));
            string archivePath = Path.GetTempFileName();
            ZipFile.CreateFromDirectory(path, archivePath);
            FileStream archive = File.Open(archivePath, FileMode.Open);
            lib.LoadCookBookFromFileStream(archive);
        }
    }
}
