using MediatR;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Commands.Update
{
    public class UpdateExpenseCommand : IRequest<byte[]?>
    {
        public int Id { get; set; }
        public UpdateExpenseDto Dto { get; set; } = null!;
    }
}
