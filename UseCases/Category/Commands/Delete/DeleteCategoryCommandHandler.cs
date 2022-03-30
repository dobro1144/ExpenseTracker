using Infrastructure.Interfaces.DataAccess;
using UseCases.Base.Commands.Delete;

namespace UseCases.Category.Commands.Delete
{
    public class DeleteCategoryCommandHandler : DeleteEntityCommandHandler<DeleteCategoryCommand, Entities.Models.Category>
    {
        public DeleteCategoryCommandHandler(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
