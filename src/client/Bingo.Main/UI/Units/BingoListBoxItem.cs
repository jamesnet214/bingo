using Bingo.Core.Models;
using Bingo.Main.Local.Event;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Bingo.Main.UI.Units
{
		public class BingoListBoxItem : ListBoxItem
		{
				static BingoListBoxItem()
				{
						DefaultStyleKeyProperty.OverrideMetadata (typeof (BingoListBoxItem), new FrameworkPropertyMetadata (typeof (BingoListBoxItem)));
				}
				private bool _isDragItem;
				public BingoListBoxItem()
				{
						Drop += BingoListBoxItem_Drop;
						DataContextChanged += BingoListBoxItem_DataContextChanged;
						;
				}

				private void BingoListBoxItem_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
				{
						if (DataContext is BingoItem data)
						{
								_isDragItem = !String.IsNullOrEmpty(data.Name);
						}
				}

				protected override void OnMouseMove(MouseEventArgs e)
				{
						base.OnMouseMove (e);

						if (e.LeftButton == MouseButtonState.Pressed)
						{
								var data = new DataObject ();
								data.SetData ("MyCustomFormat", this);
								DragDrop.DoDragDrop ((DependencyObject)this, data, DragDropEffects.Move);
						}
				}

				public static readonly DependencyProperty DropCommandProperty =
				   DependencyProperty.Register (
					   "DropCommand",
					   typeof (ICommand),
					   typeof (BingoListBoxItem),
					   new PropertyMetadata (null));
				public ICommand DropCommand
				{
						get { return (ICommand)GetValue (DropCommandProperty); }
						set { SetValue (DropCommandProperty, value); }
				}

				private void BingoListBoxItem_Drop(object sender, DragEventArgs e)
				{
						var droppedObject = e.Data.GetData ("MyCustomFormat") as BingoListBoxItem;
						if (!droppedObject.Equals (this))
						{
								var Targetobejct = this.DataContext as BingoItem;

								BingoEventArgs args = new BingoEventArgs ();
								args.DropItem = droppedObject.DataContext as BingoItem;
								args.TargetItem = Targetobejct;
								this.DataContext = args.DropItem;
								DropCommand?.Execute (args);
						}

				}
		}
}
