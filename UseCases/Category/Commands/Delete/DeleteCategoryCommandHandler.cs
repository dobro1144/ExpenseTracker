using Infrastructure.Interfaces;
using UseCases.Base.Commands.Delete;

namespace UseCases.Category.Commands.Delete
{
    public class DeleteCategoryCommandHandler : DeleteEntityCommandHandler<DeleteCategoryCommand, Entities.Models.Category>
    {
        public DeleteCategoryCommandHandler(IDbContext dbContext) : base(dbContext)
        {
        }

        protected override Entities.Models.Category CreateEntity(int id, byte[] timestamp)
        {
            return new Entities.Models.Category {
                Id = id,
                Timestamp = timestamp
            };
        }
    }
}
