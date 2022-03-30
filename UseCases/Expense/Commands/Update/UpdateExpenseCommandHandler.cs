using AutoMapper;
using Infrastructure.Interfaces.DataAccess;
using UseCases.Base.Commands.Update;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Commands.Update
{
    public class UpdateExpenseCommandHandler : UpdateEntityCommandHandler<UpdateExpenseCommand, UpdateExpenseDto, Entities.Models.Expense>
    {
        public UpdateExpenseCommandHandler(IDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
