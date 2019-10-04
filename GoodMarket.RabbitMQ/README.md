# Настройки RabbitMQ

### Конфигурация соединения
Конфигурация должна называться "RabbitConnection"
Пример конфигурационного объекта

    ```json
      "RabbitConnection": {
        "HostName": "localhost",
        "Username": "guest",
        "Password": "guest",
        "VirtualHost": "/",
        "AutomaticRecoveryEnabled": true,
        "RequestedHeartbeat": 30
      },
    ```
    
### Конфигурация схемы
Схема предназначена для того, чтобы предварительно поднять указанные exchange, queue и настроить их.  
Стоит выносить json со схемой в отдельный файл.

Подтянуть все файлы, которые заканчиваются на *rabbitschema.json
    ConfigureGMRabbitHost(host)
    
Настроить DI для всех конфигурации - заканчиваются на RabbitSchema
    

    ```json
    {
      "ChatHubRabbitSchema": {
        "Queues": [
          {
            "Queue": "Queue1",
            "Durable": false,
            "Exclusive": false,
            "AutoDelete": false
          }
        ],
        "Exchanges": [
          {
            "Exchange": "Exchange1",
            "Type": "direct",
            "Durable": false,
            "AutoDelete": false
          }
        ],
        "ExchangeBinds": [
          {
            "Destination": "",
            "Source": "",
            "RoutingKey": ""
          }
        ],
        "QueueBinds": [
          {
            "Queue": "Queue1",
            "Exchange": "Exchange1",
            "RoutingKey": ""
          }
        ]
      }
    }

    ```
    
    