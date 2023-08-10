# 4. （上級編）デバッグを行う
デバッグを行うにあたり、Github Codespacesを使用します。
Codespacesが利用できる方は[4-1](#4-1-codespacesでデバッグを行う)を参考に、利用できない方は[4-2](#4-2-ローカルデバッグ手順)を参考に進めてください。

## 4-1. Codespacesでデバッグを行う
### リポジトリのFork
> Fork手順を記載

### Codespacesを起動する
[前節](#リポジトリのfork)でForkしたリポジトリへ移動します。
「Code」ボタンを選択します。
出てきたメニューの「Codespaces」タブを選択します。
「Create codespace on main」を選択します。

![Codespacesデバッグ1](images/debug_codespaces_1.png)

### 設定ファイルを用意し、Functionsをデバッグ起動
`Functions/local.settings.json` ファイルを作成します。  
内容は `Functions/local.settings.json.template` の中身をコピーし、 `LINE_CHANNEL_ACCESS_TOKEN` の値のみご自身のLINE Messaging APIのチャネルアクセストークンに書き換えます。  
（例: `"LINE_CHANNEL_ACCESS_TOKEN": "abcd...xyz="` ）

Codespaces上で、追加で新しくターミナルを開きます。  
以下コマンドで `Functions` ディレクトリに移動し、Functionsをデバッグ起動します。

```
cd Functions
func start --csharp
```

下の画像のように、 `Webhook: [POST] http://localhost:7071/api/Webhook` と表示されたらCodespaces上でのFunctionsのデバッグ起動が成功です！

![Codespacesデバッグ2](images/debug_codespaces_2.png)

### ポートの公開範囲を変更
「ポート」タブに移動します。
「7071ポート」を右クリックします。
「ポートの表示範囲」を「Public」に変更します。

![Codespacesデバッグ3](images/debug_codespaces_3.png)

### LineBotの設定
> LineBotにWebHook設定する手順を記載

### Codespacesの削除
**今回のハンズオン終了には、使用したCodespacesを削除しましょう。**
[このページ](https://github.com/codespaces)を開き、自身のCodespaces一覧を表示します。
画面左側の「By Repository」から使用したCodespacesの詳細を開きます。
右側の「・・・」を選択し、「Delete」で削除します。
![Codespacesデバッグ4](images/debug_codespaces_4.png)



## 4-2. ローカルデバッグ手順
※事前にソースコードをcloneしてください。

### Dev Containersを使って開発環境を立ち上げる
まずは、`Docker`を起動した状態(Docker Desktopを使用する場合は、Docker Desktopを起動した状態)にします。  
VSCodeを起動し、左上の「File」→「Open Folder」で`hol-azure-line-bot-functions`フォルダを開きます。  
VSCode上でF1キーからコマンドパレットを起動し、「Dev Containers:Reopen in Container」を選択します。
![devcontainer起動1](images/devcontainer_start_1.png)

VSCodeが起動しなおし、コンテナが動いていることが確認できます。
![devcontainer起動2](images/devcontainer_start_2.png)

### 設定ファイルを用意し、Functionsをデバッグ起動
`Functions/local.settings.json` ファイルを作成します。  
内容は `Functions/local.settings.json.template` の中身をコピーし、 `LINE_CHANNEL_ACCESS_TOKEN` の値のみご自身のLINE Messaging APIのチャネルアクセストークンに書き換えます。  
（例: `"LINE_CHANNEL_ACCESS_TOKEN": "abcd...xyz="` ）

VSCode上で、追加で新しくターミナルを開きます。  
以下コマンドで `Functions` ディレクトリに移動し、Functionsをデバッグ起動します。

```
cd Functions
func start --csharp
```

下の画像のように、 `Webhook: [POST] http://localhost:7071/api/Webhook` と表示されたらDev Containers上でのFunctionsのデバッグ起動が成功です！
![devcontainer起動3](images/devcontainer_start_3.png)

### ngrokを使用したLINE Botとの疎通
ngrokが使用できるターミナルを開き、以下コマンドを実行します。

```
ngrok http 7071
```

このコマンドにより、発行されたngrokのURL（例: `https://1234-567-890.jp.ngrok.io` ）が http://localhost:7071 にトンネリングされます。  
LINE DevelopersコンソールのWebhook URLの設定（『2-3. LINEチャネル作成』参照）に、この発行されたngrokのURLに `/api/Webhook` とつけたもの（例: `https://1234-567-890.jp.ngrok.io/api/Webhook` ）を設定します。

![Webhook設定](images/webhook-url-ngrok.png)

LINEアプリのトークルームでBotにメッセージを送ると、ローカルデバッグしているFunctionsが動作します。  
以上で、Dev Containersを使用したAzure Functionsのローカルデバッグならびに、ngrokを使用したLINE Botからローカルで実行中のAzure Functionsへの疎通手順が完了しました。  
試しに、ローカルのソースコードを変更し、動作確認してみてください。

## 4-2. 参考資料
### Azure Functionsのトリガーとバインド  
ハンズオンの2章でAzure Functionsを使用しました。  
トリガーとバインドに関する概念をここで詳しく説明しています。  
[AzureFunctionsのトリガーとバインドの概念](https://learn.microsoft.com/ja-jp/azure/azure-functions/functions-triggers-bindings?tabs=csharp)

### LINE Messaging APIのWebhookイベント  
ハンズオンの2章でWebhookイベントを使用しました。  
Webhookに関して詳しくここで説明しています。  
[LINE Messaging APIのWebhookイベント（テキストメッセージ）](https://developers.line.biz/ja/reference/messaging-api/#wh-text)

また、Messaging APIの概要や仕組みについてのドキュメントもありますので、何ができるのかぜひ見てみましょう。  
[Messaging APIの概要](https://developers.line.biz/ja/docs/messaging-api/overview/)
