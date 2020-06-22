namespace NETCore_MVC_Water_Company.Web.Data
{
    using NETCore_MVC_Water_Company.Web.Data.Entities;

    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(DataContext context) : base(context)
        {

        }
    }
}
