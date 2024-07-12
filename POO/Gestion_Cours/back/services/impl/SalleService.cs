using Gestion_Cours.back.data.entities;
using Gestion_Cours.back.data.repositories;
using Gestion_Cours.back.data.repositories.impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.services.impl
{
    public class SalleService : ISalleService
    {
        private readonly ISalleRepository salleRepository;

        public SalleService(ISalleRepository salleRepository)
        {
            this.salleRepository = salleRepository;
        }

        public int add(Salle entity)
        {
            return salleRepository.insert(entity);
        }

        public int archivate(int id)
        {
            return salleRepository.archivate(id);
        }

        public Salle findById(int id)
        {
            return salleRepository.findById(id);
        }

        public List<Salle> getAll()
        {
            List<Salle> salles = new List<Salle>();
            DataTable dataTable = salleRepository.findAll();
            foreach (DataRow row in dataTable.Rows)
            {
                salles.Add(new Salle()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Name = row.ItemArray[1].ToString(),
                    NbrePlace = int.Parse(row.ItemArray[2].ToString()),
                    IsArchived = Convert.ToBoolean(row.ItemArray[3]),     
               });
            }
            return salles;
        }

        public int update(Salle entity)
        {
            return salleRepository.update(entity);
        }
    }
}
