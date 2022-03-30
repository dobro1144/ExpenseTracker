using Infrastructure.Interfaces.Services;

namespace Server.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(/*IHttpContextAccessor httpContextAccessor*/)
        {
            Id = 1;
        }

        public int Id { get; }
    }
}
