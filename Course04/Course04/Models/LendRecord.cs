using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Course04.Models
{
    public class LendRecord
    {

        [DisplayName("借閱日期")]
        public string LendDate { get; set; }

        [DisplayName("借閱人代號")]
        public string KeeperID { get; set; }

        [DisplayName("英文姓名")]
        public string KeeperEname { get; set; }

        [DisplayName("中文姓名")]
        public string KeeperCname { get; set; }

    }
}