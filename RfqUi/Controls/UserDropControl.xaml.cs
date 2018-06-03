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

namespace RfqUi.Controls
{
    /// <summary>
    /// Interaction logic for UserDropControl.xaml
    /// </summary>
    public partial class UserDropControl : UserControl
    {
        public UserDropControl()
        {
            InitializeComponent();
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Button btn = e.Source as Button;

            if (e.LeftButton == MouseButtonState.Pressed)
                DragDrop.DoDragDrop(btn, btn.Content, DragDropEffects.Copy);
        }

        private void Button_Drop(object sender, DragEventArgs e)
        {
            string draggedText = (string)e.Data.GetData(DataFormats.StringFormat);

            Button toButton = e.Source as Button;
            toButton.Content = draggedText;
        }

        private void Label_Drop(object sender, DragEventArgs e)
        {
            string draggedText = (string)e.Data.GetData(DataFormats.StringFormat);

            Button toButton = e.Source as Button;
            toButton.Content = draggedText;
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Label lblFrom = e.Source as Label;

            if (e.LeftButton == MouseButtonState.Pressed)
                DragDrop.DoDragDrop(lblFrom, lblFrom.Content, DragDropEffects.Copy);
        }
    }
}
