USE GSSWEB
GO

-- 所有dbo. 都可以去掉
SELECT Mem.[USER_ID] AS KeeperId, 
	Mem.[USER_CNAME] AS Cname, 
	Mem.[USER_ENAME] AS Ename, 
	YEAR(Lend.[LEND_DATE]) AS BorrowYear, 
	COUNT(1) AS BorrowCnt
FROM BOOK_LEND_RECORD AS Lend 
INNER JOIN dbo.MEMBER_M AS Mem
	ON Mem.[USER_ID] = Lend.[KEEPER_ID]
GROUP BY Mem.[USER_ID], YEAR(Lend.[LEND_DATE]), Mem.[USER_CNAME], Mem.[USER_ENAME]
ORDER BY Mem.[USER_ID], BorrowYear;