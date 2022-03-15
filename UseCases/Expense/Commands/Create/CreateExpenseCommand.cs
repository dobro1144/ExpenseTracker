using MediatR;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Commands.Create
{
    public class CreateExpenseCommand : IRequest<ExpenseDto>
    {
        public CreateExpenseDto Dto { get; set; } = null!;
    }
}
