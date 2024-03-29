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

        [DisplayName("流水號")]
        public string BookID { get; set; }

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
        public string BookNote { get; set; }

        [DisplayName("購書日期")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BuyDate { get; set; }

        [DisplayName("圖書類別")]
        public string BookClass { get; set; }

        [DisplayName("圖書類別代號")]
        [Required(ErrorMessage = "此欄位必填")]
        public string BookClassID { get; set; }

        [DisplayName("借閱狀態")]
        public string BookStatus { get; set; }

        [DisplayName("借閱狀態代號")]
        public string BookStatusID { get; set; }

        [DisplayName("借閱人")]
        public string Keeper { get; set; }

        [DisplayName("借閱人代號")]
        public string KeeperID { get; set; }


    }
}