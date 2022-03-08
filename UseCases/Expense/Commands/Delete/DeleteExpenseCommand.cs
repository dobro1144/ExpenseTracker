using MediatR;

namespace UseCases.Expense.Commands.Delete
{
    public class DeleteExpenseCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
