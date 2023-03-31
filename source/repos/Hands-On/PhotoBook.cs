using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hands_On
{
    /*Create a C# program to manage a photo book using OOPs.To start, 
      create a class called PhotoBook.It must also have a public method 
      GetNumberPages that will return the number of photo book pages.
    The default constructor will create an album with 16 pages.
    There will be an additional constructor, with which we can specify 
    the number of pages we want in the album.
    There is also a AddPhotoBook class whose constructor 
    will create an album with 64 pages.
    Finally create a PhotoBookTest class to perform the following actions:
    Create a default photo book and show the number of pages
    Create a photo book with 32 pages and show the number of pages
    Create a large photo book and show the number of pages*/
    public class PhotoBook
    {
        int pageNo = 0;
        public int GetNumberPages()
        {
            Console.WriteLine("PageNo "+pageNo);
            return pageNo;
        }

        public PhotoBook() {
            pageNo = 16;
        }

        public PhotoBook(int page)
        {
            this.pageNo = page;
        }
    }

    public class AddPhotoBook : PhotoBook
    {
    
        public AddPhotoBook() : base(64)
        {
            
        }

    }
}
