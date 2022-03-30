using Infrastructure.Interfaces.DataAccess;
using UseCases.Base.Commands.Delete;

namespace UseCases.User.Commands.Delete
{
    public class DeleteUserCommandHandler : DeleteEntityCommandHandler<DeleteUserCommand, Entities.Models.User>
    {
        public DeleteUserCommandHandler(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
