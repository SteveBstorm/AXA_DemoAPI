using AXA_DemoAPI_BLL.Abstractions;
using AXA_DemoAPI_DAL.Abstractions;
using Axa_DemoAPI_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXA_DemoAPI_BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }

        public Client GetById(int id)
        {
            return _clientRepository.GetById(id);
        }

        public void Insert(Client c)
        {
            _clientRepository.Insert(c);
        }
    }
}
