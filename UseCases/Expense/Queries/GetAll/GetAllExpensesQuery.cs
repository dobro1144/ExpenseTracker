using UseCases.Base.Queries.GetAll;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Queries.GetAll
{
    public class GetAllExpensesQuery : GetAllEntitiesQuery<GetAllExpensesQueryDto, ExpenseDto>
    {
    }
}
