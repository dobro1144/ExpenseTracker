using MediatR;
using System.Collections.Generic;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Queries.GetAll
{
    public class GetAllExpensesQuery : IRequest<IEnumerable<ExpenseDto>>
    {
    }
}
