# hol-azure-line-bot
## 概要
本ハンズオンではMicrosoftのクラウドサービス、Azureを活用したWebアプリケーションの開発を通し、  
基本的なクラウドの知識・Azureの使い方を学ぶことができます。  
  
本リポジトリをcloneもしくはダウンロードしてから手順を開始してください。

## 実施環境
本サンプルは下記のツールやアカウントを用意した上で実施することを推奨します。
- Git
    - https://git-scm.com/
    - インストール後、PCのターミナルでgitコマンドが使用できるかご確認をお願いします
        - `git --version` など
- Visual Studio Code
    - https://azure.microsoft.com/ja-jp/products/visual-studio-code/
- LINE Developers アカウント
    - https://developers.line.biz/ja/docs/line-developers-console/login-account/
- Azure アカウント
    - https://azure.microsoft.com/ja-jp/free/
    - (学生の方: https://azure.microsoft.com/ja-jp/free/students/ )

### ※上級編のローカルデバッグを行いたい方向け
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
1. [ソースコードの準備](./docs/1-prepare-sourcecode.md)
2. [Functionsの作成](./docs/2-functions-create.md)
3. [返信内容の変更と再デプロイ](/docs/3-reply-redeploy.md)
4. [（上級編）Dev Containersとngrokを使ってローカルデバッグを行う](/docs/4-document-suppliment.md)

上記手順完了後、作成した全てのリソースグループを削除してください。
