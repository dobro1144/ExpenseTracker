using AutoMapper;
using Infrastructure.Interfaces.DataAccess;
using UseCases.Base.Commands.Update;
using UseCases.Income.Dto;

namespace UseCases.Income.Commands.Update
{
    public class UpdateIncomeCommandHandler : UpdateEntityCommandHandler<UpdateIncomeCommand, UpdateIncomeDto, Entities.Models.Income>
    {
        public UpdateIncomeCommandHandler(IDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
