using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;

using marking_test_task.ViewModel;

namespace marking_test_task.View
{
    /// <summary>
    /// Логика взаимодействия для PalleteView.xaml
    /// </summary>
    public partial class PalleteView : UserControl
    {
        public PalleteView()
        {
            InitializeComponent();
            DataContext = Program.ServiceProvider.GetService<PalleteViewModel>();
        }
    }
}
