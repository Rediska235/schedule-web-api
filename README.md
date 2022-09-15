# Shedule WebApi
> An ASP.NET Core Web API project to manage your shedule for school/university.

## Methods

- GetTodayShedule &emsp; (GET)
- GetAll &emsp; &emsp; &emsp; &emsp; &emsp; (GET)
- GetByDay &emsp; &emsp; &emsp; &emsp;(GET)
- Insert &emsp; &emsp; &emsp; &emsp; &emsp; &nbsp;(POST)
- Update &emsp; &emsp; &emsp; &emsp; &ensp; (POST)
- Delete &emsp; &emsp; &emsp; &emsp; &emsp;(DELETE)

## Examples

Request URL: 
```
https://localhost:{Your port}/DailyShedule/GetTodayShedule
```

Response body:
```
{
  "dayOfWeek": 5,
  "first": "БЖЧ",
  "second": "Методы вычислений",
  "third": "Методы вычислений",
  "fourth": "Машинное обучение"
}
```

## ApiKey

>Everyone could see your shedule but only people with `ApiKey` can update it.

To create your ApiKey you need to follow this steps:

### Enable secret storage
```
dotnet user-secrets init
```

### Set a secret
```
dotnet user-secrets set "ApiKey" "{Your ApiKey}"
```

Or right-click the project in solution explorer go to "Manage User Secrets" and enter "ApiKey": "{Your ApiKey}"
