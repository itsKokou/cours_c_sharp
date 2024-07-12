using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.presenter
{
    public interface IClassePagePresenter
    {
        void LoadData();//charger les données de la vue
        void AjouterClasseHandler(object sender, EventArgs e);//sender : btn qui a appelé
        void SelectClasseHandler(object sender, EventArgs e);//sender : btn qui a appelé
        void EditClasseHandler(object sender, EventArgs e);
        void DeleteClasseHandler(object sender, EventArgs e);
        void FiltreHandler(object sender, EventArgs e);
        void VoirModulesHandler(object sender, EventArgs e);
        void ActiveEventHandler();//Mapper le Handler à celui de la vue(invoke)
    }
}
