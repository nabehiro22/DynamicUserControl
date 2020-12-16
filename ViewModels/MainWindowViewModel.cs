using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive.Disposables;

namespace DynamicUserControl.ViewModels
{
	public class MainWindowViewModel : BindableBase, INotifyPropertyChanged
	{
		/// <summary>
		/// タイトル
		/// </summary>
		public ReactivePropertySlim<string> Title { get; } = new ReactivePropertySlim<string>("Dynamic UserControl");

		/// <summary>
		/// Disposeが必要な処理をまとめてやる
		/// </summary>
		private CompositeDisposable Disposable { get; } = new CompositeDisposable();

		/// <summary>
		/// MainWindowのCloseイベント
		/// </summary>
		public ReactiveCommand ClosedCommand { get; } = new ReactiveCommand();

		/// <summary>
		/// 動的ユーザコントロールのリスト
		/// </summary>
		public ObservableCollection<ControlViewModel> ControlList { get; } = new ObservableCollection<ControlViewModel>();

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainWindowViewModel()
		{
			var c1 = new ControlViewModel(50, 50);
			_ = c1.AddTo(Disposable);
			ControlList.Add(c1);
			var c2 = new ControlViewModel(50, 150);
			_ = c2.AddTo(Disposable);
			ControlList.Add(c2);

			_ = ClosedCommand.Subscribe(Close).AddTo(Disposable);
		}

		/// <summary>
		/// アプリが閉じられる時
		/// </summary>
		private void Close()
		{
			Disposable.Dispose();
		}
	}
}
