# HospitalDb
## Описание
В этой базе данных хранится информация о пациентах, врачах и приёмах в поликлинике. База данных состоит из трёх таблиц: Пациент (Patient), Врач (Doctor) и Приём (Reception). Таблица Пациент содержит идентификатор (PatientId), имя (FirstName), фамилию (LastName) и диагноз пациента (Illness). Таблица Врач содержит идентификатор (DoctorId), имя (FirstName), фамилию (LastName) и специализацию врача (Specialty). Таблица Приём содержит идентификатор (ReceptionId), идентификатор врача (DoctorId), идентификатор пациента (PatientId) и номер кабинета, где проходит приём (RoomNumber). 
Связь между таблицами осуществляется посредством Id врача и пациента, которые являются внешними ключами в таблице Приём. Это означает, что каждая запись в таблице Приём ссылается на одну запись в таблице Врач и одну запись в таблице Пациент. Одному врачу могут соответствовать несколько приёмов. Одному пациенту могут соответствовать несколько приёмов. Одному приёму может соответствовать только один врач и один пациент.
## ER-диаграмма
![ER-Diagram](https://github.com/Romancikh/HospitalDb/blob/main/images/er.png?raw=true)
Ссылка: https://clck.ru/34wfDS
## Запросы
### CREATE
```sql
create table Doctor (
	DoctorId int identity(1, 1) not null constraint PK_Doctor primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Specialty nvarchar(50) not null
)
```
```sql
create table Patient (
	PatientId int identity(1, 1) not null constraint PK_Patient primary key,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Illness nvarchar(50) not null
)
```
```sql
create table Reception (
	ReceptionId int identity(1, 1) not null constraint PK_Reception primary key,
	DoctorId int not null constraint FK_Reception_Doctor references Doctor(DoctorId)
		on delete cascade
		on update cascade,
	PatientId int not null constraint FK_Reception_Patient references Patient(PatientId)
		on delete cascade
		on update cascade,
	RoomNumber int not null
)
```
### INSERT
```sql
insert into Doctor (FirstName, LastName, Specialty)
values
	(N'Иван', N'Смирнов', N'Кардиология'),
	(N'Александра', N'Иванова', N'Офтальмология'),
	(N'Михаил', N'Кузнецов', N'Дерматология'),
	(N'Елена', N'Лебедева', N'Ортопедия'),
	(N'Сергей', N'Смирнов', N'Гастроэнтерология'),
	(N'Мария', N'Волкова', N'Эндокринология')
```
```sql
insert into Patient (FirstName, LastName, Illness)
values
	(N'Анна', N'Смирнова', N'Аритмия'),
	(N'Максим', N'Иванов', N'Сердечная недостаточность'),
	(N'Екатерина', N'Кузнецова', N'Катаракта'),
	(N'Алексей', N'Соколов', N'Глаукома'),
	(N'Дарья', N'Попова', N'Акне'),
	(N'Иван', N'Лебедев', N'Остеоартрит'),
	(N'Александра', N'Смирнова', N'Гастрит'),
	(N'Михаил', N'Морозов', N'Сахарный диабет'),
	(N'Ольга', N'Петрова', N'Гиперпаратиреоз'),
	(N'Андрей', N'Волков', N'Ожирение')
```
```sql
insert into Reception (DoctorId, PatientId, RoomNumber)
values
	(1, 1, 101),
	(1, 2, 101),
	(2, 3, 102),
	(2, 4, 102),
	(3, 5, 103),
	(4, 6, 104),
	(5, 7, 104),
	(6, 8, 105),
	(6, 9, 106),
	(6, 10, 106)
```
### SELECT
```sql
select FirstName, LastName, Specialty from Doctor
```
```sql
select FirstName, LastName from Patient where Illness = N'Ожирение'
```
```sql
select ReceptionId, RoomNumber from Reception where RoomNumber > 104
```
```sql
select
	DoctorId,
	count(PatientId) as PatientsCount
from Reception
group by DoctorId
```
```sql
select * from Doctor order by Specialty
```
```sql
select top 5 * from Reception
```
```sql
select
	DoctorId,
	count(PatientId) as PatientsCount
from Reception
group by DoctorId
having count(PatientId) = 2
```
```sql
select * from Reception where RoomNumber between 100 and 102
```
```sql
select FirstName from Doctor where DoctorId in (1, 3, 5)
```
```sql
select FirstName from Doctor where FirstName like '_____'
```
### UPDATE
```sql
update Doctor set Specialty = N'Дерматология' where DoctorId = 2
```
```sql
update Patient set Illness = N'Остеоартрит' where FirstName like '_____'
```
```sql
update Reception set RoomNumber = 103 where DoctorId = 1 and PatientId = 1
```
### DELETE
```sql
delete from Patient where PatientId = 10
```
### SELECT with JOIN
Для примеров некоторые данные из таблиц были удалены
#### INNER
```sql
select
	Doctor.FirstName as DoctorFirstName,
	Doctor.LastName as DoctorLastName,
	Patient.FirstName as PatientFirstName,
	Patient.LastName as PatientLastName,
	Reception.RoomNumber
from Reception
join Doctor on Reception.DoctorId = Doctor.DoctorId
join Patient on Reception.PatientId = Patient.PatientId
```
Этот запрос соединяет таблицы `Recepеtion`, `Doctor` и `Patient` по `DoctorId` и `PatientId` и достаёт имена врачей, пациентов и номер комнаты.
![INNER JOIN example](https://github.com/Romancikh/HospitalDb/blob/main/images/inner.png?raw=true)
#### LEFT
```sql
select
	Doctor.LastName as DoctorLastName,
	Reception.RoomNumber
from Doctor
left join Reception on Doctor.DoctorId = Reception.DoctorId
```
Этот запрос соединяет таблицы `Recepеtion` и `Doctor` по `DoctorId`. Если у врача не назначено приёмов (нет номера кабинета), то в соответствующем столбце будет **NULL**.
![LEFT JOIN example](https://github.com/Romancikh/HospitalDb/blob/main/images/left.png?raw=true)
#### RIGHT
```sql
select
	Reception.RoomNumber,
	Patient.LastName as DoctorLastName
from Reception
right join Patient on Reception.PatientId = Patient.PatientId
```
Этот запрос соединяет таблицы `Recepеtion` и `Patient` по `PatientId`. Если у пациента не назначено приёмов (нет номера кабинета), то в соответствующем столбце будет **NULL**.
![RIGHT JOIN example](https://github.com/Romancikh/HospitalDb/blob/main/images/right.png?raw=true)