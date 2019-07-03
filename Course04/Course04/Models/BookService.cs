using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Course04.Models
{
    public class BookService
    {
        // 取得與DB連線字串
        private string GetDBConnectionString()
        {
            return
                System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
        }

        public List<Models.Book> GetBookByCondtioin(Models.BookSearchArg arg)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT 
		                        Book.BOOK_ID AS '流水號',
								Book.BOOK_NAME AS '書名',
								Book.BOOK_AUTHOR AS '作者',
								Book.BOOK_PUBLISHER AS '出版商',
								Book.BOOK_NOTE AS '內容簡介',
		                        FORMAT(Book.BOOK_BOUGHT_DATE, 'yyyy/MM/dd') AS '購買日期',
		                        BookClass.BOOK_CLASS_NAME AS '書籍類別',
		                        BookClass.BOOK_CLASS_ID AS '書籍類別代號',
		                        BookStatus.CODE_NAME AS '借閱狀態',
		                        BookStatus.CODE_ID AS '借閱狀態代號',
		                        ISNULL(Mem.USER_ENAME, '') AS '借閱人',
		                        ISNULL(Mem.[USER_ID], '') AS '借閱人代號'
                        FROM BOOK_DATA AS Book
                        INNER JOIN BOOK_CLASS AS BookClass
	                        ON Book.BOOK_CLASS_ID = BookClass.BOOK_CLASS_ID
                        INNER JOIN BOOK_CODE AS BookStatus
	                        ON Book.BOOK_STATUS = BookStatus.CODE_ID
	                        AND BookStatus.CODE_TYPE = 'BOOK_STATUS'
                        LEFT JOIN MEMBER_M AS Mem
	                        ON Book.BOOK_KEEPER = Mem.[USER_ID]
                        WHERE 
	                        BookClass.BOOK_CLASS_ID = @BookClassID
	                        AND Book.BOOK_NAME LIKE '%' +  @BookName + '%' 
	                        AND (ISNULL(@KeeperID, '') = '' OR Mem.[USER_ID] = @KeeperID)
	                        AND (ISNULL(@StatusCodeID, '') = '' OR BookStatus.CODE_ID = @StatusCodeID)
                        ORDER BY [購買日期] DESC;";
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add("@BookClassID", arg.BookClassID == null ? string.Empty : arg.BookClassID);
                cmd.Parameters.Add("@BookName", arg.BookName == null ? string.Empty : arg.BookName);
                cmd.Parameters.Add("@KeeperID", arg.KeeperID == null ? string.Empty : arg.KeeperID);
                cmd.Parameters.Add("@StatusCodeID", arg.StatusCodeID == null ? string.Empty : arg.StatusCodeID);
                SqlDataAdapter sqladapter = new SqlDataAdapter(cmd);
                sqladapter.Fill(dt);
                conn.Close();
            }
            return this.MapEmployeeDataToList(dt);
        }

        private List<Book> MapEmployeeDataToList(DataTable dt)
        {
            List<Models.Book> result = new List<Models.Book>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new Book()
                {
                    BookID = row["流水號"].ToString(),
                    BookName = row["書名"].ToString(),
                    BookAuthor = row["作者"].ToString(),
                    BookPublisher = row["出版商"].ToString(),
                    BookNote = row["內容簡介"].ToString(),
                    BuyDate = row["購買日期"].ToString(),
                    BookClass = row["書籍類別"].ToString(),
                    BookStatus = row["借閱狀態"].ToString(),
                    Keeper = row["借閱人"].ToString()
                });
            }
            return result;
        }

        public int AddBook(Models.Book book)
        {
            string sql = @"INSERT INTO BOOK_DATA
	                    (
		                    BOOK_NAME, BOOK_AUTHOR, BOOK_PUBLISHER,
		                    BOOK_NOTE, BOOK_BOUGHT_DATE, BOOK_CLASS_ID,
                            BOOK_STATUS
	                    )
	                    VALUES
	                    (
		                    @BOOK_NAME, @BOOK_AUTHOR, @BOOK_PUBLISHER,
		                    @BOOK_NOTE, @BOOK_BOUGHT_DATE, @BOOK_CLASS_ID,
                            'A'
	                    )
	                    SELECT SCOPE_IDENTITY();";
            int EmployeeId;
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@BOOK_NAME", book.BookName));
                cmd.Parameters.Add(new SqlParameter("@BOOK_AUTHOR", book.BookAuthor));
                cmd.Parameters.Add(new SqlParameter("@BOOK_PUBLISHER", book.BookPublisher));
                cmd.Parameters.Add(new SqlParameter("@BOOK_NOTE", book.BookNote));
                cmd.Parameters.Add(new SqlParameter("@BOOK_BOUGHT_DATE", book.BuyDate));
                cmd.Parameters.Add(new SqlParameter("@BOOK_CLASS_ID", book.BookClassID));
                EmployeeId = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }
            return EmployeeId;
        }
    }
}