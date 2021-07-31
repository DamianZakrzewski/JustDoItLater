using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JustDoItLater.Model;
using JustDoItLater.ViewModels;

namespace JustDoItLater.UserControls
{
    /// <summary>
    /// Interaction logic for TDViewControl.xaml
    /// </summary>
    public partial class TDViewControl : UserControl
    {
        public ToDo ToDo { get; }
        public TDViewControl(ToDo toDo)
        {
            InitializeComponent();
            ToDo = toDo;
            DataContext = ToDo;
        }
    }
}
