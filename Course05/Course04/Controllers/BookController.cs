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
            return View(new Models.Book());
        }

        // 新增書籍
        [HttpPost()]
        public JsonResult AddBook(Models.Book book)
        {
            Models.BookService bookService = new Models.BookService();
            TempData["message"] = "存檔成功"; // for frontend
            return this.Json(bookService.AddBook(book));
        }

        // 修改書籍
        [HttpGet()]
        public ActionResult EditBook()
        {
            return View();
        }

        //// 修改書籍
        //[HttpPost()]
        //public JsonResult EditBook(string BookID)
        //{
        //    Models.BookService bookService = new Models.BookService();
        //    return this.Json(bookService.GetBookByID(BookID));
        //}

        // 修改書籍
        [HttpPost()]
        public JsonResult EditBook(Models.Book book)
        {
            Models.BookService bookService = new Models.BookService();
            return this.Json(bookService.EditBook(book));
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
        public ActionResult PresentBook()
        {
            return View();
        }

        // 明細資料
        [HttpPost()]
        public JsonResult PresentBook(string BookID)
        {
            Models.BookService bookService = new Models.BookService();
            return this.Json(bookService.GetBookByID(BookID));
        }

        // 借閱紀錄
        [HttpGet()]
        public ActionResult QueryLendRecord()
        {
            return View();
        }

        // 借閱紀錄
        [HttpPost()]
        public JsonResult QueryLendRecord(string BookID)
        {
            Models.BookService bookService = new Models.BookService();
            return this.Json(bookService.GetLendRecord(BookID));
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