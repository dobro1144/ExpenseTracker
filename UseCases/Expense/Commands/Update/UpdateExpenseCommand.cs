using MediatR;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Commands.Update
{
    public class UpdateExpenseCommand : IRequest<bool>
    {
        public ExpenseDto Expense { get; set; }
    }
}
