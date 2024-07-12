using Exam.back.data.entities;
using Exam.back.data.repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Exam.back.services.impl
{
    internal class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public Client getByPortable(string portable)
        {
            Client client = null;
            DataTable dataTable = clientRepository.findByPortable(portable);
            foreach (DataRow row in dataTable.Rows)
            {
                client = new Client()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Nom = row.ItemArray[1].ToString(),
                    Prenom = row.ItemArray[2].ToString(),
                    Portable = row.ItemArray[3].ToString(),
                };
            }
            return client;
        }
    }
}
