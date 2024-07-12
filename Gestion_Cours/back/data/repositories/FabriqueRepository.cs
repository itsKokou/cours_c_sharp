using Gestion_Cours.back.core;
using Gestion_Cours.back.data.enums;
using Gestion_Cours.back.data.repositories.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.repositories
{
    public class FabriqueRepository
    {
        private FabriqueRepository()
        {
        }

        public static IBaseRepository GetInstance(RepositoryName repositoryName)
        {
            IBaseRepository repository = null;
            switch (repositoryName)
            {
                case RepositoryName.UserRepository:
                    repository = UserRepository.GetInstance();
                    break;
                 case RepositoryName.FiliereRepository:
                    repository = FiliereRepository.GetInstance();
                    break;
                 case RepositoryName.ProfesseurRepository:
                    repository = ProfesseurRepository.GetInstance();
                    break;
                 case RepositoryName.SalleRepository:
                    repository = SalleRepository.GetInstance();
                    break;
                 case RepositoryName.ClasseRepository:
                    repository = ClasseRepository.GetInstance();
                    break;
                 case RepositoryName.CoursRepository:
                    repository = CoursRepository.GetInstance();
                    break;
                 case RepositoryName.NiveauRepository:
                    repository = NiveauRepository.GetInstance();
                    break;
                 case RepositoryName.ModuleRepository:
                    repository = ModuleRepository.GetInstance();
                    break;
                default:
                    break;
            }
            return repository;
        }


    }
}
