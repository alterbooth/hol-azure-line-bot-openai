# 1. ソースコードの準備
## 1-1. Githubからソースコードを取得
はじめに、このハンズオンで使用するコードの保存先をつくります。任意の場所に「フォルダ」を作成。
今回はフォルダ名を`handson`とします。


次に、Githubからソースコードをフォークします。
[Githubハンズオンリポジトリ](https://github.com/alterbooth/hol-azure-line-bot-functions) を開き、右上の「Fork」をクリックします。
![ソースコードの準備1](images/preparing_source_1.png)


Ownerの「Select an owner」で自分のアカウントを選択し、一番下の「Create fork」でフォークを作成します。
![ソースコードの準備2](images/preparing_source_2.png)


次に、自分のアカウントのリポジトリからフォークしてきたコードをCloneします。
フォークしたリポジトリの「Code」をクリックし、HTTPSをコピーします。
![ソースコードの準備3](images/preparing_source_3.png)

VSCodeを開き、ターミナルでディレクトリを先ほど作ったフォルダに移動し、クローンしたリポジトリを開きます。<br>
まずは、VSCodeの左下をクリックし、ターミナルを開きます。
![ソースコードの準備5](images/preparing_source_5.png)
![ソースコードの準備6](images/preparing_source_6.png)

<!-- ターミナルで「cd 保存先のディレクトリ」(cd半角スペース)と入力し、handsonディレクトリに移動 -->
<!-- ![ソースコードの準備7](images/preparing_source_7.png) -->
ターミナルで`handson`ディレクトリに移動し、「git clone https://github.com/alterbooth/hol-azure-line-bot-functions.git 」とコマンドを入力します。
![ソースコードの準備8](images/preparing_source_8.png)

「code .」とコマンド入力すると、ローカルでコードを開きます。
![ソースコードの準備9](images/preparing_source_9.png)


## 1-2. devcontainerを使って開発環境を立ち上げる
まずは、「Docker Desktop」を開いておきます。
先ほど開いたソースコードのVSCodeで、「F1キー」を押し、「Dev Containers:Reopen in Container」を選択。
![devcontainer起動1](images/devcontainer_start_1.png)

VSCodeが立上がりコンテナが動いているのが確認できます。
![devcontainer起動2]()

次に、ローカルで関数アプリを立ち上げます。<br>
今立ち上がったVSCodeのターミナルでhol-azure-line-bot-functionsのFunctionsディレクトリに移動し、「func start --csharp」とコマンド入力します。
![devcontainer起動3]()



