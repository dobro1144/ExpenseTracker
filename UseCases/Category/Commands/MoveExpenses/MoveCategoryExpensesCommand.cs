using MediatR;
using UseCases.Category.Dto;

namespace UseCases.Category.Commands.MoveExpenses
{
    public class MoveCategoryExpensesCommand : IRequest
    {
        public MoveCategoryExpensesDto Dto { get; set; } = null!;
    }
}
