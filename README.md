Требования
.NET Core SDK 6.0 или выше.
SQL Server для хранения данных.
Установленный QuickBooks SDK и доступ к тестовой компании.

Работа с API
Авторизация
Получите JWT токен:

POST https://host/api/auth/login
Content-Type: application/json

{
    "username": "",
    "password": ""
}

Authorization: Bearer Токен который получите

