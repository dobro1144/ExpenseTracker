using MediatR;

namespace UseCases.Expense.Commands.Delete
{
    public class DeleteExpenseCommand : IRequest
    {
        public int Id { get; set; }
    }
}
