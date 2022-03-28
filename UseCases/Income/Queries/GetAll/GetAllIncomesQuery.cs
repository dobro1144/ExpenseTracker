using UseCases.Base.Queries.GetAll;
using UseCases.Income.Dto;

namespace UseCases.Income.Queries.GetAll
{
    public class GetAllIncomesQuery : GetAllEntitiesQuery<GetAllIncomesQueryDto, IncomeDto>
    {
    }
}
