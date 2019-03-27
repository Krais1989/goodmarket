# Good Market

Тестовый проект с бэкэндом на .NetCore и фронтэндом на React.

## Структура проектов серверной части

### GoodMarket.API
  .Net Core WebApi приложение.
  
### GoodMarket.Application.Tests
  Unit-Тесты на xUnit
  
### GoodMarket.Application
  Библиотека с бизнес-логикой.
  
### GoodMarket.Domain
  Библиотека с классами доменных объектов.
  
### GoodMarket.Persistence
  Библиотека с функциями доступа к хранилищу.
  
### GoodMarket.Common
  Библиотека с общим функционалом.
  
  
## Запуск серверной части

### Локально 

### Через Docker
  Образ собирается из конфига *Dockerfile*.
  Контейнеры разворачиваются через **Docker-Compose** с конфигом в *gm.yml*.
  
  
## Клиенская часть 
  Сейчас располагается в [GoodMarket.Api/wwwroot/app/](GoodMarket.Api/wwwroot/app/)
