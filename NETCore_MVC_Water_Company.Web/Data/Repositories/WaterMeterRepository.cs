namespace NETCore_MVC_Water_Company.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using NETCore_MVC_Water_Company.Web.Data.Entities;
    using System.Linq;

    public class WaterMeterRepository : GenericRepository<WaterMeter>, IWaterMeterRepository
    {
        readonly DataContext _context;

        public WaterMeterRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return _context.WaterMeters.Include(w => w.User);
        }
    }
}
