INSERT INTO dbo.Curriculums
        ( CurrID, CurrName )
VALUES  ( 'APPTECH',N'Lập Trình Viên Apptech Quốc Tế'),
		( 'COLLEGE',N'Cao Đẳng Công Nghệ Thông Tin'),
		( 'ARENA',N'Mỹ Thuật Đa Phương Tiện Quốc Tế'),
		( 'ENGLAND',N'Công Nghệ Thông Tin Anh Quốc')

INSERT INTO dbo.Classes
        ( ClassID ,
          ClassName ,
          CurrID ,
          SlotTime
        )
VALUES ( 'CP1996G03' ,N'Lớp Hoa Sen Đỏ' ,'APPTECH' ,'G: 7:00-9:00'),
		( 'CP1995H07' ,N'Lớp Chuối Vàng' ,'APPTECH' ,'H: 9:00-11:00'),
		( 'CP1994I09' ,N'Lớp Xanh Biển' ,'COLLEGE' ,'I: 13:00-15:00'),
		( 'CP1995H08' ,N'Lớp Muôn Màu' ,'COLLEGE' ,'G: 7:00-9:00'),
		( 'CP1993I04' ,N'Lớp Ngọc Trai' ,'ARENA' ,'I: 13:00-15:00'),
		( 'CP1996K01' ,N'Lớp Bình Minh' ,'ENGLAND' ,'K: 15:00-17:00'),
		( 'CP1994L03' ,N'Lớp Hoàng Hôn' ,'COLLEGE' ,'L: 17:00-19:00'),
		( 'CP1994G01' ,N'Lớp Ngày Mai' ,'COLLEGE' ,'M: 19:00-21:00')


INSERT INTO dbo.Subjects
        ( SubID, SubName, CurrID, Sem, Hours )
VALUES  ( 'START',N'Lập Trình Căn Bản C,C++','COLLEGE',1,20),
		( 'OOP',N'Lập Trình Căn Hướng Đối Tượng C,C++','COLLEGE',2,40),
		( 'SQL',N'Cơ Sở Dữ Liệu Căn Bản Và Nâng Cao (SQL Server)','COLLEGE',2,50),
		( 'WEB',N'Lập Trình Web Căn Bản','COLLEGE',3,30),
		( 'PROG',N'Nhập Môn Công Nghệ Phần Mềm','COLLEGE',1,10),
		( 'WEBSTR',N'HTML/CSS/JS Căn Bản Và Nâng Cao','APPTECH',1,30),
		( 'JAVA-1',N'Lập Trình Java Cơ Bản','APPTECH',1,30),
		( 'JAVA-2',N'Lập Trình Java Nâng Cao','APPTECH',1,50),
		( 'PYTH',N'Lập trình Python cơ bản và nâng cao','COLLEGE',1,80),
		( 'CDATAM',N'Cấu trúc dữ liệu và thuật toán','COLLEGE',2,100),
		( 'MATH',N'Toán rời rạc','COLLEGE',2,120),
		( 'SQLPROMT',N'Phân tích thiết kế cơ sở dữ liệu','COLLEGE',2,80),
		( 'DICE',N'Xác suất thống kê','COLLEGE',1,90),
		( 'ENGAM',N'Anh văn căn bản','COLLEGE',1,40),
		( 'SEC',N'An Ninh Mạng','COLLEGE',1,20),
		( 'MANIT',N'Quản trị hệ thống','COLLEGE',3,60),
		( 'MACL',N'Chủ Nghĩa Mác Lê-nin','COLLEGE',1,30),
		( 'JSADV',N'Lập trình Javascript Nâng Cao(ES 6)','APPTECH',2,40),
		( 'TYPESRC',N'Lập trình Typescript cơ bản và nâng cao','APPTECH',1,20),
		( 'ANDR',N'Lập trình App Android','APPTECH',3,90),
		( 'LAV',N'Laravel Cơ Bản','APPTECH',3,50),
		( 'MSA',N'MS Azure','APPTECH',3,70),
		( 'BOOT4',N'Bootstrap v4.5 và Jquery','APPTECH',1,20),
		( 'SPRING',N'Spring Căn Bản','APPTECH',3,50),
		( 'MYSQL',N'Sử Dụng Mysql','APPTECH',2,30),
		( 'PHPAM',N'Lập trình Php cơ bản và nâng cao','APPTECH',2,90),
		( 'ADI',N'ADI NCC','APPTECH',3,20),
		( 'MODEL',N'Dựng 3D Model','ARENA',3,160),
		( 'PTS',N'Toàn Thư Photoshop','ARENA',1,60),
		( 'AIAD',N'Tạo Logo bằng Adobe AI','ARENA',2,120),
		( 'CSHR',N'Dựng Model 2D','APPTECH',3,90)


INSERT INTO dbo.Lecturers
        ( LecID, Fullname, Password )
