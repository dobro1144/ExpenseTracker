using Infrastructure.Interfaces.DataAccess;
using UseCases.Base.Commands.Delete;

namespace UseCases.Income.Commands.Delete
{
    public class DeleteIncomeCommandHandler : DeleteEntityCommandHandler<DeleteIncomeCommand, Entities.Models.Income>
    {
        public DeleteIncomeCommandHandler(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
