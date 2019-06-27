USE GSSWEB
GO
-- 所有dbo. 都可以去掉

SELECT subtable.ClassId AS classId, 
		subtable.ClassName AS className,
		SUM(CASE subtable.[year] WHEN 2016 THEN subtable.Cnt ELSE 0 END) AS Cnt2016,
		SUM(CASE subtable.[year] WHEN 2017 THEN subtable.Cnt ELSE 0 END) AS Cnt2017,
		SUM(CASE subtable.[year] WHEN 2018 THEN subtable.Cnt ELSE 0 END) AS Cnt2018,
		SUM(CASE subtable.[year] WHEN 2019 THEN subtable.Cnt ELSE 0 END) AS Cnt2019
FROM (
	SELECT Class.BOOK_CLASS_ID AS ClassId, 
			Class.BOOK_CLASS_NAME AS ClassName,
			FORMAT(Lend.LEND_DATE,'yyyy') AS [year],-- format from 2012, can delete year 
			COUNT(FORMAT(Lend.LEND_DATE,'yyyy')) AS Cnt
	FROM BOOK_LEND_RECORD AS Lend 
	INNER JOIN BOOK_DATA AS Book
		ON Lend.BOOK_ID = Book.BOOK_ID
	INNER JOIN BOOK_CLASS AS Class
		ON Book.BOOK_CLASS_ID = Class.BOOK_CLASS_ID
	GROUP BY Class.BOOK_CLASS_ID, Class.BOOK_CLASS_NAME, FORMAT(Lend.LEND_DATE,'yyyy')
) AS subtable
GROUP BY subtable.ClassId, subtable.ClassName
ORDER BY subtable.ClassId;

