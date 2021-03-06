# どうぶつゆうびん

どうぶつがものを送り届けるゲーム

# ゲームシステム

- 郵便を食べるとHP回復
- 4人プレイ
  * Coop? 可能ならオンライン

# インストール

## 必要環境

  * Unity 2017.3.0f3
* Git
* Githubアカウント

## 事前にやること

* そのままだとpushできないので、同じ班のJammerはHibikineKageにGitHubのアカウントIDを伝えてください
* 次に、HibikineKageがCollaboratorの追加承認を送るので、GitHubに登録したメールアドレスに届くメールから承認をクリックしてください
* そうすればPushできるようになるはずです

## プロジェクトを落としてくる

```bash
git clone git@github.com:HibikineKage/ggj18.git
```

あとはUnityでggj18のフォルダを開けばOKです

## 変更の追加

SourceTreei(GUI)でもいいですがぼくは操作方法わかりません
CUI(コンソール)での操作方法を書いておきますのでお好きな方を使ってください

```
# git add [ファイル名]で変更をステージング(登録)します
# --allで全ファイルステージング
# 変更をやっぱりアンステージしたい(含めたくない)場合はgit reset HEAD [ファイル名]
git add --all

# git commit -m "コミットメッセージ" で変更をコミットします
# 間違えてコミットしてしまった場合はgit reset --soft 'HEAD^'
git commit -m "画像ファイルを追加"

# git pushでコミットをサーバーにプッシュ(送り)ます
# 最初のpushの時はgit push -u origin masterって打ってください
# 怒られたときはgit pullしてからgit pushし直してください
# なんか変な画面が立ち上がったら :wq って打ってエンターを押せばOKです
# もし、git pullでCONFLICTが発生した場合、自分で直すのは難しいと思うのでHibikineKageを呼んでください(できる人はマージしちゃってね)
git push

# サーバーの変更はgit pullで落としてきて取り込みます
# pullしたときに自分のコミットがある場合はダウンロード完了後にマージが発生します
# サーバーと自分の競合を解消してくれます
# 基本的には変な画面が立ち上がったら :wq とタイプしてエンターを押せばいいのですが
# CONFLICTって出た場合は同じファイルいじった場合です
# コンフリクト解消は難しいのでHibikineKageを呼んでください
# 基本的には同じファイルは同時に操作しないようにお願いします(コンフリクト解消できる人はガンガンマージすればいいです)
git pull
```

## 開発時の留意点
基本的に自分の名前を付けたシーンで作業する。
複数シーンのマージは非常に面倒なので、誰か1人が作業するようにする。
できるだけプレハブ化し、他のシーンに持っていけるようにする。

# コーディング規約
* privateでRigidbodyのコンポーネントを持つときは変数名はrbを使う。

