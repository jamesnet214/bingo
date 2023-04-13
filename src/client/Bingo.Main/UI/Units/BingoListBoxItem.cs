using System.Windows;
using System.Windows.Controls;

namespace Bingo.Main.UI.Units
{
		public class BingoListBoxItem : ListBoxItem
		{
				static BingoListBoxItem()
				{
						DefaultStyleKeyProperty.OverrideMetadata (typeof (BingoListBoxItem), new FrameworkPropertyMetadata (typeof (BingoListBoxItem)));
				}
		}
}
