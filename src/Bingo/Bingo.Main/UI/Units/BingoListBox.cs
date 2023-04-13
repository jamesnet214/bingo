using System.Windows;
using System.Windows.Controls;

namespace Bingo.Main.UI.Units
{
		public class BingoListBox : ListBox
		{


				public int Columns
				{
						get { return (int)GetValue (ColumnsProperty); }
						set { SetValue (ColumnsProperty, value); }
				}

				// Using a DependencyProperty as the backing store for Columns.  This enables animation, styling, binding, etc...
				public static readonly DependencyProperty ColumnsProperty =
					DependencyProperty.Register ("Columns", typeof (int), typeof (BingoListBox), new PropertyMetadata (0));


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
