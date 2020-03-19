VisitingStolac.BLL.Absractions Readme.txt

Every entity must have it's repository, in this project we create repository abstractions which will be later implemented
by the BL layers like for example (BLL.EF and BLL.Mock, potentially BLL.SP)

In the Unit of work abstraction we need to put all the abstract repositories as the BLL will work with UOW and not with the 
repositories directly (read Unit of work pattern).

When all repositories implement these abstraction potential changes between BLLs won't affact anything in th application.

Folders:
Repositories: Repository abstractions
UOW:          Abstraction for Unit of work