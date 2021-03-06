## TODO

### 振り返り

- 古橋さんはリファクタリング機能が呼べるけど、ゲストは機能しない...
- おーひらさんの音声が乱れた
- モブプロが回ってるか？
  - 誰宛に喋ってるか
  - 誰が書くのか
  - 質問なのか意見なのか
- 自動タイポ修正最高な件について
- 環境の用意が一人で良い
  - ホストマシンをガチ盛りにすればいけるのでは！
  - とはいえ、誰がやっても成立するようにしておくのは大事やで
- 議論をしないで実装を進めるのは良かった
  - 結論の後回しは進める上で良かった
- リモートでのモププロが成立したことがわかった
  - TDD自体がモププロを成立させている
  - 業務(納期)で成立する？？
- 自分のスタイルがあることがわかった
  - 他の人の意見を聞くことで自分のスタイルがあることが発見した
  - 人の意見を聞くことで自分のスタイルがわかる
- TDDのテストをどこまでテストを残すか
  - privateは残すべき？
  - 実装の詳細は残すべきではない→privateは残さない
  - テストをしまくることで気付く
    - バランス感覚を養う
- 同時編集はどこまで許容するか
  - 考えていることを書くのはNG
    - 考えていることは後で指摘する
    - 思考を邪魔しないところにメモを残す
      - ローカルのエディタとか
  - タイポなどは許容できる

---

- [ ] ストレートを判定できる
  - 2枚のカードのランクが連続している
    - [x] ハートの3とスペードの4
    - [x] ハートの4とスペードの5    
    - [x] ハートのAとスペードの2
    - [ ] ハートのKとスペードのA
- [ ] ストレートフラッシュを判定できる
  - ストレートとフラッシュが成立している
- [ ] 強い役が優先される


---

### 課題1-1

- [x] カードの文字列表記
  - [x] スペードの3 -> "3♠"
  - [x] ハートのJ -> "J♥"
- [ ] suitは文字列で良いのか？(Enum)
- [x] rankは数値で良いのか？(AやJなど)
- [x] ChainingAssertion使って書く？

- [x] ファイル名とかを修正したい話
  - [x] Pocker問題(ぽっかー) -> 棚上げ。ディレクトリとかは触らない
  - [x] テストファイル名の変更(UnitTest1.cs -> PokerTest?)
- [x] targetって名前よくつかうのかな？ sutとか？ card? spade3?
- [x] 代入するだけのコンストラクタは省略できるはず
  - https://www.buildinsider.net/language/csharplang/070001

- VS Live Share
  - みんなのカーソルの反映が不完全。PokerTest.csにいるのに
  - ファイルの整合性がとれてない
  - ホストの問題？ autoSaveの問題？ OSの問題？
  - Pocker.mdは無事

---

### 課題1-2
- [x] 任意のカード2枚について、同じスート／ランクを持つか判断してください
  - [x] HasSameSuit
    - [x] 3♠ == J♠ 
    - [x] 3♠ != 3♥
  - [x] HasSameRank
    - [x] spade3.HasSameRank(heart3).IsTrue()
    - [x] spade3.HasSameRank(spade5).IsFalse()
- [x] SuitとRankをEnumにしたい -> しない

!!!課題1-2 カードの比較

任意のカード2枚について、同じスート／ランクを持つか判断してください

* '''カード''' (card) がもう1枚のカードと'''同じスートを持つか''' (has same suit) を判断してください
* '''カード''' (card) がもう1枚のカードと'''同じランクを持つか''' (has same rank) を判断してください

 【例】
 Card threeOfSpades = new Card("♠", "3"); // スペードの3
 Card aceOfSpades = new Card("♠", "A"); // スペードのA
 Card aceOfHearts = new Card("♥", "A") // ハートのA
 // スペードの3とスペードのAは同じスートを持つ
 threeOfSpades.hasSameSuit(aceOfSpades) // => true
 // スペードの3とハートのAは異なるスートを持つ
 threeOfSpades.hasSameSuit(aceOfHearts) // => false
 // スペードの3とスペードのAは異なるランクを持つ
 threeOfSpades.hasSameRank(aceOfSpades) // => false
 // スペードのAとハートのAは同じランクを持つ
 aceOfSpades.hasSameRank(aceOfHearts) // => true

---

- [x] ペアが判定できる
  - [x] 同じランクを持つ
    - [x] "3♠"と "3♥"のときにTrueとなる
- [x] フラッシュが判定できる
  - [x] 同じスートを持つ
    - [x] "3♠"と "J♠"のときにTrueになる
- [x] ハイカードが判定できる
- [x] cards.Hand == Pair
- [ ] 「ペアじゃないケースのテスト」を書くべき？
  - テストケース増えそう
  - 今の所ペアの判定ロジックに不安はない
- [x] 役の判定メソッドをPrivateにする
  - [x] IsPair
  - [x] IsFlush
  - [x] IsHighCard
- [x] IsPairとかのtestを残す？(プライベートメソッドのテストいるかいらない問題)
  - 使わないものは消す。使うなら残す

- 古橋さんはリファクタリング機能が呼べるけど、ゲストは機能しない...
- おーひらさんの音声が乱れた
- モブプロが回ってるか？
  - 誰宛に喋ってるか
  - 誰が書くのか
  - 質問なのか意見なのか
- 自動タイポ修正最高な件について
- 環境の用意が一人で良い
  - ホストマシンをガチ盛りにすればいけるのでは！
  - とはいえ、誰がやっても成立するようにしておくのは大事やで
  
### 課題2-1

!!課題2 ツーカードポーカー (two card poker) の役を判定

1デッキのトランプの内、任意の2枚から構成される手札を使ったポーカー

!!課題2-1 ツーカードポーカーの役を判定

ツーカードボーカーの任意の '''手札''' (cards) について、その '''役''' (hand) を判定してください

ツーカードポーカーには以下の役があります

* ペア (pair)
** 2枚のカードが同じランクを持つ
* フラッシュ (flush)
** 2枚のカードが同じスートを持つ
* ハイカード (high card)
** 2枚のカードが異なるランク/スートを持つ

!!課題2-2 ツーカードポーカーの役を判定(役の追加)

ツーカードポーカーに新たな役が追加されます

ツーカードボーカーの任意の手札について、その役を判定してください
(複数の役が成立している場合は、より上位の役が成立しているとみなしてください)

* ストレートフラッシュ (straight flush)
** ストレートとフラッシュが成立している
* ペア (pair)
** 2枚のカードが同じランクを持つ
* ストレート (straight)
** 2枚のカードのランクが連続している
** A は 2 と K の両方と連続しているとみなす (A-K および 2-A のランクの組み合わせはいずれもストレートである)
* フラッシュ (flush)
** 2枚のカードが同じスートを持つ
* ハイカード (high card)
** 上記の役が1つも成立していない
---

