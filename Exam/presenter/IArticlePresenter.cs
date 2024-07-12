using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.presenter
{
    public interface IArticlePresenter
    {
        void LoadData();
        void ClickBtnAddHandler(object sender, EventArgs e);
        void ClickBtnEnregistrerHandler(object sender, EventArgs e);
        void FiltreClientHandler(object sender, EventArgs e);
        void FiltreArticleHandler(object sender, EventArgs e);

    }
}
