﻿using System;
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
            ViewBag.BookStatusCodeTable = codeService.GetStatusCodeTable();
            ViewBag.BookClassCodeTable = codeService.GetBookClassCodeTable();
            ViewBag.MemberCodeTable = codeService.GetMemberCodeTable();
            return View();
        }

        // 查詢書籍
        [HttpPost()]
        public ActionResult QueryBook(Models.BookSearchArg arg)
        {
            Models.BookService bookService = new Models.BookService();
            ViewBag.BookStatusCodeTable = codeService.GetStatusCodeTable();
            ViewBag.BookClassCodeTable = codeService.GetBookClassCodeTable();
            ViewBag.MemberCodeTable = codeService.GetMemberCodeTable();
            ViewBag.SearchResult =  bookService.GetBookByCondtioin(arg);
            return View();
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
                TempData["message"] = "存檔成功";
            }
            return View(book);
        }
    }
}