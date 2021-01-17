using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace PetitTournant.Lib.Test
{
    [TestClass]
    public class FacadeCookBookFromFolder
    {
        private static TestContext context;
        [ClassInitialize]
        public static void SetupTests(TestContext testContext) { context = testContext; }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void GarbageLink()
        {
            PetitTournant.Lib.PetitTournantFacade lib = new PetitTournant.Lib.PetitTournantFacade();

            lib.LoadCookBookFromFolder(@"#+213t5thisLinkIsGarbage");
        }
        [TestMethod]
        public void DocBookLink()
        {
            PetitTournant.Lib.PetitTournantFacade lib = new PetitTournant.Lib.PetitTournantFacade();

            string path = Path.GetFullPath(Path.Combine(context.TestRunDirectory, @"..\..\..\doc\ExampleCookBook\BasicExampleBook"));
            lib.LoadCookBookFromFolder(path);
        }
    }
}
