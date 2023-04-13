using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bingo.Core.Models;
public class BingoItem : INotifyPropertyChanged
{
	private string? _name;

	private bool _isChecked;

	private bool _isInBingoLine;

	public BingoItem()
	{
	}

	public BingoItem(string name)
	{
		_name = name;
	}

	/// <summary>
	/// 아이템의 이름을 가져오거나 설정합니다.
	/// </summary>
	public string? Name
	{
		get => _name;
		set { _name = value; OnPropertyChanged(); }
	}

	/// <summary>
	/// 아이템이 체크되었는지 여부를 가져오거나 설정합니다.
	/// </summary>
	public bool IsChecked
	{
		get => _isChecked;
		set { _isChecked = value; OnPropertyChanged(); }
	}

	/// <summary>
	/// 아이템이 위치한 줄이 모두 체크되었는지 여부를 가져오거나 설정합니다. (UI 업데이트용)
	/// </summary>
	public bool IsInBingoLine
	{
		get => _isInBingoLine;
		internal set { _isInBingoLine = value; OnPropertyChanged(); }
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new(propertyName));
	}
}
