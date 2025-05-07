# 🇯🇵 Comet - 2回目の Unity チャレンジ！

クラシックなスネークゲームを「Slither.io」風に改造！  
参考は基本チュートリアル動画のみ。本当に1日で完成できるか、挑戦！

<img src="video/cometgif.gif" width="600" />

## 使用ツール
- Unity 6.0
- C#
- Visual Studio Code
- Cursor
- Git
- Logic Pro
- Photopea
- CapCut

## 使用したAIツール
- ChatGPT（C# コーディング支援）
- Ideogram.ai、Freepik（画像生成）
- SUNO（BGM生成）

## ゲーム概要
**Comet** は進化型スネークゲーム。  
彗星を操作して隕石を食べ、体を伸ばしながらブラックホールなどの障害を避ける！

## 制作動機
目的は**90度ターンを360度自由移動に変更**すること。  
UI、マネージャー、シーン管理、Gitも勉強。

## 技術的な特徴
- `Vector2.Lerp` による360度移動
- マネージャーでオブジェクトと音声管理
- UI 実装（スタート/エンド画面・ボタン）
- AI画像を Photopea で編集・利用

## ⚠️ 苦労した点と解決法
- 方向キーでの自由移動実装が困難 → `Vector2.Lerp` 採用
- Unityバージョン差異で混乱 → AIと調査で解決
- 体が縮む機能未実装 → 今回は断念

## 📅 開発日記
### Day 1：チュートリアルから深夜まで
MansCom の動画で学習開始。  
360度移動の実装に成功、体縮小機能は未完成。

### Day 2：機能追加＆再挑戦
音声、UI、障害物追加。縮小機能は失敗のまま。

## 🏁 振り返り
「1日で完成」には失敗！🤣  
でも貴重な実戦経験。次こそ縮小機能を実現！

---


# Comet - 第二次 Unity 挑戰！  
這次從經典貪食蛇出發，試著挑戰把它變成像 Slither.io 的玩法。  
只參考原始貪食蛇教學影片，能不能在一天內搞定？來試試看吧！

<img src="video/cometgif.gif" width="600" />

## 🛠️ 開發工具
- Unity 6.0 (6000.0.48f1)
- C#
- Visual Studio Code
- Cursor
- Git
- Logic Pro
- Photopea
- CapCut

## 🤖 使用的 AI 工具
- ChatGPT（協助撰寫與除錯 C# 程式碼）
- Ideogram.ai、Freepik（圖片生成）
- SUNO（背景音樂生成）

## 🎮 遊戲概要
**Comet** 是一款進化版的貪食蛇遊戲。  
玩家是一顆擁有自我意識的彗星，操作方向鍵在宇宙中移動，吃下隕石後會拉長身體，  
但要小心四周的牆壁與出現的黑洞陷阱！

## 🎯 製作動機
這是我第二次使用 Unity 製作遊戲。  
想挑戰的目標是：**把固定90度轉彎的控制方式，改成自由360度移動**，  
並學習 Unity 的 UI 系統、GameManager、AudioManager、場景切換與 Git 版控。

## 🧩 技術特色
- **360度方向控制**：從傳統貪食蛇的固定轉彎改成滑順自由的圓形移動，使用 `Vector2.Lerp` 實現。
- **物件管理架構**：透過 Manager 統一管理遊戲物件與音效，讓專案更好維護。
- **UI 系統實作**：實作開始畫面、結束畫面、按鈕功能。
- **AI 素材融合**：AI 產圖後使用 Photopea 微調製作物件。

## ⚠️ 遇到的挑戰與解法
- **方向鍵控制難調整**：原本以為改改 KeyDown/KeyUp 就能改成360度移動，後來才找到用 `Vector2.Lerp` 的方式解決。
- **教學影片 Unity 版本不同**：Unity 版本差異導致教學中部分功能名稱不同，花了很多時間查資料與問 AI 才解決。
- **身體縮小功能未完成**：本來希望實作彗星身體會逐漸縮短的功能，但嘗試各種方法都失敗，暫時放棄（但未來還想挑戰）。

---

## 📅 開發日記

### Day 1：從教學影片出發，一路研究到半夜  
這次我參考的是 YouTuber「MansCom 曼斯康」的貪食蛇教學。  
一開始就想改成360度移動方式，試了1小時後終於發現 `Vector2.Lerp` 的寫法，測試後成功實裝。  
第一天幾乎完成了遊戲核心，但我卡在一個功能：「讓身體會慢慢縮短」──研究到半夜還是沒做出來，只好先放棄。

---

### Day 2：加料加功能，但還是沒搞定身體縮小…  
既然超過一天，那就加點挑戰吧：  
我加了音效管理功能、遊戲 UI 畫面與黑洞障礙物，讓遊戲更完整。  
不過我對於漸漸縮小身體功能不死心還是花了2～3小時在研究……最後還是沒辦法實現。  
但總算是把遊戲做完了！

---

## 🏁 結語：挑戰成功嗎？
目標是「一天內完成 Unity 遊戲開發」──  
**結果：還是沒成功！🤣**

看很多教學影片（不管是中文、日文還是英文）開起來都很快，  
但我的舊電腦實在不給力，在換新電腦前只能多點耐心。

---


雖然挑戰失敗，但這次又是一次非常寶貴的實戰經驗，  
未來我還想繼續挑戰「身體會逐漸縮短」的功能！

👏 感謝你看到這裡！

---


# Comet - Second Unity Challenge!

From Snake to Slither.io in one day?  
Let’s see if I can build it using only a basic Snake tutorial!

<img src="video/cometgif.gif" width="600" />

## Tools Used
- Unity 6.0
- C#
- Visual Studio Code
- Cursor
- Git
- Logic Pro
- Photopea
- CapCut

## AI Tools
- ChatGPT (for C# help)
- Ideogram.ai, Freepik (image gen)
- SUNO (background music)

## Game Overview
**Comet** is a Snake-inspired game where you control a conscious comet.  
Eat meteors to grow longer while avoiding walls and black holes!

## Goal
My goal was to **replace 90° turns with smooth 360° movement**,  
and also learn UI, GameManager, AudioManager, scene transitions, and Git.

## Key Features
- 360° movement via `Vector2.Lerp`
- Manager structure for objects and audio
- Custom UI screens and button events
- AI-generated and edited visuals

## ⚠️ Challenges
- Directional control wasn’t simple → `Vector2.Lerp` fixed it
- Unity version differences caused confusion → solved with AI
- Shrinking body feature didn’t work out → future challenge!

## 📅 Dev Log
### Day 1: Tutorial & Testing
Followed MansCom’s video.  
Implemented 360° movement successfully.  
Couldn’t finish shrinking feature.

### Day 2: Final polish
Added sound, UI, obstacles.  
Still couldn’t get shrinking to work, but game completed!

## 🏁 Conclusion
Tried to finish in 1 day —  
**Failed! 🤣**  
But great learning experience. I’ll tackle the shrinking tail next time!

---
