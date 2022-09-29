# Divisions
 Divisions
Тестовое задание для вакансии C# Junior
___________________________________________________________________________________________________________________________________________________________________

Имеется список подразделений организации. 
Каждое подразделение имеет уникальное наименование, статус(Активно/Заблокировано), а также может входить в состав другого подразделения. 
Данные о наименованиях и структуре подразделений хранятся в базе данных PostgreSQL (https://www.postgresql.org/).
Данные о статусе подразделений отдает сервис А. Статус каждого подразделения должен изменяться каждые 3 секунды.
Данные о наименовании подразделений, структуру подразделений, а также страницу со списком отдает сервис B.
Клиентская часть в браузере. 
Сервисы А и B должны быть реализованы на ASP.NET Core 2.1 или более новой версии.
API сервиса А доступно только сервису B. Сервис B доступен для всех и должен реализовывать паттерн MVC.

Создайте страницу, отображающую структуру данных о подразделениях со статусами.
На странице должен быть контекстный фильтр по наименованию подразделения, а также кнопка "Синхронизация данных". 
По нажатию кнопки "Синхронизация данных" - организовать синхронизацию данных о подразделениях с данными в файле (формат произвольный).
В БД древовидная структура, в файле тоже.
1. Основное - это БД. Если там есть подразделение, его нельзя удалять.
2. Синхронизация:
- если подразделение есть в БД, но нет в файле, подразделение не трогаем, оставляем в БД;
- если подразделения нет в БД, но есть в файле, его нужно добавить в БД;
- если в файле и БД есть подразделения, то проверяем их положение в дереве: если положения одинаковые, то оставляем в БД, как есть; если положение подразделения в БД и файле отличаются, делаем, как в файле.

___________________________________________________________________________________________________________________________________________________________________

