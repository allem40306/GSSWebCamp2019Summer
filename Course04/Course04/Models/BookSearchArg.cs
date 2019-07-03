using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Course04.Models
{
    public class BookSearchArg
    {

        [DisplayName("書名")]
        public string BookName { get; set; }
        
        [DisplayName("圖書類別")]
        public string BookClassID { get; set; }

        [DisplayName("借閱人")]
        public string KeeperID { get; set; }

        [DisplayName("借閱狀態")]
        public string StatusCodeID { get; set; }

    }
}