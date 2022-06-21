using Army.Core.DAL;
using Army.Core.DAL.Repositories;
using Army.Core.Infrastructure.Models.Entites;

namespace Meshini.Core.DAL.Repositories
{
    public class CardProductRepository : BaseRepository<CardProduct>
    {
        public CardProductRepository(ArmyTechContext db)
            : base(db)
        {
        }

    }
}
