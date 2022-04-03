using MediatR;
using UseCases.Account.Dto;

namespace UseCases.Account.Commands.MoveEntries
{
    public class MoveAccountEntriesCommand : IRequest
    {
        public MoveAccountEntriesDto Dto { get; set; } = null!;
    }
}
