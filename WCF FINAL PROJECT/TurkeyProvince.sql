Create Database asdd
go
use asdd
go

Create table Users
(
	UserID int primary key Identity,
	UserName nvarchar(50)unique,
	Password nvarchar(50),
	IsActive Bit Default 1
)

Insert into Users(UserName,Password,IsActive) 
values('mhmtens13', '13',0)

Insert into Users(UserName,Password,IsActive) 
values('berkin1', '1',1)

Insert into Users(UserName,Password,IsActive) 
values('hasan42', '42',0)

Insert into Users(UserName,Password,IsActive) 
values('mete06', '06',1)

go
		
create table City
(
	CityID int primary key Identity,
	CityName nvarchar(50),
	PlateCode int unique,
	Population nvarchar(50),
	Picture image,
	PlaceToVisitID int,
	WhatFamousID int,
	RegionID int,
	TransportationServiceID int,
	PartyID int
)

Insert into City(CityName,PlateCode,Population,PlaceToVisitID,WhatFamousID,RegionID,TransportationServiceID,PartyID)
values('Sivas',58,'700 Bin',2,2,2,2,2)
Insert into City(CityName,PlateCode,Population,PlaceToVisitID,WhatFamousID,RegionID,TransportationServiceID,PartyID)
values('Ýstanbul',34,'16 Milyon',2,2,2,2,2)
Insert into City(CityName,PlateCode,Population,PlaceToVisitID,WhatFamousID,RegionID,TransportationServiceID,PartyID)
values('Ankara',34,'6 Milyon',1,1,1,1,1)

go

create table Town
(
	TownID int primary key Identity,
	TownName nvarchar(50),
	Population nvarchar(50),
	Picture image,
	CityID int,
	PlaceToVisitID int,
	WhatFamousID int,
	TransportationServiceID int,
	PartyID int
)
Insert into Town(TownName,Population,CityID,PlaceToVisitID,WhatFamousID,TransportationServiceID,PartyID)
values('Hafik', '7 Bin',2,2,2,2,2)
Insert into Town(TownName,Population,CityID,PlaceToVisitID,WhatFamousID,TransportationServiceID,PartyID)
values('Çankaya', '1 Milyon',1,1,1,1,1)

go

Create table Village
(
	VillageID int primary key Identity,
	VillageName nvarchar(50),
	Population nvarchar(50),
	Picture image,
	TownID int,
	PlaceToVisitID int,
	WhatFamousID int
)

Insert into Village(VillageName, Population, TownID, PlaceToVisitID, WhatFamousID)
values('Pusat', '1256', 1,1,1)

go

create table PlacesToVisit
(
	PlaceToVisitID int primary key Identity,
	PlaceToVisit nvarchar(300),
)

Insert into PlacesToVisit(PlaceToVisit)values('Anýtkabir')
Insert into PlacesToVisit(PlaceToVisit)values('Ulu Cami')
Insert into PlacesToVisit(PlaceToVisit)values('Topkapý Sarayý, Dolmabahçe Sarayý')

go

create table WhatFamous
(
	WhatFamousID int primary key Identity,
	WhatFamous nvarchar(200)
)

Insert into WhatFamous(WhatFamous)values('Keçi')
Insert into WhatFamous(WhatFamous)values('Sivas Köftesi')

go

Create table Region
(
	RegionID int primary key Identity,
	RegionName nvarchar(50)
)

Insert into Region(RegionName)values('Marmara Bölgesi')
Insert into Region(RegionName)values('Karadeniz Bölgesi')
Insert into Region(RegionName)values('Güneydoðu Anadolu Bölgesi')
Insert into Region(RegionName)values('Ýç Anadolu Bölgesi')

go

Create table TransportationServices
(
	TransportationServicesID int primary key Identity,
	TransportationService nvarchar(200)
)

Insert into TransportationServices(TransportationService) values('Otobüs')
Insert into TransportationServices(TransportationService) values('Metro')
Insert into TransportationServices(TransportationService) values('Marmaray')

go

Create table RulingParty
(
	PartyID int primary key Identity,
	Party nvarchar(50)
)

Insert into RulingParty(Party) values('A Partisi')
Insert into RulingParty(Party) values('B Partisi')

go

Create proc SP_TownByCity
as
Select
	T.TownName,
	SUM(C.CityID) City
from City C
join Town T on C.CityID=T.CityID
group by T.TownName

go

Create proc SP_VillageByTown
as
Select
	V.VillageName,
	SUM(T.TownID) Town
from Town T
join Village V on T.TownID=V.TownID
group by V.VillageName



/*
Ýþsizlik oraný --
Baðýmsýz olduðu tarih
Kadýn-Erkek oran --
Eðitim Seviyesi --
*/ 