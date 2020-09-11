namespace NETCore_MVC_Water_Company.Web.Data.Repositories
{
    using NETCore_MVC_Water_Company.Web.Data.Entities;
    using System.Linq;

    public interface IWaterMeterRepository : IGenericRepository<WaterMeter>
    {
        IQueryable GetAllWithUsers();
    }
}