VALUES  ( 'LEC01',N'Nguyễn Thành Nam','01234'),
		( 'LEC02',N'Nguyễn Trung Tấn','03356'),
		( 'LEC03',N'Trần Thị Thiên Anh','thienanh1234'),
		( 'LEC05',N'Lê Thanh Thống','01234thong01234'),
		( 'LEC06',N'Nguyễn Thị Tuyết Nhung','0164789a'),
		( 'LEC07',N'Trần Hồng Tâm','tam123456'),
		( 'LEC08',N'Liểu Thị Thu Hiền','56987123'),
		( 'LEC09',N'Bùi Tấn Tài','tai201412abc'),
		( 'LEC010',N'Trương Quốc Lâm','0335808794aA'),
		( 'LEC011',N'Anh Tuấn','tuan000'),
		( 'LEC012',N'Trần Quốc Hảo','tqhao1234'),
		( 'LEC013',N'Bùi Thanh Lâm','456212758285')
		
INSERT INTO dbo.SubjectsOfClass
        ( SubID ,
          ClassID ,
          LecID ,
          StartDate ,
          EndDate ,
          Hours ,
          SlotTime ,
          Status
        )
VALUES  ( 'START' ,'CP1994I09' ,'LEC013' ,'2018-10-20' ,'2018-11-15' ,2 ,'I: 13:00-15:00' ,1 ),
		( 'ENGAM' ,'CP1995H08' ,'LEC08' ,'2017-04-21' ,'2017-05-22' ,2 ,'H: 9:00-11:00' ,2 ),
		( 'SEC' ,'CP1995H08' ,'LEC07' ,'2019-11-10' ,'2019-12-13' ,2 ,'H: 9:00-11:00' ,1 ),
		( 'JAVA-1' ,'CP1994I09' ,'LEC012' ,'2020-01-17' ,'2020-02-14' ,2 ,'I: 13:00-15:00' ,1 ),
		( 'MSA' ,'CP1994G01' ,'LEC06' ,'2018-10-20' ,'2018-11-15' ,2 ,'M: 19:00-21:00' ,1 ),
		( 'MODEL' ,'CP1993I04' ,'LEC01' ,'2017-09-10' ,'2017-10-19' ,2 ,'I: 13:00-15:00' ,1 ),
		( 'AIAD' ,'CP1995H07' ,'LEC010' ,'2018-07-12' ,'2018-08-25' ,2 ,'I: 13:00-15:00' ,2 ),
		( 'PTS' ,'CP1994L03' ,'LEC09' ,'2015-11-10' ,'2015-12-15' ,2 ,'L: 17:00-19:00' ,1 ),
		( 'LAV' ,'CP1994I09' ,'LEC06' ,'2020-08-11' ,'2020-09-12' ,2 ,'I: 13:00-15:00' ,2 ),
		( 'WEB' ,'CP1994L03' ,'LEC03' ,'2018-03-12' ,'2018-04-16' ,2 ,'L: 17:00-19:00' ,2 ),
		( 'MYSQL' ,'CP1994I09' ,'LEC08' ,'2016-12-10' ,'2017-01-20' ,2 ,'I: 13:00-15:00' ,1 )

INSERT INTO dbo.Students
        ( StID ,
          StName ,
          Password ,
          PortalID ,
          ClassID ,
          Email ,
          Phone
        )
VALUES  ( 'A19059' ,N'Nguyễn Đức Hiệp Định' , '0164789a' , '' ,'CP1994I09' , 'ndhdinha19059@cusc.ctu.edu.vn' ,'0335808794'),
( 'A19067' ,N'Nguyễn Thanh Tùng' , '01234567a' , '' ,'CP1994I09' , 'nttunga19067@cusc.ctu.edu.vn' ,'0355556385'),
( 'A19060' ,N'Lê Hào Tài' , '542847226' , '' ,'CP1995H07' , 'lhtaia19060@cusc.ctu.edu.vn' ,'0935551943'),
( 'A19061' ,N'Nguyễn Tấn Thành' , '693214025' , '' ,'CP1995H07' , 'ntthanha19061@cusc.ctu.edu.vn' ,'09555513312'),
( 'A19062' ,N'Bùi Định Chuẩn' , '933154055' , '' ,'CP1995H07' , 'bdchuana19062@cusc.ctu.edu.vn' ,'0335555082'),
( 'A19063' ,N'Trần Lê Mã' , '8520244025' , '' ,'CP1994L03' , 'tlmaa1963@cusc.ctu.edu.vn' ,'0335808794'),
( 'A19064' ,N'Nguyễn Thị Thu Trinh' , '524541225' , '' ,'CP1994L03' ,'ntttrinha19064@cusc.ctu.edu.vn' ,'09555530668'),
( 'A19065' ,N'Trần Thị Mẫn' , '269334863' , '' ,'CP1993I04' , 'ttmana19065@cusc.ctu.edu.vn' ,'093555518-57'),
( 'A19066' ,N'Lê Thị Thuỳ Diên' , '5224583635' , '' ,'CP1993I04' , 'lttduyena19066@cusc.ctu.edu.vn' ,'0982521621')


INSERT INTO dbo.Exams
        ( SubOfClaID, Time, Date )
VALUES  ( 5, 45,'2020-01-29'),
		( 2, 90,'2018-11-18'),
		( 3, 45,'2017-05-25')

SELECT * FROM dbo.Exams

INSERT INTO dbo.ExamDetails
        ( ExamID, StID )
VALUES  ( 1, 'A19067'),
		( 3, 'A19066')
