using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;

namespace Bingo.LayoutSupport.Behaviors;
public class DragDropAdorner : Adorner
{
	private Brush _visualBrush;

	private Point _currentLocation;

	private Point _startLocation;

	public DragDropAdorner(UIElement adornedElement, Point startLocation) : base(adornedElement)
	{
		_startLocation = startLocation;
		_visualBrush = new VisualBrush(AdornedElement)
		{
			Opacity = .7
		};
		IsHitTestVisible = false;
	}

	public void UpdatePosition(Point location)
	{
		_currentLocation = location;

		InvalidateVisual();
	}

	protected override void OnRender(DrawingContext dc)
	{
		var p = _currentLocation;
		p.Offset(-_startLocation.X, -_startLocation.Y);

		dc.DrawRectangle(_visualBrush, null, new Rect(p, RenderSize));
	}
}
