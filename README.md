Web API test application

### Overview

| API | Description | Request body | Response body |
| --- | --- | --- | --- |
| `GET /api/user` | Get all users | None | List of users |
| `GET /api/user/{id}` | Get an item by ID | None | User |
| `POST /api/user` | Add a new item | User | User |
| `PUT /api/user/{id}` | Update an existing user | User | Timestamp |
| `DELETE /api/user/{id}` | Delete an item | Timestamp | None |
| | | | |
| `GET /api/account` | Get all accounts | None | List of accounts |
| `GET /api/account/{id}` | Get an item by ID | None | Account |
| `POST /api/account` | Add a new item | Account | Account |
| `PUT /api/account/{id}` | Update an existing account | Account | Timestamp |
| `DELETE /api/account/{id}` | Delete an item | Timestamp | None |
| | | | |
| `GET /api/category` | Get all category items | None | Array of category items |
| `GET /api/category/{id}` | Get an item by ID | None | Category item |
| `POST /api/category` | Add a new item | Category item | Category item |
| `PUT /api/category/{id}` | Update an existing item | Category item | Timestamp |
| `DELETE /api/category/{id}` | Delete an item | Timestamp | None |
| | | | |
| `GET /api/income` | Get all income items | None | Array of income items |
| `GET /api/income/{id}` | Get an item by ID | None | Income item |
| `POST /api/income` | Add a new item | Income item | Income item |
| `PUT /api/income/{id}` | Update an existing item | Income item | Timestamp |
| `DELETE /api/income/{id}` | Delete an item | Timestamp | None |
| | | | |
| `GET /api/expense` | Get all expense items | None | Array of expense items |
| `GET /api/expense/{id}` | Get an item by ID | None | Expense item |
| `POST /api/expense` | Add a new item | Expense item | Expense item |
| `PUT /api/expense/{id}` | Update an existing item | Expense item | Timestamp |
| `DELETE /api/expense/{id}` | Delete an item | Timestamp | None |
