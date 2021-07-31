using System;
using System.Windows.Controls;
using JustDoItLater.Enums;

namespace JustDoItLater.UserControls
{
    /// <summary>
    /// Interaction logic for ViewControl.xaml
    /// </summary>
    public partial class ViewControl : UserControl
    {
        public ViewControl()
        {
            InitializeComponent();
            States.ItemsSource = Enum.GetValues(typeof(ToDoState));
        }
    }
}