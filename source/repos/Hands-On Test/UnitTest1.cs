using Hands_On;

namespace Hands_On_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Wages1()
        {
            WorkTime workTime = new WorkTime();
            workTime.OverTime(9, 17, 30, 1.5);
            double actual = workTime.GetWages();
            if (actual == 240)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }

        }

        [TestMethod]
        public void Test_Wages2()
        {
            WorkTime workTime = new WorkTime();
            workTime.OverTime(16, 18, 30, 1.8);
            double actual = workTime.GetWages();
            if (actual == 84)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestMethod]
        public void Test_Wages3()
        {
            WorkTime workTime = new WorkTime();
            workTime.OverTime(13.25, 15, 30, 1.5);
            double actual = workTime.GetWages();
            if (actual == 52.5)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail();
            }

        }
        /* [TestMethod]
         public void Test_DefaultPhotoBook()
         {
             PhotoBook pb = new PhotoBook();
             int page = pb.GetNumberPages();
             Assert.AreEqual(page,16);
         }

         [TestMethod]
         public void Test_PhotoBook()
         {
             PhotoBook pb = new PhotoBook(32);
             int page = pb.GetNumberPages();
             Assert.AreEqual(page, 32);
         }

         [TestMethod]
         public void Test_LargePhotoBook()
         {
             PhotoBook pb = new PhotoBook(156);
             int page = pb.GetNumberPages();
             if(page == 160)
             {
                 Assert.IsTrue(true);
             }
             else
             {
                 Assert.Fail();
             }
         }

         [TestMethod]
         public void Test_AlbumBook()
         {
             AddPhotoBook addPhotoBook = new AddPhotoBook();
             int page = addPhotoBook.GetNumberPages();
             Assert.AreEqual(page, 64);
         }*/
    }
}