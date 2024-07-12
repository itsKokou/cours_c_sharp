using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Cours.front.views
{
    public interface IModuleWindow
    {
        string Message { get; set; }//nom de la classe
        void ShowWindow();
        void setModuleBindingSource(BindingSource moduleList);

    }
}
