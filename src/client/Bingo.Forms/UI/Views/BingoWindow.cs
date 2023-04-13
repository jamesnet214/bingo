using Jamesnet.Wpf.Controls;
using System.Windows;

namespace Bingo.Forms.UI.Views
{
    public class BingoWindow : JamesWindow
    {
        static BingoWindow()  
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BingoWindow), new FrameworkPropertyMetadata(typeof(BingoWindow)));
        }

        public BingoWindow()
        {
        }
    }
}
