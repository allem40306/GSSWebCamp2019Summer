﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Course04.Models
{
    public class CodeService
    {
        // 取得與DB連線字串
        private string GetDBConnectionString()
        {
            return
                System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
        }

        public List<SelectListItem> GetStatusCodeTable()
        {
            return this.GetCodeTable(@"SELECT CODE_ID AS CodeId, CODE_NAME AS CodeName FROM BOOK_CODE WHERE CODE_TYPE = 'BOOK_STATUS';", true);
        }

        public List<SelectListItem> GetBookClassCodeTable()
        {
            return this.GetCodeTable(@"SELECT BOOK_CLASS_ID AS CodeId, BOOK_CLASS_NAME AS CodeName FROM BOOK_CLASS;", false);
        }

        public List<SelectListItem> GetMemberCodeTable()
        {
            return this.GetCodeTable(@"SELECT [USER_ID] AS CodeId, USER_ENAME AS CodeName FROM MEMBER_M;", true);
        }

        public List<SelectListItem> GetCodeTable(string sql, bool allowEmpty)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);

                sqlAdapter.Fill(dt);
                conn.Close();
            }

            return this.MapCodeData(dt, allowEmpty);
        }

        private List<SelectListItem> MapCodeData(DataTable dt, bool allowEmpty)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (DataRow row in dt.Rows)
            {

                result.Add(new SelectListItem()
                {
                    Text = row["CodeName"].ToString(),
                    Value = row["CodeId"].ToString()
                });
            }
            return result;
        }
    }
}