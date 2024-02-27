using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace marking_test_task.Services
{
    public class DialogService: IDialogService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public string FilePath { get; set; }
        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == false)
            {
                return false;
            }

            FilePath = openFileDialog.FileName;
            return true;
        }

        public bool SaveFileDialog() 
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == false)
            {
                return false;
            }

            FilePath = saveFileDialog.FileName;
            return true;
        }
    }
}
