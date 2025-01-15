using Kreta.Backend.Context;
using Kreta.Backend.Repos.Base;
using Kreta.Shared.Models;

namespace Kreta.Backend.Repos
{
    public class SubjectRepo<TDbContext> : BaseRepo<TDbContext, Subject>, ISubjectRepo where TDbContext : KretaContext
    {
        public SubjectRepo(TDbContext? dbContext) : base(dbContext)
        {
        }
    }
}
