Web API test application

### Overview

| API | Description | Request body | Response body |
| --- | --- | --- | --- |
| `GET /api/category` | Get all category items | None | Array of category items |
| `GET /api/category/{id}` | Get an item by ID | None | Category item |
| `POST /api/category` | Add a new item | Category item | Category item |
| `PUT /api/category/{id}` | Update an existing item | Category item | Timestamp |
| `DELETE /api/category/{id}/{timestamp}` | Delete an item | None | None |
| | | | |
| `GET /api/expense` | Get all expense items | None | Array of expense items |
| `GET /api/expense/{id}` | Get an item by ID | None | Expense item |
| `POST /api/expense` | Add a new item | Expense item | Expense item |
| `PUT /api/expense/{id}` | Update an existing item | Expense item | Timestamp |
| `DELETE /api/expense/{id}/{timestamp}` | Delete an item | None | None |
