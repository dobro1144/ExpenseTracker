using UseCases.Base.Commands.Create;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Commands.Create
{
    public class CreateExpenseCommand : CreateEntityCommand<CreateExpenseDto, ExpenseDto>
    {
    }
}
