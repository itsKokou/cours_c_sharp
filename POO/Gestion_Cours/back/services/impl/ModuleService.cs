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
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository moduleRepository;

        public ModuleService(IModuleRepository moduleRepository)
        {
            this.moduleRepository = moduleRepository;
        }

        public int add(Module entity)
        {
            return moduleRepository.insert(entity);
        }

        public int archivate(int id)
        {
            return moduleRepository.archivate(id);  
        }

        public Module findById(int id)
        {
            return moduleRepository.findById(id);   
        }

        public List<Module> getAll()
        {
            List<Module> modules = new List<Module>();
            DataTable dataTable = moduleRepository.findAll();
            foreach (DataRow row in dataTable.Rows)
            {
                modules.Add(new Module()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Name = row.ItemArray[1].ToString(),
                    IsArchived = Convert.ToBoolean(row.ItemArray[2])
                });
            }
            return modules;
        }

        public int update(Module entity)
        {
           return moduleRepository.update(entity);
        }
    }
}
