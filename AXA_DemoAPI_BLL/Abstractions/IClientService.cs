using Axa_DemoAPI_Domain.Entities;

namespace AXA_DemoAPI_BLL.Abstractions
{
    public interface IClientService
    {
        List<Client> GetAll();
        Client GetById(int id);
        void Insert(Client c);
    }
}