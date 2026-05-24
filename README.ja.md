<div align="center">
  <img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />
</div>

# Game Frame X Procedure

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/releases)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

> インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#クイックスタート) · [QQグループ](https://qm.qq.com/q/5U9Fvebw) · [言語](#言語)

---

## 言語

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

---

## プロジェクト概要

GameFrameX の Procedure フロー管理コンポーネント。

**Procedure フロー管理コンポーネント (Procedure Component)** - フロー管理コンポーネント関連のインターフェースを提供します。

**このライブラリは主に `https://github.com/AlianBlank/GameFrameX.Unity` のサブライブラリとして使用されます。**

## 依存コンポーネント

- 有限状態機械 (FSM)：https://github.com/AlianBlank/com.alianblank.gameframex.unity.fsm

## クイックスタート

### インストール（いずれかを選択）

1. `manifest.json` の `dependencies` セクションに以下を追加します：
   ```json
   {"com.gameframex.unity.procedure": "https://github.com/AlianBlank/com.gameframex.unity.procedure.git"}
   ```

2. Unity の `Package Manager` で `Git URL` を使用して追加：https://github.com/AlianBlank/com.gameframex.unity.procedure.git

3. リポジトリを直接ダウンロードして、Unity プロジェクトの `Packages` ディレクトリに配置します。自動的に読み込まれます。

## 使用例

### ProcedureComponent 概要

`ProcedureComponent` は、Unity と Game Framework ベースのゲームでゲームフローを管理するためのコンポーネントです。`FSMComponent`（有限状態機械コンポーネント）に依存し、ゲームの起動、メニュー、プレイ、一時停止、終了など、異なる段階や状態を管理します。

### 機能

- プロシージャマネージャー (`IProcedureManager`) を初期化し、`GameFrameworkEntry` を通じて関連モジュールを登録・取得します。
- ゲーム起動時にすべての利用可能なプロシージャ (`ProcedureBase` 型配列) を作成・初期化します。
- ゲーム起動時、エントリプロシージャ (`m_EntranceProcedure`) に自動的に切り替えます。
- 現在のプロシージャとその継続時間を照会・取得するメソッドを提供します。

### 依存関係

`ProcedureComponent` は以下のコンポーネントまたはモジュールが必要です：

- `FSMComponent`：プロシージャの有限状態機械ロジックの実装に使用。
- `IProcedureManager`：Game Framework が提供する、ゲームのプロシージャ状態を管理するインターフェース。
- `ProcedureBase`：カスタムプロシージャを拡張するための基底クラス。

### 設定

Unity Inspector で以下のプロパティを設定できます：

- `m_AvailableProcedureTypeNames`：利用可能なプロシージャの型名配列。ゲーム起動時にプロシージャを作成・初期化するために使用。
- `m_EntranceProcedureTypeName`：ゲーム起動時に最初に入るプロシージャの型名。

### パブリックメソッド

- `HasProcedure<T>()`：指定された型のプロシージャが存在するか確認します。
- `GetProcedure<T>()`：指定された型のプロシージャを取得します。

## 変更履歴

詳細は [CHANGELOG.md](CHANGELOG.md) をご覧ください。

## ライセンス

このプロジェクトは MIT ライセンスの下で公開されています。詳細は [LICENSE.md](LICENSE.md) ファイルをご覧ください。
