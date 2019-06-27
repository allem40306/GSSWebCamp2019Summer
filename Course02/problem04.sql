USE GSSWEB
GO
-- 所有dbo. 都可以去掉

SELECT SubTable.Seq AS Seq, 
	SubTable.class AS BookClass, 
	SubTable.BookId AS BookId, 
	SubTable.BookName AS BookName, 
	SubTable.Cnt AS Cnt
FROM (
	SELECT DENSE_RANK() OVER(PARTITION BY Class.BOOK_CLASS_NAME ORDER BY COUNT(Book.BOOK_CLASS_ID) DESC) Seq, 
		Class.BOOK_CLASS_NAME AS class, 
		Lend.BOOK_ID AS BookId, 
		Book.BOOK_NAME AS BookName, 
		COUNT(Book.BOOK_CLASS_ID) AS Cnt
	FROM BOOK_LEND_RECORD AS Lend 
	INNER JOIN BOOK_DATA AS Book
		ON Lend.BOOK_ID = Book.BOOK_ID
	INNER JOIN BOOK_CLASS AS Class
		ON Book.BOOK_CLASS_ID = Class.BOOK_CLASS_ID
	GROUP BY Class.BOOK_CLASS_NAME, Lend.BOOK_ID, Book.BOOK_NAME
) AS SubTable
WHERE SubTable.Seq <= 3 -- 用<=比較直觀
ORDER BY SubTable.class;