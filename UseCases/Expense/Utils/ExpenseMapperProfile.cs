using AutoMapper;
using UseCases.Expense.Dto;

namespace UseCases.Expense.Utils
{
    public class ExpenseMapperProfile : Profile
    {
        public ExpenseMapperProfile()
        {
            CreateMap<Entities.Models.Expense, ExpenseDto>();
            CreateMap<CreateExpenseDto, Entities.Models.Expense>();
            CreateMap<UpdateExpenseDto, Entities.Models.Expense>();
        }
    }
}
