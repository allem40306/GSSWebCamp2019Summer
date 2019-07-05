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
        public JsonResult QueryBook(Models.BookSearchArg arg)
        {
            Models.BookService bookService = new Models.BookService();
            return this.Json(bookService.GetBookByCondtioin(arg));
        }

        // 新增書籍
        [HttpGet()]
        public ActionResult AddBook()
        {
            ViewBag.BookStatusCodeTable = codeService.GetStatusCodeTable();
            ViewBag.BookClassCodeTable = codeService.GetBookClassCodeTable();
            ViewBag.MemberCodeTable = codeService.GetMemberCodeTable();
            return View(new Models.Book());
        }

        // 新增書籍
        [HttpPost()]
        public ActionResult AddBook(Models.Book book)
        {
            ViewBag.BookStatusCodeTable = codeService.GetStatusCodeTable();
            ViewBag.BookClassCodeTable = codeService.GetBookClassCodeTable();
            ViewBag.MemberCodeTable = codeService.GetMemberCodeTable();
            if (ModelState.IsValid)
            {
                Models.BookService bookService = new Models.BookService();
                bookService.AddBook(book);
                TempData["message"] = "存檔成功"; // for frontend
            }
            return View(book);
        }

        // 修改書籍
        [HttpGet()]
        public ActionResult EditBook(string BookID)
        {
            Models.BookService bookService = new Models.BookService();
            ViewBag.BookStatusCodeTable = codeService.GetStatusCodeTable();
            ViewBag.BookClassCodeTable = codeService.GetBookClassCodeTable();
            ViewBag.MemberCodeTable = codeService.GetMemberCodeTable();
            ViewBag.SearchResult = bookService.GetBookByID(BookID);
            return View(new Models.Book());
        }

        // 修改書籍
        [HttpPost()]
        public ActionResult EditBook(Models.Book book)
        {
            ViewBag.BookStatusCodeTable = codeService.GetStatusCodeTable();
            ViewBag.BookClassCodeTable = codeService.GetBookClassCodeTable();
            ViewBag.MemberCodeTable = codeService.GetMemberCodeTable();
            if (ModelState.IsValid)
            {
                Models.BookService bookService = new Models.BookService();
                string BookID = bookService.EditBook(book).ToString();
                ViewBag.SearchResult = bookService.GetBookByID(BookID);
                TempData["message"] = "存檔成功";
            }
            return View(book);
        }

        /// 刪除書籍
        [HttpPost()]
        public JsonResult DeleteBook(string bookID)
        {
            try
            {
                Models.BookService bookService = new Models.BookService();
                if (bookService.DeleteBook(bookID))
                {
                    return this.Json(true);
                }
                return this.Json(false);
            }
            catch (Exception ex)
            {
                return this.Json(null);
            }
        }

        // 明細資料
        [HttpGet()]
        public ActionResult PresentBook(string BookID)
        {
            Models.BookService bookService = new Models.BookService();
            ViewBag.SearchResult = bookService.GetBookByID(BookID);
            return View();
        }

        // 借閱紀錄
        [HttpGet()]
        public ActionResult QueryLendRecord(string BookID)
        {
            Models.BookService bookService = new Models.BookService();
            ViewBag.SearchResult = bookService.GetLendRecord(BookID);
            return View();
        }

        [HttpPost]
        public JsonResult GetBookClassCodeTable()
        {
            return Json(this.codeService.GetBookClassCodeTable());
        }

        [HttpPost]
        public JsonResult GetMemberCodeTable()
        {
            return Json(this.codeService.GetMemberCodeTable());
        }

        [HttpPost]
        public JsonResult GetStatusCodeTable()
        {
            return Json(this.codeService.GetStatusCodeTable());
        }

    }
}