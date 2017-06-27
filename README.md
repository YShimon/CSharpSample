# C# Sample Code

C# Sample Codeのサンプルコード(コンソールアプリケーション)です。  
C#の色々な機能のサンプルを掲載しています。
Visual Studio 2015(Profesional)で作成しています。C#のVersionは 6.0になります。  

## 開発時の環境
- Windows 10  
- Visual Studio 2015(Profesional)


## 依存(導入Nuget Package等)
- Stype Cop  
- Dapper(軽量ORマッパー)  

## 実行方法  
** (ビルドするには、Visual Studio 2015が必要になります。  )**  
このアプリケーションは、コンソールアプリケーションとして作成されており、  
**コマンドライン引数が2個**必要となります。     

1.  引数について  

    **第1引数**は、Sample Section Numberです。   
    
    Sample Section Numberは下記のようになります。  
    **1 ：Program Flow Management**  
    **5 ：Database Access**  
    **8 ：Delegate**  
    **9 ：Generics**  
    **10：DependencyProperty**  
    **11：Attribute**  
    
    が定義されています。  
    
    **第2引数**は、個別のサンプルコード番号です。

2. Visual Studioから実行する場合  

    3. Project Propertyの指定  
    Visual Studioのメニュー[プロジェクト(P)][CSharpSampeのプロパティ(E)...]  
    を選択しプロジェクトのプロパティ画面を表示します。   
    左ペインの[デバッグ]を選択し、  
    数値を2つ入力します。（例えば、"5 3"と入力します。）


4. コマンドラインから実行する場合  

    5. ソースコードをダウンロードします。  
    Visual Studioからソリューションを開いてビルドします。  
    Dosプロンプト(または、PowerShell)を起動します。  
    bin/Debug(または、Release)に移動します。  
    ***.exeに上記で説明した引数2つを指定し、実行します。  

## コード解説  
- [1.Program Flow Management](https://github.com/YShimon/CSharpSample/wiki/1.-Program-Flow-Management)  
- [4.Linq to Object](https://github.com/YShimon/CSharpSample/wiki/4.-Linq-to-Object)
- [5.Database Access](https://github.com/YShimon/CSharpSample/wiki/5.-Database-Access)
- Generics
- Dependency Property
- Custum Attribute  
- Design Pattern  

## Licence
特に考えてない  

## Author
Y.Shimone
