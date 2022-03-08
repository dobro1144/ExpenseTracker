using MediatR;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Queries.GetAll
{
    public class GetAllExpensesQuery : IRequest<ExpenseDto[]>
    {
    }
}
