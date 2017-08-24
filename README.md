# TestingConf Utilities
<div class="wikidoc">
<p><strong>Project Description</strong><br /> <br /> This Framework&nbsp;is very&nbsp;helpful for testing and configuration purpose, it has some methods that will be used as utilities that developers may need in unit testing, integration testing, configuration and automation or anything else that not related to the business logic of any project but related to the development and testing purpose, so of course it can be reused in other projects.</p>
<p><strong><span style="white-space: normal; text-transform: none; word-spacing: 0px; float: none; color: #253340; font: 13px/19px 'Segoe UI',Tahoma,Arial,Helvetica,sans-serif; orphans: 2; widows: 2; display: inline!important; letter-spacing: normal; text-indent: 0px;">Authors : &nbsp;</span><em style="font-size: 13px; font-family: 'Segoe UI',Tahoma,Arial,Helvetica,sans-serif; font-variant: normal; vertical-align: baseline; white-space: normal; text-transform: none; word-spacing: 0px; font-weight: normal; color: #253340; outline-width: 0px; outline-style: none; margin: 0px; orphans: 2; widows: 2; letter-spacing: normal; outline-color: invert; line-height: 19px; background-color: transparent; text-indent: 0px; border: 0px; padding: 0px;"><a style="font-size: 13px; vertical-align: baseline; color: #ce8b10; outline-width: 0px; outline-style: none; text-decoration: none; margin: 0px; outline-color: invert; background-color: transparent; border: 0px; padding: 0px;" title="M.Radwan Blog" href="http://mohamedradwan.com/" target="_blank" rel="noopener">Mohamed Radwan</a></em></strong></p>
<p><strong><span style="font-size: 15pt; color: #3f529c;">Examples:</span></strong></p>
<p><span style="font-size: 15pt; color: #3f529c;">DeleteTableDataAndRessedId</span><span style="font-size: 15pt; color: #3f529c;">&nbsp;</span><strong><span style="font-size: 15pt; color: #3f529c;">Method</span></strong></p>
<p><span style="font-size: 10pt; color: black;">This method will delete all data in a given table in the given database and also reseed the Ids for that table, you can use this method to restate a table before inserting test data in the table to return the table to the original state.&nbsp;</span></p>
<p><strong><span style="font-size: 11.5pt; color: #3f529c;">Syntax</span></strong></p>
<p><span style="font-size: 10pt; color: black;">C#</span></p>
<p><span style="font-size: 9.5pt; color: blue;">void</span><span style="font-size: 9.5pt; color: black;"> DeleteTableDataAndRessedId(<br /> </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color: #0000ff;">string</span><span style="font-size: 9.5pt; color: black;"> tableName,&nbsp;<br /> </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color: #0000ff;">string</span><span style="font-size: 9.5pt; color: black;"> connectionString<br /> </span>)</p>
<p><span style="font-size: 10pt; color: black;">&nbsp;</span><span style="font-size: 10pt; color: #3f529c;">Parameters</span></p>
<p><em><span style="font-size: 9.5pt; color: black;">tableName</span></em></p>
<p><span style="font-size: 10pt; color: black;">Type:&nbsp;</span><a href="http://msdn.microsoft.com/en-us/library/system.string.aspx">System.String</a></p>
<p><span style="font-size: 10pt; color: black;">The table name that will delete its data and reseed its Ids.</span></p>
<p><em><span style="font-size: 9.5pt; color: black;">&nbsp;</span></em><em><span style="font-size: 9.5pt; color: black;"><br /> connectionString</span></em></p>
<p><span style="font-size: 10pt; color: black;">Type:&nbsp;</span><a href="http://msdn.microsoft.com/en-us/library/system.string.aspx">System.String</a></p>
<p><span style="font-size: 10pt; color: black;">The connection string of the database that has the desired table.</span></p>
<p><span style="font-size: 10pt; color: black;">&nbsp;<hr/></span></p>
<p><span style="font-size: 15pt; color: #3f529c;">DeleteDataBaseDataAndReseedAllIds&nbsp;</span><strong><span style="font-size: 15pt; color: #3f529c;">Method</span></strong></p>
<p><span style="font-size: 10pt; color: black;">This method will delete all data in all tables in a given database and also reseed the Ids for all tables, you can use this method to restate a database tables to return the tables to the original state.&nbsp;</span></p>
<p><strong><span style="font-size: 11.5pt; color: #3f529c;">Syntax</span></strong></p>
<p><span style="font-size: 10pt; color: black;">C#</span></p>
<p><span style="font-size: 9.5pt; color: blue;">void</span><span style="font-size: 9.5pt; color: black;"> DeleteDataBaseDataAndReseedAllIds(<br /> </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="color: #0000ff;">string </span><span style="font-size: 9.5pt; color: black;">connectionString<br /> </span>)</p>
<p><span style="font-size: 10pt; color: black;">&nbsp;</span><span style="font-size: 10pt; color: #3f529c;">Parameters</span></p>
<p><em><span style="font-size: 9.5pt; color: black;">connectionString</span></em></p>
<p><span style="font-size: 10pt; color: black;">Type:&nbsp;</span><a href="http://msdn.microsoft.com/en-us/library/system.string.aspx">System.String</a></p>
<p><span style="font-size: 10pt; color: black;">The connection string of the database that has the desired table.</span></p>
<p><span style="font-size: 10pt; color: black;">&nbsp;&nbsp;<hr/></span></p>
<p><span style="font-size: 15pt; color: #3f529c;">GetValueFromDB</span><span style="font-size: 15pt; color: #3f529c;">&nbsp;</span><strong><span style="font-size: 15pt; color: #3f529c;">Method</span></strong></p>
<p><span style="font-size: 10pt; color: black;">This method will return a scalar value from any table with a where condition, we can use this method to check for specific value in the DB so this method will be very helpful in the testing scenario when we want to make sure that our CRUD was successed</span><strong><span style="font-size: 11.5pt; color: #3f529c;">&nbsp;</span></strong></p>
<p><strong><span style="font-size: 11.5pt; color: #3f529c;">Syntax</span></strong></p>
<p><span style="font-size: 10pt; color: black;">C#</span></p>
<p><span style="font-size: 9.5pt; color: blue;">string</span><span style="font-size: 9.5pt; color: black;"> GetValueFromDB(<br /> </span><span style="font-size: 9.5pt; color: blue;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string</span><span style="font-size: 9.5pt; color: black;"> connectionString, <br /> </span><span style="font-size: 9.5pt; color: blue;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string</span><span style="font-size: 9.5pt; color: black;"> tableName, <br /> </span><span style="font-size: 9.5pt; color: blue;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;string</span><span style="font-size: 9.5pt; color: black;"> searchByColumn, <br /> </span><span style="font-size: 9.5pt; color: blue;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string</span><span style="font-size: 9.5pt; color: black;"> searchValue, <br /> </span><span style="font-size: 9.5pt; color: blue;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; string</span><span style="font-size: 9.5pt; color: black;"> targetColumn)</span><span style="font-size: 9.5pt; color: black;"><br /> </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-size: 9.5pt; color: black;"><br /> </span>)</p>
<p><span style="font-size: 10pt; color: black;">&nbsp;</span><span style="font-size: 10pt; color: #3f529c;">Parameters</span></p>
<p><em><span style="font-size: 9.5pt; color: black;">connectionString</span></em></p>
<p><span style="font-size: 10pt; color: black;">Type:&nbsp;</span><a href="http://msdn.microsoft.com/en-us/library/system.string.aspx">System.String</a></p>
<p><span style="font-size: 10pt; color: black;">The connection string of the database that has the desired table.</span></p>
<p><span style="font-size: 10pt; color: black;">&nbsp;</span></p>
<p><em><span style="font-size: 9.5pt; color: black;">tableName</span></em><em>&nbsp;</em></p>
<p><span style="font-size: 10pt; color: black;">Type:&nbsp;</span><a href="http://msdn.microsoft.com/en-us/library/system.string.aspx">System.String</a></p>
<p><span style="font-size: 10pt; color: black;">The table name that we want to use</span></p>
<p><span style="font-size: 10pt; color: black;">&nbsp;</span></p>
<p><em><span style="font-size: 9.5pt; color: black;">searchByColumn</span></em></p>
<p><span style="font-size: 10pt; color: black;">Type:&nbsp;</span><a href="http://msdn.microsoft.com/en-us/library/system.string.aspx">System.String</a></p>
<p>The search by column that will be used in the where clause.</p>
<p>&nbsp;</p>
<p><em><span style="font-size: 9.5pt; color: black;">searchValue</span></em></p>
<p><span style="font-size: 10pt; color: black;">Type:&nbsp;</span><a href="http://msdn.microsoft.com/en-us/library/system.string.aspx">System.String</a></p>
<p>The value that will be used in the where clause after the = operator, remember to put single quotes around the value if the value is string for example 'Seif'.</p>
<p><span style="font-size: 10pt; color: black;">&nbsp;</span></p>
<p><em><span style="font-size: 9.5pt; color: black;">targetColumn</span></em></p>
<p><span style="font-size: 10pt; color: black;">Type:&nbsp;</span><a href="http://msdn.microsoft.com/en-us/library/system.string.aspx">System.String</a></p>
<p>The name of column that we want to get its value.</p>
<p><span style="font-size: 10pt; color: #3f529c;"><br /> Return Value</span></p>
<p><span style="font-size: 10pt; color: black;">Type:&nbsp;</span><a href="http://msdn.microsoft.com/en-us/library/system.string.aspx">System.String</a></p>
<p>&nbsp;<span style="font-size: 10pt; color: black;">The scalar value that we want to retrieve&nbsp;</span></p>
<p><span style="font-size: 10pt; color: black;">&nbsp;&nbsp;<hr/></span></p>
<p><strong><span style="font-size: 15pt; color: #3f529c;">And many other methods&hellip;.</span></strong><strong>&nbsp;</strong></p>
<p>&nbsp;</p>
<p><strong>Note:</strong></p>
<p>This Framework need SQL Server because it use <span style="white-space: normal; text-transform: none; word-spacing: 0px; color: #000000; text-align: left; font: 13px 'Segoe UI',Verdana,Arial; orphans: 2; widows: 2; letter-spacing: normal; text-indent: 0px;"> <span style="font-weight: bold;">Microsoft.SqlServer.Management.Smo</span></span><span style="white-space: normal; text-transform: none; word-spacing: 0px; float: none; color: #000000; text-align: left; font: 13px 'Segoe UI',Verdana,Arial; orphans: 2; widows: 2; display: inline!important; letter-spacing: normal; text-indent: 0px;">&nbsp;which contains the instance object classes that represent SQL Server Database Engine objects and some utility classes that represent specific tasks, such as scripting. When a connection to the instance of the SQL Server Database Engine has been established by using a Server object variable, objects on the instance can be accessed by using the SMO instance objects.&nbsp;</span></p>
</div>
