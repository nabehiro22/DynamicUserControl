using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Windows;

namespace DynamicUserControl.ViewModels
{
	public class ControlViewModel : BindableBase, INotifyPropertyChanged, IDisposable
	{

		/// <summary>
		/// 表示する上からの位置
		/// </summary>
		public ReactivePropertySlim<double> Top { get; } = new ReactivePropertySlim<double>();

		/// <summary>
		/// 表示する左からの位置
		/// </summary>
		public ReactivePropertySlim<double> Left { get; } = new ReactivePropertySlim<double>();

		/// <summary>
		/// ボタンが押された時
		/// </summary>
		public ReactiveCommand ClickCommand { get; } = new ReactiveCommand();

		/// <summary>
		/// Disposeが必要な処理をまとめてやる
		/// </summary>
		private CompositeDisposable Disposable { get; } = new CompositeDisposable();

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="top">メインウィンドウ表示するTopからの座標</param>
		/// <param name="left">メインウィンドウ表示するLeftからの座標</param>
		public ControlViewModel(double top , double left)
		{
			// これで表示する座標を決める
			Top.Value = top;
			Left.Value = left;

			_ = ClickCommand.Subscribe(_ => MessageBox.Show($"test{Top.Value},{Left.Value}")).AddTo(Disposable);
		}

		public void Dispose()
		{
			Disposable.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
