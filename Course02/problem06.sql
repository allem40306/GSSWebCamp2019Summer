USE GSSWEB
GO
-- 所有dbo. 都可以去掉

SELECT pt.ClassID, 
		pt.ClassName,
		ISNULL(pt.[2016], 0) AS Cnt2016,
		ISNULL(pt.[2017], 0) AS Cnt2017,
		ISNULL(pt.[2018], 0) AS Cnt2018,
		ISNULL(pt.[2019], 0) AS Cnt2019
FROM (
	SELECT Class.BOOK_CLASS_ID AS ClassID, 
			Class.BOOK_CLASS_NAME AS ClassName, 
			FORMAT(Lend.LEND_DATE,'yyyy') AS [year], 
			COUNT(FORMAT(Lend.LEND_DATE,'yyyy')) AS Cnt
	FROM dbo.BOOK_LEND_RECORD AS Lend INNER JOIN dbo.BOOK_DATA AS Book
		ON Lend.BOOK_ID = Book.BOOK_ID
	INNER JOIN dbo.BOOK_CLASS AS Class
		ON Book.BOOK_CLASS_ID = Class.BOOK_CLASS_ID
	GROUP BY Class.BOOK_CLASS_ID, Class.BOOK_CLASS_NAME, FORMAT(Lend.LEND_DATE,'yyyy')
) AS SubTable
PIVOT
(
	SUM(Cnt) for [year] IN ([2016], [2017], [2018], [2019])
) AS pt
ORDER BY pt.ClassID;
