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

        [DisplayName("書名")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookName { get; set; }

        [DisplayName("作者")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookAuthor { get; set; }

        [DisplayName("出版商")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookPublisher { get; set; }

        [DisplayName("內容簡介")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookBriefIntroduction { get; set; }

        [DisplayName("購書日期")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BuyDate { get; set; }

        [DisplayName("圖書類別")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookClass { get; set; }


    }
}