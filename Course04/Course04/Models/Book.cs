﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Course04.Models
{
    public class Book
    {

        //[Required(ErrorMessage = "此欄位必填")]

        [DisplayName("書名")]
        public string BookName { get; set; }

        [DisplayName("作者")]
        public string BookAuthor { get; set; }

        [DisplayName("出版商")]
        public string BookPublisher { get; set; }

        [DisplayName("內容簡介")]
        public string BookNote { get; set; }

        [DisplayName("購書日期")]
        public string BuyDate { get; set; }

        [DisplayName("圖書類別")]
        public string BookClass { get; set; }

        [DisplayName("借閱狀態")]
        public string BookStatus { get; set; }

        [DisplayName("借閱人")]
        public string Keeper { get; set; }


    }
}