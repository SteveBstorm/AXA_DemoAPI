using Axa_DemoAPI_Domain.Entities;

namespace AXA_DemoAPI_DAL.Abstractions
{
    public interface IClientRepository
    {
        List<Client> GetAll();
        Client GetById(int id);
        void Insert(Client c);
    }
}