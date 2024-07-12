using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.presenter
{
    public interface IModulePagePresenter
    {

        void LoadData();//charger les données de la vue
        void AjouterModuleHandler(object sender, EventArgs e);//sender : btn qui a appelé
        void SelectModuleHandler(object sender, EventArgs e);//sender : btn qui a appelé
        void EditModuleHandler(object sender, EventArgs e);
        void DeleteModuleHandler(object sender, EventArgs e);
        void ActiveEventHandler();//Mapper le Handler à celui de la vue(invoke)
    }
}
