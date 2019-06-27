USE GSSWEB
GO

SELECT Lend.BOOK_ID AS '�ѥ�ID',
		FORMAT(Book.BOOK_BOUGHT_DATE, 'yyyy/MM/dd') AS '�ʶR���',
		FORMAT(Lend.LEND_DATE, 'yyyy/MM/dd') AS '�ɾ\���', 
		Class.BOOK_CLASS_ID + '-' + Class.BOOK_CLASS_NAME AS '���y���O',
		Mem.[USER_ID] + '-' + Mem.USER_CNAME + '(' + Mem.USER_ENAME + ')' AS '�ɾ\�H',
		Status.CODE_ID + '-' + Status.CODE_NAME AS '���A', -- ����[���A��
		FORMAT(Book.BOOK_AMOUNT, '##,###' ) + '��' AS '�ʶR���B' -- �Τ@���� convert format
FROM dbo.BOOK_LEND_RECORD AS Lend(NOLOCK) -- NOLOCK ���Q�צ�
INNER JOIN dbo.MEMBER_M AS Mem
	ON Mem.[USER_ID] = Lend.[KEEPER_ID]
INNER JOIN dbo.BOOK_DATA AS Book
	ON Lend.BOOK_ID = Book.BOOK_ID
INNER JOIN dbo.BOOK_CLASS AS Class
	ON Book.BOOK_CLASS_ID = Class.BOOK_CLASS_ID
INNER JOIN dbo.BOOK_CODE AS Status
	ON Status.CODE_ID = Book.BOOK_STATUS
	AND Status.CODE_TYPE_DESC = '���y���A'
WHERE Mem.[USER_CNAME] = '���|' 
ORDER BY �ѥ�ID DESC;