using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.presenter
{
    public interface IClasseAddPagePresenter
    {
        void LoadData();//charger les données de la vue
        void AjouterClasseHandler(object sender, EventArgs e);//sender : btn qui a appelé
        void SelectFiliereHandler(object sender, EventArgs e);//sender : btn qui a appelé
        void ActiveEventHandler();//Mapper le Handler à celui de la vue(invoke)
    }
}
