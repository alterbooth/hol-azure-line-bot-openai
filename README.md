# hol-azure-line-bot
## 概要
本ハンズオンではMicrosoftのクラウドサービス、Azureを活用したWebアプリケーションの開発を通し、  
基本的なクラウドの知識・Azureの使い方を学ぶことができます。  
  
本リポジトリをcloneもしくはダウンロードしてから手順を開始してください。

## 実施環境
本ハンズオンの実施には、以下アカウントが必要です。

- GitHub アカウント
    - https://github.com/
- LINE Developers アカウント
    - https://developers.line.biz/ja/docs/line-developers-console/login-account/
- Azure アカウント
    - https://azure.microsoft.com/ja-jp/free/
    - (学生の方: https://azure.microsoft.com/ja-jp/free/students/ )

### （任意）上級編のローカルデバッグを行いたい方向け
本ハンズオンのソースコードのローカルデバッグを行うには、以下ツールが必要です。

- Git
    - https://git-scm.com/
    - インストール後、PCのターミナルでgitコマンドが使用できるかご確認をお願いします
        - `git --version` など
- Visual Studio Code
    - https://azure.microsoft.com/ja-jp/products/visual-studio-code/
- Dev Containersセットアップ
    - https://code.visualstudio.com/docs/devcontainers/containers#_installation
    - Docker
        - https://www.docker.com/
        - インストール後、PCのターミナルでdockerコマンドが使用できるかご確認をお願いします
            - hello worldイメージを試す: https://hub.docker.com/_/hello-world
    - Visual Studio Code 用の Remote Development 拡張機能
        - https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.vscode-remote-extensionpack
- ngrok
    - https://ngrok.com/
    - ダウンロード&パス設定後、ngrokコマンドが使用できるかご確認をお願いします

## 本ハンズオンで実装するアーキテクチャ
![アーキテクチャ図](./docs/images/hol-azure-line-bot-architecture.png)

## 目次
1. [ソースコードの準備](./docs/1-fork-repo.md)
2. [LINE Botの作成](./docs/2-create-linebot.md)
3. [Azure OpenAI Serviceを使って返信内容を作成するよう更新](./docs/3-update-reply-from-openai.md)
4. [（上級編）Azure Functionsのローカルデバッグを行う](./docs/4-debug.md)

上記手順完了後、作成した全てのリソースグループを削除してください。
