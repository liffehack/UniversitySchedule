USE MASTER 
GO

IF EXISTS (SELECT 1 FROM sys.databases AS d WHERE d.name = 'DBfivt')
DROP DATABASE DBfivt 
GO

CREATE DATABASE DBfivt;
GO
ALTER DATABASE DBfivt
SET RECOVERY SIMPLE;
GO
 
USE DBfivt;
GO

CREATE TABLE Groups		-- Справочник групп
(
    [LINK] 				[INT] PRIMARY KEY IDENTITY,				-- Ид
    [Name_groups]	    [VARCHAR] 	(30) NOT NULL   			-- Название группы
);


CREATE TABLE Teachers	-- Справочник преподавателей
(
    [LINK] 				[INT] 		PRIMARY KEY IDENTITY, 		-- Ид (Номер преподавателя)	
    [Name_teacher]		[VARCHAR] 	(100) NOT NULL				-- Преподаватель
);

CREATE TABLE Days		-- Справочник дней {0 - понедельник,1,2,3,4,5}
(
    [LINK] 				[INT]  		PRIMARY KEY IDENTITY,   	-- Ид (Номер дня)	
    [days]				[varchar] 	(30) NOT NULL    			-- День недели
);

CREATE TABLE Timetables	-- Справочник пар {1,2,3,4,5,6,8,9}
(
    [LINK] 				[INT]  		PRIMARY KEY IDENTITY, 		-- Ид (Номер пары)
    [timetable_begin]	[time] 		NOT NULL,    				-- Время начала	пары	
    [timetable_end]		[time] 		NOT NULL    				-- Время конца пары
	[audio_path] 		[VARCHAR] (300)   NULL  				-- Путь к аудиофайлу
);

CREATE TABLE SubGroups	-- Справочник подгрупп {0 - по умолчанию, 1 - 1 ая подгруппа, 2 - 2 подгруппа}
(
    [LINK] 				[INT] 		PRIMARY KEY IDENTITY,		-- Ид (Номер подгруппы)
    [Name_subgroups] 	[VARCHAR] 	(20) NOT NULL    			-- Название подгруппы
);

CREATE TABLE TypeWeek	-- Справочние типа недели {0 - по умолчанию, 1 - четная, 2 - нечетная}
(
    [LINK]				 [INT] 		PRIMARY KEY IDENTITY, 		-- Ид	
    [Name_type_week] 	 [VARCHAR] 	(30) NOT NULL    			-- Наименование типа недели
);

CREATE TABLE Courses	-- Справочние курсов { 1 - Первый курс, 2 - Второй курс ...}
(
    [LINK]				 [INT] 		PRIMARY KEY IDENTITY, 		-- Ид	
    [Name_cours] 	 	 [VARCHAR] 	(30) NOT NULL    			-- Наименование курса
);

CREATE TABLE Timesheet 	-- Расписание
(	
	[LINK]			[INT] 		PRIMARY KEY IDENTITY, 			-- Ид	
	[F_group]    	[int] NOT NULL,								-- Группа
	[F_days]     	[int] NOT NULL,								-- День 
	[F_timetable]   [int] NOT NULL,								-- Номер пары
	[F_teacher]     [int] NULL,									-- Преподаватель
	[F_typeweek]    [int] NOT NULL,								-- Тип недели
	[F_subgroups]   [int] NULL,									-- Номер подгруппы
	[subject] 		[VARCHAR] (100)   NULL,  					-- Предмет
	[audience] 		[VARCHAR] (20)    NULL  					-- Аудитория
	 CONSTRAINT FK_Groups_Timesheet FOREIGN KEY (F_group) REFERENCES dbo.Groups (LINK),	 
	 CONSTRAINT FK_Days_Timesheet FOREIGN KEY (F_days) REFERENCES dbo.Days (LINK),
	 CONSTRAINT FK_Timetables_Timesheet FOREIGN KEY (F_timetable) REFERENCES dbo.Timetables (LINK),
	 CONSTRAINT FK_Teachers_Timesheet FOREIGN KEY (F_teacher) REFERENCES dbo.Teachers (LINK),
	 CONSTRAINT FK_TypeWeek_Timesheet FOREIGN KEY (F_typeweek) REFERENCES dbo.TypeWeek (LINK),
	 CONSTRAINT FK_SubGroups_Timesheet FOREIGN KEY (F_subgroups) REFERENCES dbo.SubGroups (LINK)
);

CREATE TABLE Messages	-- Справочник сообщений { 1 - Первый курс, 2 - Второй курс ...}
(
    [id]				[INT] 		PRIMARY KEY IDENTITY, 		-- Ид	
    [message]			[VARCHAR]   (1000)   NULL				-- Сообщение
);
