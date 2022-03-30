using Infrastructure.Interfaces.DataAccess;
using UseCases.Base.Commands.Delete;

namespace UseCases.Account.Commands.Delete
{
    public class DeleteAccountCommandHandler : DeleteEntityCommandHandler<DeleteAccountCommand, Entities.Models.Account>
    {
        public DeleteAccountCommandHandler(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
