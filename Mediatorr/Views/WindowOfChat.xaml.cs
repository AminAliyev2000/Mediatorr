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
using System.Windows.Shapes;

namespace Mediatorr.Views
{
    /// <summary>
    /// Interaction logic for WindowOfChat.xaml
    /// </summary>
    public partial class WindowOfChat : Window
    {
        public WindowOfChat()
        {
            InitializeComponent();
            TxtBxMessage.Focus();
        }
    }
}
