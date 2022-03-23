using AutoMapper;
using Infrastructure.Interfaces;
using UseCases.Base.Queries.GetById;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Queries.GetById
{
    public class GetExpenseByIdQueryHandler : GetEntityByIdQueryHandler<GetExpenseByIdQuery, ExpenseDto, Entities.Models.Expense>
    {
        public GetExpenseByIdQueryHandler(IReadDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
