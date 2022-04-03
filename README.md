Web API test application

### Implemented technologies

- .NET 6
- ASP.NET Core
- Entity Framework Core
- MS SQL
- MediatR
- AutoMapper
- FluentValidation
- Serilog
- Swagger

### API overview

<table>
  <thead>
    <tr>
      <th>API</th>
      <th>Description</th>
      <th>Request body</th>
      <th>Response body</th>
    </tr>
  </thead>
  <tbody>
    <tr><td colspan="4" align="center">Users</td></tr>
    <tr>
      <td><code>GET /api/user</code></td>
      <td>Get all users</td>
      <td>None</td>
      <td>List of users</td>
    </tr>
    <tr>
      <td><code>GET /api/user/{id}</code></td>
      <td>Get an item by ID</td>
      <td>None</td>
      <td>User</td>
    </tr>
    <tr>
      <td><code>POST /api/user</code></td>
      <td>Add a new item</td>
      <td>User</td>
      <td>User</td>
    </tr>
    <tr>
      <td><code>PUT /api/user/{id}</code></td>
      <td>Update an existing user</td>
      <td>User</td>
      <td>Timestamp</td>
    </tr>
    <tr>
      <td><code>DELETE /api/user/{id}</code></td>
      <td>Delete an item</td>
      <td>Timestamp</td>
      <td>None</td>
    </tr>
    <tr><td colspan="4" align="center">Accounts</td></tr>
    <tr>
      <td><code>GET /api/account</code></td>
      <td>Get all accounts</td>
      <td>None</td>
      <td>List of accounts</td>
    </tr>
    <tr>
      <td><code>GET /api/account/{id}</code></td>
      <td>Get an item by ID</td>
      <td>None</td>
      <td>Account</td>
    </tr>
    <tr>
      <td><code>POST /api/account</code></td>
      <td>Add a new item</td>
      <td>Account</td>
      <td>Account</td>
    </tr>
    <tr>
      <td><code>PUT /api/account/{id}</code></td>
      <td>Update an existing item</td>
      <td>Account</td>
      <td>Timestamp</td>
    </tr>
    <tr>
      <td><code>DELETE /api/account/{id}</code></td>
      <td>Delete an item</td>
      <td>Timestamp</td>
      <td>None</td>
    </tr>
    <tr>
      <td><code>POST /api/account/moveentries</code></td>
      <td>Move incomes and expenses to another account</td>
      <td>FromId, ToId</td>
      <td>None</td>
    </tr>
    <tr><td colspan="4" align="center">Categories</td></tr>
    <tr>
      <td><code>GET /api/category</code></td>
      <td>Get all categories</td>
      <td>None</td>
      <td>List of categories</td>
    </tr>
    <tr>
      <td><code>GET /api/category/{id}</code></td>
      <td>Get an item by ID</td>
      <td>None</td>
      <td>Category</td>
    </tr>
    <tr>
      <td><code>POST /api/category</code></td>
      <td>Add a new item</td>
      <td>Category</td>
      <td>Category</td>
    </tr>
    <tr>
      <td><code>PUT /api/category/{id}</code></td>
      <td>Update an existing item</td>
      <td>Category</td>
      <td>Timestamp</td>
    </tr>
    <tr>
      <td><code>DELETE /api/category/{id}</code></td>
      <td>Delete an item</td>
      <td>Timestamp</td>
      <td>None</td>
    </tr>
    <tr>
      <td><code>POST /api/category/moveexpenses</code></td>
      <td>Move expenses to another category</td>
      <td>FromId, ToId</td>
      <td>None</td>
    </tr>
    <tr><td colspan="4" align="center">Incomes</td></tr>
    <tr>
      <td><code>GET /api/income</code></td>
      <td>Get all incomes</td>
      <td>None</td>
      <td>List of incomes</td>
    </tr>
    <tr>
      <td><code>GET /api/income/{id}</code></td>
      <td>Get an item by ID</td>
      <td>None</td>
      <td>Income</td>
    </tr>
    <tr>
      <td><code>POST /api/income</code></td>
      <td>Add a new item</td>
      <td>Income</td>
      <td>Income</td>
    </tr>
    <tr>
      <td><code>PUT /api/income/{id}</code></td>
      <td>Update an existing item</td>
      <td>Income</td>
      <td>Timestamp</td>
    </tr>
    <tr>
      <td><code>DELETE /api/income/{id}</code></td>
      <td>Delete an item</td>
      <td>Timestamp</td>
      <td>None</td>
    </tr>
    <tr><td colspan="4" align="center">Expenses</td></tr>
    <tr>
      <td><code>GET /api/expense</code></td>
      <td>Get all expenses</td>
      <td>None</td>
      <td>List of expenses</td>
    </tr>
    <tr>
      <td><code>GET /api/expense/{id}</code></td>
      <td>Get an item by ID</td>
      <td>None</td>
      <td>Expense</td>
    </tr>
    <tr>
      <td><code>POST /api/expense</code></td>
      <td>Add a new item</td>
      <td>Expense</td>
      <td>Expense</td>
    </tr>
    <tr>
      <td><code>PUT /api/expense/{id}</code></td>
      <td>Update an existing item</td>
      <td>Expense</td>
      <td>Timestamp</td>
    </tr>
    <tr>
      <td><code>DELETE /api/expense/{id}</code></td>
      <td>Delete an item</td>
      <td>Timestamp</td>
      <td>None</td>
    </tr>
  </tbody>
</table>
