RESTORE FILELISTONLY
FROM DISK = 'D:\OneDrive\WOU 2017 - 2018\Fall Term\cs460\docs\Homework6\AdventureWorks2014.bak'
GO

RESTORE DATABASE AdventureWorks  
FROM DISK = 'D:\OneDrive\WOU 2017 - 2018\Fall Term\cs460\docs\Homework6\AdventureWorks2014.bak'  
WITH MOVE 'AdventureWorks2014_Data' TO 'D:\OneDrive\WOU 2017 - 2018\Fall Term\cs460\docs\Homework6\AdventureWorks2014.mdf',  
MOVE 'AdventureWorks2014_Log' TO 'D:\OneDrive\WOU 2017 - 2018\Fall Term\cs460\docs\Homework6\AdventureWorks2014.ldf'