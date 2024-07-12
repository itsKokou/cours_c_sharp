using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gestion_Cours.front.views
{
    public interface IPage
    {
        MessageBoxImage Icone { get; set; }


        event EventHandler ClickBtnClasseEvent;
        event EventHandler ClickBtnModuleEvent;
        event EventHandler ClickBtnSalleEvent;
        event EventHandler ClickBtnCoursEvent;
        event EventHandler ClickBtnProfesseurEvent;
        event EventHandler ClickBtnLogoutEvent;
    }
}
