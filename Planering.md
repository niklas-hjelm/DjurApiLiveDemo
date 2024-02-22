# Planering för DjurApi

## Endpoints

### Husdjur

| Path                | Method | Request     | Response | ResponseCodes |
| ------------------- | ------ | ----------- | -------- | ------------- |
| "/pets"             | GET    | NONE        | Pet[]    | 200           |
| "/pets/{id}"        | GET    | int Id      | Pet      | 200, 404      |
| "/pets/{type}"      | GET    | string Type | Pet[]    | 200, 404      |
| "/pets/{age}"       | GET    | int age     | Pet[]    | 200           |
| "/pets/people/{id}" | GET    | int Id      | Person[] | 200           |
| "/pets"             | POST   | Pet         | NONE     | 200, 400      |

### Personer

| Path                      | Method | Request                 | Response | ResponseCodes |
| ------------------------- | ------ | ----------------------- | -------- | ------------- |
| "/people"                 | GET    | NONE                    | Person[] | 200           |
| "/people/{id}"            | GET    | int Id                  | Person   | 200, 404      |
| "/people/pets/{id}"       | GET    | int Id                  | Pet[]    | 200, 404      |
| "/people"                 | POST   | Person                  | NONE     | 200, 400      |
| "/people/pets/{personId}" | POST   | int personId, Pet pet   | NONE     | 200, 404      |
| "/people/pets/{personId}" | PUT    | int personId, int petId | NONE     | 200, 404      |
| "/people/pets/{personId}" | DELETE | int personId, int petId | NONE     | 200, 404      |
| "/people/pets/{type}"     | DELETE | string Type             | Person[] | 200, 404      |

## Data

### Pet

| Property Name | Data Type  | Description            |
| ------------- | ---------- | ---------------------- |
| Id            | int        | Id for database        |
| Name          | string     | Name of the pet        |
| Date of Birth | Date       | To calculate the age   |
| Type          | AnimalType | The type of the animal |

### AnimalType

| Property Name | Data Type | Description                            |
| ------------- | --------- | -------------------------------------- |
| Id            | int       | Id for database                        |
| Name          | string    | Name of the Type (e.g. "Dog" or "Cat") |

### Person

| Property Name | Data Type | Description          |
| ------------- | --------- | -------------------- |
| Id            | int       | Id for database      |
| Name          | string    | Name of the Person   |
| Phone         | string    | Persons phone number |
| Pets          | Pet[]     | List of pets         |
