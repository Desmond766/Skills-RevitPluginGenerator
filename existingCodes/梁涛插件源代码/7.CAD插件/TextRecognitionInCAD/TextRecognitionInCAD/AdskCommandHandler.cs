using Autodesk.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TextRecognitionInCAD
{
    public class AdskCommandHandler : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            RibbonButton ribBtn = parameter as RibbonButton;
            if (ribBtn != null)
            {
                //execute the command 
                Autodesk.AutoCAD.ApplicationServices.Application
                  .DocumentManager.MdiActiveDocument
                  .SendStringToExecute(
                     (string)ribBtn.CommandParameter, true, false, true);
            }
        }
    }
}
