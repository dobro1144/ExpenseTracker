using Infrastructure.Interfaces;
using UseCases.Base.Commands.Delete;

namespace UseCases.Expense.Commands.Delete
{
    public class DeleteExpenseCommandHandler : DeleteEntityCommandHandler<DeleteExpenseCommand, Entities.Models.Expense>
    {
        public DeleteExpenseCommandHandler(IDbContext<Entities.Models.Expense> dbContext) : base(dbContext)
        {
        }

        protected override Entities.Models.Expense CreateEntity(int id, byte[] timestamp)
        {
            return new Entities.Models.Expense {
                Id = id,
                Timestamp = timestamp
            };
        }
    }
}
