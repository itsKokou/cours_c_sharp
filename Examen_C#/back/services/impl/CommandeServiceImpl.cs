using Examen_C_.back.data.entities;
using Examen_C_.back.data.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_C_.back.services.impl
{
    public class CommandeServiceImpl : ICommandeService
    {
        private readonly ICommandeRepository commandeRepository;

        public CommandeServiceImpl(ICommandeRepository commandeRepository)
        {
            this.commandeRepository = commandeRepository;
        }

        public int save(Commande commande)
        {
            return commandeRepository.insert(commande);
        }
    }
}
