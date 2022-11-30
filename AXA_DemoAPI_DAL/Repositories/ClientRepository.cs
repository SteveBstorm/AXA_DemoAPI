using AXA_DemoAPI_DAL.Abstractions;
using Axa_DemoAPI_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AXA_DemoAPI_DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private List<Client> clients;
        private int currentId = 0;

        public ClientRepository()
        {
            clients = new List<Client>();
            clients.Add(new Client
            {
                Email = "arthur@mail.com",
                Lastname = "Pendragon",
                Firstname = "Arthur",
                ID = currentId++,
            });
            clients.Add(new Client
            {
                Email = "merlin@mail.com",
                Lastname = "L'enchanteur",
                Firstname = "Merlin",
                ID = currentId++,
            });
        }

        public List<Client> GetAll()
        {
            return clients;
        }

        public Client GetById(int id)
        {
            return clients.FirstOrDefault(c => c.ID == id);
        }

        public void Insert(Client c)
        {
            c.ID = currentId++;
            clients.Add(c);
        }


    }
}
