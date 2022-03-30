using AutoMapper;
using Infrastructure.Interfaces.DataAccess;
using System;
using UseCases.Base.Commands.Create;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Commands.Create
{
    public class CreateExpenseCommandHandler : CreateEntityCommandHandler<CreateExpenseCommand, CreateExpenseDto, ExpenseDto, Entities.Models.Expense>
    {
        public CreateExpenseCommandHandler(IDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        protected override void InitializeNewEntity(Entities.Models.Expense entity)
        {
            entity.CreatedAtUtc = DateTime.UtcNow;
        }
    }
}
