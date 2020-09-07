namespace NETCore_MVC_Water_Company.Web.Data
{
    using NETCore_MVC_Water_Company.Web.Data.Entities;

    public class WaterMeterRepository : GenericRepository<WaterMeter>, IWaterMeterRepository
    {
        public WaterMeterRepository(DataContext context) : base(context)
        {

        }
    }
}
