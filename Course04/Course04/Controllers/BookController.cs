using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Course04.Controllers
{
    public class BookController : Controller
    {

        Models.CodeService codeService = new Models.CodeService();

        // 查詢書籍
        [HttpGet()]
        public ActionResult QueryBook()
        {
            return View();
        }

        // 查詢書籍
        [HttpPost()]
        public ActionResult QueryBook(Models.BookSearchArg arg)
        {
            ViewBag.BookStatusCodeTable = codeService.GetStatusCodeTable();
            ViewBag.BookClassCodeTable = codeService.GetBookClassCodeTable();
            ViewBag.MemberCodeTable = codeService.GetMemberCodeTable();
            return View();
        }

        // 新增書籍
        [HttpGet()]
        public ActionResult AddBook()
        {
            return View(new Models.Book());
        }

        // 新增書籍
        [HttpPost()]
        public ActionResult AddBook(Models.Book book)
        {
            return View(book);
        }
    }
}