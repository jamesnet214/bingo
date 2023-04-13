using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Bingo.Core.Models;
public class BingoItemCollection : ObservableCollection<BingoItem>
{
	private int _goal;

	private int _numOfLine;

	private int _numOfBingoLine;

	/// <summary>
	/// 목표 줄 수를 가져오거나 설정합니다.
	/// </summary>
	public int Goal
	{
		get => _goal;
		set
		{
			_goal = value;
			Update();
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// 가로/세로 줄의 수를 가져오거나 설정합니다.
	/// </summary>
	public int NumOfLine
	{
		get => _numOfLine;
		set
		{
			_numOfLine = value;
			Update();
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// 현재 지운 줄의 수를 가져오거나 설정합니다.
	/// </summary>
	public int NumOfBingoLine
	{
		get => _numOfBingoLine;
		private set
		{
			_numOfBingoLine = value;
			OnPropertyChanged();
			OnPropertyChanged(nameof(IsBingo));
		}
	}

	/// <summary>
	/// 목표를 모두 달성했는지 여부를 가져옵니다.
	/// </summary>
	public bool IsBingo => _numOfBingoLine >= _goal;

	/// <summary>
	/// 빙고 여부를 업데이트합니다.
	/// </summary>
	/// <exception cref="InvalidOperationException">컬렉션에 있는 아이템의 수가 지정된 줄 수와 일치하지 않습니다. 아이템 수는 지정된 줄 수의 제곱수여야 합니다.</exception>
	public void Update()
	{
		if (Count == 0 || NumOfLine == 0)
		{
			return;
		}
		
		if (Count != Math.Pow(NumOfLine, 2))
		{
			throw new InvalidOperationException();
		}

		int numOfBingo = 0;
		var items = Items;

		void CheckLines(IEnumerable<IEnumerable<BingoItem>> lines)
		{
			foreach (var line in lines.Where(line => !line.Any(cell => !cell.IsChecked)))
			{
				foreach (var cell in line)
				{
					cell.IsInBingoLine = true;
				}
				++numOfBingo;
			}
		}

		CheckLines(items.Chunk(_numOfLine));
		CheckLines(ChunkRows(items, _numOfLine));
		CheckLines(ChunkDiagonals(items, _numOfLine));

		NumOfBingoLine = numOfBingo;
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		UnregisterEvents(e.OldItems?.OfType<BingoItem>());
		RegisterEvents(e.NewItems?.OfType<BingoItem>());

		Update();

		base.OnCollectionChanged(e);
	}

	private static IEnumerable<IEnumerable<BingoItem>> ChunkRows(IEnumerable<BingoItem> items, int numOfLine)
	{
		return items.Select((item, index) => new { Item = item, Index = index }).
					 GroupBy(cell => cell.Index % numOfLine).
					 Select(row => row.Select(cell => cell.Item));
	}

	private static IEnumerable<IEnumerable<BingoItem>> ChunkDiagonals(IEnumerable<BingoItem> items, int numOfLine)
	{
		if (numOfLine % 2 == 0)
		{
			yield break;
		}

		var cursors = Enumerable.Range(0, numOfLine);

		yield return cursors.Select(cursor => items.ElementAt(cursor * numOfLine + cursor));
		yield return cursors.Select(cursor => items.ElementAt((cursor + 1) * (numOfLine - 1)));
	}

	private void RegisterEvents(IEnumerable<BingoItem>? items)
	{
		if (items?.Any() is not true)
		{
			return;
		}

		foreach (var item in items)
		{
			item.PropertyChanged += OnItemPropertyChanged;
		}
	}

	private void UnregisterEvents(IEnumerable<BingoItem>? items)
	{
		if (items?.Any() is not true)
		{
			return;
		}

		foreach (var item in items)
		{
			item.PropertyChanged -= OnItemPropertyChanged;
		}
	}

	private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
	}

	private void OnItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == nameof(BingoItem.IsChecked))
		{
			Update();
		}
	}
}
