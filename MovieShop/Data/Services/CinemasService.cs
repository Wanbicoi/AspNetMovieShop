using MovieShop.Data.Base;
using MovieShop.Models;

namespace MovieShop.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(ApplicationDbContext context) : base(context) { }
    }
}
