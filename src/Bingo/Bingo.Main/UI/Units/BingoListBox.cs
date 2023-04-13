using System.Windows;
using System.Windows.Controls;

namespace Bingo.Main.UI.Units
{
		public class BingoListBox : ListBox
		{
				static BingoListBox()
				{
						DefaultStyleKeyProperty.OverrideMetadata (typeof (BingoListBox), new FrameworkPropertyMetadata (typeof (BingoListBox)));
				}

				protected override DependencyObject GetContainerForItemOverride()
				{
						return new BingoListBoxItem ();
				}
		}
}
