using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Course04.Models
{
    public class BookSearchArg
    {

        [DisplayName("圖書類別")]
        public string BookClass { get; set; }

        [DisplayName("書名")]
        public string BookName { get; set; }

        [DisplayName("購書日期")]
        public string BuyDate { get; set; }

        [DisplayName("借閱狀態")]
        public string BookStatus { get; set; }

        [DisplayName("借閱人")]
        public string KeeperEname { get; set; }
    }
}