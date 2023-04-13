using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Bingo.LayoutSupport.Behaviors;
public class DragDropBehavior : Behavior<ItemsControl>
{
	public enum DragDropMode
	{
		Swap = 0,
		Reorder
	}

	public static readonly DependencyProperty TargetTypeProperty =
		DependencyProperty.Register(nameof(TargetType), typeof(Type), typeof(DragDropBehavior), new PropertyMetadata(default));

	public static readonly DependencyProperty DelayProperty =
		DependencyProperty.Register(nameof(Delay), typeof(int), typeof(DragDropBehavior), new PropertyMetadata(500));

	public static readonly DependencyProperty ModeProperty =
		DependencyProperty.Register(nameof(Mode), typeof(DragDropMode), typeof(DragDropBehavior), new PropertyMetadata(default));

	public Type TargetType
	{
		get { return (Type)GetValue(TargetTypeProperty); }
		set { SetValue(TargetTypeProperty, value); }
	}

	public int Delay
	{
		get { return (int)GetValue(DelayProperty); }
		set { SetValue(DelayProperty, value); }
	}

	public DragDropMode Mode
	{
		get { return (DragDropMode)GetValue(ModeProperty); }
		set { SetValue(ModeProperty, value); }
	}

	private int _dragIndex = -1;

	private Stopwatch _mouseClickTimer = new();

	private DragDropAdorner? _adorner;

	protected override void OnAttached()
	{
		base.OnAttached();

		AssociatedObject.PreviewMouseLeftButtonDown += OnPreviewMouseLeftButtonDown;
		AssociatedObject.PreviewMouseLeftButtonUp += OnPreviewMouseLeftButtonUp;
		AssociatedObject.Drop += OnDrop;
		AssociatedObject.GiveFeedback += OnGiveFeedback;
	}

	protected override void OnDetaching()
	{
		AssociatedObject.PreviewMouseLeftButtonDown -= OnPreviewMouseLeftButtonDown;
		AssociatedObject.PreviewMouseLeftButtonUp -= OnPreviewMouseLeftButtonUp;
		AssociatedObject.Drop -= OnDrop;
		AssociatedObject.GiveFeedback -= OnGiveFeedback;

		base.OnDetaching();
	}

	private static Point GetMousePositionWindowsForms()
	{
		var point = System.Windows.Forms.Control.MousePosition;
		return new Point(point.X, point.Y);
	}

	private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		_mouseClickTimer.Restart();
		int delay = Delay;

		Task.Factory.StartNew(async () =>
		{
			await Task.Delay(delay);
			if (!_mouseClickTimer.IsRunning)
			{
				return;
			}

			Application.Current.Dispatcher.Invoke(() =>
			{
				var temp = FindAncestor((DependencyObject)AssociatedObject.InputHitTest(e.GetPosition(AssociatedObject)));
				if (temp is not null)
				{
					SetDropAction(temp);
				}
			});
		}, CancellationToken.None);
	}

	private void OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
		_mouseClickTimer.Reset();
	}

	private void OnDrop(object sender, DragEventArgs e)
	{
		var target = FindAncestor((DependencyObject)AssociatedObject.InputHitTest(e.GetPosition(AssociatedObject)));
		if (target is null)
		{
			return;
		}

		var itemsSource = AssociatedObject.ItemsSource;

		var list = itemsSource.OfType<object>().ToList();

		var targetIndex = list.IndexOf(target);
		if (targetIndex == -1)
		{
			targetIndex = list.IndexOf(target.DataContext);
		}

		var items = (dynamic)itemsSource;
		dynamic temp;
		switch (Mode)
		{
			case DragDropMode.Swap:
				temp = items[_dragIndex];
				items[_dragIndex] = items[targetIndex];
				items[targetIndex] = temp;
				break;

			case DragDropMode.Reorder:
				temp = items[_dragIndex];
				items.RemoveAt(_dragIndex);
				items.Insert(targetIndex, temp);
				break;
		}
		_dragIndex = -1;
	}

	private void OnGiveFeedback(object sender, GiveFeedbackEventArgs e)
	{
		e.UseDefaultCursors = e.Effects != DragDropEffects.Move;
		_adorner?.UpdatePosition(GetMousePositionWindowsForms());
		e.Handled = true;
	}

	private Control? FindAncestor(DependencyObject obj)
	{
		while (obj is not null)
		{
			if (obj.GetType().Equals(TargetType))
			{
				return (Control)obj;
			}
			obj = VisualTreeHelper.GetParent(obj);
		}

		return null;
	}

	private void SetDropAction(Control control)
	{
		if (control == null)
		{
			return;
		}

		var itemsSource = AssociatedObject.ItemsSource;

		var list = itemsSource.OfType<object>().ToList();
		var dragIndex = list.IndexOf(control.DataContext);
		if (dragIndex == -1)
		{
			dragIndex = list.IndexOf(control);
		}
		_dragIndex = dragIndex;

		SetDropEffect(control);

		DataObject data = new DataObject(TargetType.Name, control, true);
		DragDrop.DoDragDrop(control, data, DragDropEffects.Move);

		UnsetDropEffect(control);
	}

	private void SetDropEffect(Control control)
	{
		control.Effect = new DropShadowEffect
		{
			Color = Color.FromArgb(75, 0, 0, 0),
			ShadowDepth = 0,
			Opacity = .5,
		};

		_adorner = new DragDropAdorner(control, GetMousePositionWindowsForms());
		AdornerLayer.GetAdornerLayer(control)?.Add(_adorner);
		Mouse.SetCursor(Cursors.Hand);
	}

	private void UnsetDropEffect(Control control)
	{
		AdornerLayer.GetAdornerLayer(control)?.Remove(_adorner);
		Mouse.SetCursor(null);
		control.Effect = null;
		_adorner = null;
	}
}
