USE GSSWEB
GO

SELECT Lend.BOOK_ID AS '書本ID',
		FORMAT(Book.BOOK_BOUGHT_DATE, 'yyyy/MM/dd') AS '購買日期',
		FORMAT(Lend.LEND_DATE, 'yyyy/MM/dd') AS '借閱日期', 
		Class.BOOK_CLASS_ID + '-' + Class.BOOK_CLASS_NAME AS '書籍類別',
		Mem.[USER_ID] + '-' + Mem.USER_CNAME + '(' + Mem.USER_ENAME + ')' AS '借閱人',
		Status.CODE_ID + '-' + Status.CODE_NAME AS '狀態', -- 中文加中括號
		FORMAT(Book.BOOK_AMOUNT, '##,###' ) + '元' AS '購買金額' -- 統一風格 convert format
FROM dbo.BOOK_LEND_RECORD AS Lend(NOLOCK) -- NOLOCK 不被擋住
INNER JOIN dbo.MEMBER_M AS Mem
	ON Mem.[USER_ID] = Lend.[KEEPER_ID]
INNER JOIN dbo.BOOK_DATA AS Book
	ON Lend.BOOK_ID = Book.BOOK_ID
INNER JOIN dbo.BOOK_CLASS AS Class
	ON Book.BOOK_CLASS_ID = Class.BOOK_CLASS_ID
INNER JOIN dbo.BOOK_CODE AS Status
	ON Status.CODE_ID = Book.BOOK_STATUS
	AND Status.CODE_TYPE_DESC = '書籍狀態'
WHERE Mem.[USER_CNAME] = '李四' 
ORDER BY 書本ID DESC;