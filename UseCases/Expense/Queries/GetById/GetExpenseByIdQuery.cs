using MediatR;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Queries.GetById
{
    public class GetExpenseByIdQuery : IRequest<ExpenseDto?>
    {
        public int Id { get; set; }
    }
}
