using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.presenter
{
    public interface ICoursAddPagePresenter
    {
        void LoadData();//charger les données de la vue
        void AjouterCoursHandler(object sender, EventArgs e);//sender : btn qui a appelé
        void SelectModuleHandler(object sender, EventArgs e);
        void SelectProfesseurHandler(object sender, EventArgs e);
        void SelectClassesHandler(object sender, EventArgs e);
        void SelectSalleHandler(object sender, EventArgs e);//fermer codeCours
        void SaisieCodeHandler(object sender, EventArgs e);//retirer les elements de salle
        void SelectDateHandler(object sender, EventArgs e);
        void SelectHeureDebutHandler(object sender, EventArgs e);
        void SelectHeureFinHandler(object sender, EventArgs e);
        void ActiveEventHandler();//Mapper le Handler à celui de la vue(invoke)
    }
}
