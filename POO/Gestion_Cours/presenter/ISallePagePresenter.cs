using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.presenter
{
    public interface ISallePagePresenter
    {

        void LoadData();//charger les données de la vue
        void AjouterSalleHandler(object sender, EventArgs e);//sender : btn qui a appelé
        void SelectSalleHandler(object sender, EventArgs e);//sender : btn qui a appelé
        void EditSalleHandler(object sender, EventArgs e);
        void DeleteSalleHandler(object sender, EventArgs e);
        void ActiveEventHandler();//Mapper le Handler à celui de la vue(invoke)
    }
}
