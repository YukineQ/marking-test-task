using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;

using marking_test_task.ViewModel;

namespace marking_test_task.View
{
    public partial class CurrentTaskView : UserControl
    {
        public CurrentTaskView()
        {
            InitializeComponent();
            DataContext = Program.ServiceProvider.GetService<CurrentTaskViewModel>();
        }
    }
}