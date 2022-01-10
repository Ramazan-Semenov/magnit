DECLARE @UserName NvarChar(50);
SET @UserName = 'LAPTOP-86BFKAJP\lenovo';

select  Users.Id as "Id сотрудника", Dep.NameDep as "Название отдела" from Users

join Dep_User on [Users].Id=Dep_User.[User_name]
left join Dep on Dep_User.Dep_name=Dep.Id
where Users.[Name]=@UserName

----------------------------------------------------------------
select Role_name as "Роли сотрудника" from Users

join[User_Role] on Users.Id = User_Role.[User]
join[Role] on User_Role.[Role] =[Role].Id

where Users.[Name]= @UserName
-----------------------------------------------------------------
DECLARE @Department NvarChar(50);
SET @Department = N'Аналитика';

select Users.Id as "Id сотрудников", Users.[Name] as "Сотрудники департамента" from Dep
join Dep_User on Dep.Id=Dep_User.Dep_name
join Users on Dep_User.[User_name]=Users.Id
where NameDep=@Department