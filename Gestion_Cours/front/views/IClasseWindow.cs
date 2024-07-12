using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Cours.front.views
{
    public interface IClasseWindow
    {
        string Message { get; set; }//nom du prof
        void ShowWindow();
        void setEnseignementBindingSource(BindingSource enseignementList);
    }
}
