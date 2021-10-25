# DynamicUserControl<br>
MainWindowViewModelで生成されたユーザーコントロールのインスタンスはCompositeDisposableにAddToされる。<br>
ユーザーコントロールはIDisposableを継承している。<br>
ユーザーコントロールで破棄されるべきReactiveCommand等はユーザーコントロールのコンストラクタでCompositeDisposableにAddToされる。<br>
メインウインドウが閉じる時、MainWindowViewModelにあるCompositeDisposableがDispose()され、ユーザーコントロールが破棄される。<br>
その時にユーザーコントロールのDispose()が呼び出されユーザーコントロールのReactiveCommand等が破棄される。<br>
解説は  
https://www.nabehiro.net/2021/10/wpf-prism-dynamic-usercontrol.html
