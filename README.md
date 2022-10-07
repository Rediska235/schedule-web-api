# Schedule Web API
> Web API project for school/university timetable management

## Methods

- get today schedule
- get all
- get by day
- insert
- update
- delete

## Examples

Request URL: 
```
https://localhost:7215/DailySсhedule/GetTodaySсhedule
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

>Everyone could see your schedule but only people with `ApiKey` can update it.

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
