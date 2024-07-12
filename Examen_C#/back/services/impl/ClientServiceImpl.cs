using Examen_C_.back.data.entities;
using Examen_C_.back.data.repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_C_.back.services.impl
{
    public class ClientServiceImpl : IClientService
    {
        private readonly IClientRepository clientRepository;

        public ClientServiceImpl(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public Client getClientByPortable(string portable)
        {
            Client client = null;
            DataTable dataTable =  clientRepository.findClientByPortable(portable);
            foreach (DataRow row in dataTable.Rows)
            {
                client = new Client() 
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Nom = row.ItemArray[1].ToString(),
                    Prenom = row.ItemArray[2].ToString(),
                    Portable = row.ItemArray[3].ToString()
                };
            }

            return client;
        }
    }
}
