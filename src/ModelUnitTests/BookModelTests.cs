using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using NUnit.Framework;

namespace ModelUnitTests
{
    [TestFixture]
    public class BookModelTests
    {
        public BookViewModel bookModel { get; set; }

        [SetUp]
        public void Setup()
        {
            bookModel = new BookViewModel();
        }

        [TestCaseSource("Data_ListAllRecords")]
        [Test]
        public void Test_ListAllRecords(List<BookViewModel> books, int expectedBookCount)
        {
            bookModel.Stuff(books);
            Assert.AreEqual(expectedBookCount, bookModel.List().Count());
        }

        [TestCaseSource("Data_ListAllRecords")]
        [Test]
        public void Test_ListOneRecord(List<BookViewModel> books, int expectedBookCount)
        {
            bookModel.Stuff(books);
            Assert.AreEqual(expectedBookCount, bookModel.List().Count());
            Assert.AreEqual(books.Find(b => b.Id == 2), bookModel.Books.FirstOrDefault(b => b.Id == 2));
        }

        public IEnumerable<TestCaseData> Data_ListAllRecords()
        {
            yield return new TestCaseData(new List<BookDataModel>()
            {
                new BookViewModel() { Id = 1, Edition = "1st", ISBN = "123456", Title = "The Greatest Book Ever!"},
                new BookViewModel() { Id = 2, Edition = "2nd", ISBN = "789012", Title = "Another NY Times Best Seller"},
                new BookViewModel() { Id = 3, Edition = "3rd", ISBN = "345678", Title = "A murder romance book"}
            }, 3);
        }

    }
}
