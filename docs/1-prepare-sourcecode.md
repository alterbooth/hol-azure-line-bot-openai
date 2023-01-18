# 1. ソースコードの準備
## 1-1. Githubからソースコードを取得
はじめに、このハンズオンで使用するコードの保存先をつくります。任意の場所に「フォルダ」を作成。  
今回はフォルダ名を`handson`とします。


次に、Githubからソースコードをフォークします。  
[ハンズオンのソースコードリポジトリ](https://github.com/alterbooth/hol-azure-line-bot-functions) を開き、右上の「Fork」をクリックします。
![ソースコードの準備1](images/preparing_source_1.png)


Ownerの「Select an owner」で自分のアカウントを選択し、一番下の「Create fork」でフォークを作成します。
![ソースコードの準備2](images/preparing_source_2.png)


次に、自分のアカウントのリポジトリからフォークしてきたコードをCloneします。  
フォークしたリポジトリの「Code」をクリックし、HTTPSをコピーします。
![ソースコードの準備3](images/preparing_source_3.png)  

PCのターミナルを開き、`handson`ディレクトリに移動し、`git clone コピーしてきたHTTPS`とコマンドを入力します。  
(PCのターミナルでgitコマンドが使えるようにしておいてください。)
![ソースコードの準備8](images/preparing_source_8.png)

確認できたら、次のステップ「[Functionsの作成](/docs/2-functions-create.md)」へ進みます。
