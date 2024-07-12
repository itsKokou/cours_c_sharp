using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.presenter
{
    public interface IProfesseurAddPagePresenter
    {
        void LoadData();//charger les données de la vue
        void SaveProfesseurHandler(object sender, EventArgs e);//sender : btn qui a appelé
        void AjouterEnseignementHandler(object sender, EventArgs e);//sender : btn qui a appelé
        void SelectClasseHandler(object sender, EventArgs e);//sender : btn qui a appelé
        void ActiveEventHandler();//Mapper le Handler à celui de la vue(invoke)
    }
}
