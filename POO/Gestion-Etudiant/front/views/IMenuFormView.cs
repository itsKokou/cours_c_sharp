using Gestion_Etudiant.back.data.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.front.views
{
    public interface IMenuFormView:IView
    {
        event EventHandler showViewClasse;

        UserDto UserConnectDto { get; set; }


     
    }
}
