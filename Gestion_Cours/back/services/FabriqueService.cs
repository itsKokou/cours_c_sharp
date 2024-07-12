using Gestion_Cours.back.core;
using Gestion_Cours.back.data.enums;
using Gestion_Cours.back.data.repositories;
using Gestion_Cours.back.data.repositories.impl;
using Gestion_Cours.back.services.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.services
{
    public class FabriqueService
    {
        private FabriqueService() { }

        public static IBaseService GetInstance(ServiceName serviceName)
        {
            IBaseService service = null;
            switch (serviceName)
            {
                case ServiceName.UserService:
                    service = UserService.GetInstance((IUserRepository)FabriqueRepository.GetInstance(RepositoryName.UserRepository));
                    break;
                case ServiceName.ProfesseurService:
                    service = ProfesseurService.GetInstance((IProfesseurRepository)FabriqueRepository.GetInstance(RepositoryName.ProfesseurRepository));
                    break;
                case ServiceName.SalleService:
                    service = SalleService.GetInstance((ISalleRepository)FabriqueRepository.GetInstance(RepositoryName.SalleRepository));
                    break;
                case ServiceName.ClasseService:
                    service = ClasseService.GetInstance(
                        (IClasseRepository)FabriqueRepository.GetInstance(RepositoryName.ClasseRepository),
                        (INiveauRepository)FabriqueRepository.GetInstance(RepositoryName.NiveauRepository),
                        (IFiliereRepository)FabriqueRepository.GetInstance(RepositoryName.FiliereRepository));
                    break;
                case ServiceName.CoursService:
                    service = CoursService.GetInstance(
                        (ICoursRepository)FabriqueRepository.GetInstance(RepositoryName.CoursRepository),
                        (ISalleService)GetInstance(ServiceName.SalleService));
                    break;
                case ServiceName.ModuleService:
                    service = ModuleService.GetInstance((IModuleRepository)FabriqueRepository.GetInstance(RepositoryName.ModuleRepository));
                    break;
                default:
                    break;
            }
            return service;
        }
    }
}
