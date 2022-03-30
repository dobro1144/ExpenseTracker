using AutoMapper;
using Infrastructure.Interfaces;
using System;
using UseCases.Base.Commands.Create;
using UseCases.Income.Dto;

namespace UseCases.Income.Commands.Create
{
    public class CreateIncomeCommandHandler : CreateEntityCommandHandler<CreateIncomeCommand, CreateIncomeDto, IncomeDto, Entities.Models.Income>
    {
        public CreateIncomeCommandHandler(IDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        protected override void InitializeNewEntity(Entities.Models.Income entity)
        {
            entity.CreatedAtUtc = DateTime.UtcNow;
        }
    }
}
