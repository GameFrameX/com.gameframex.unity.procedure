<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Procedure

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/releases)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

インディゲーム開発者向けオールインワンソリューション · インディ開発者の夢を支援

<br />

[ドキュメント](https://gameframex.doc.alianblank.com) · [クイックスタート](#クイックスタート) · QQグループ: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

</div>
## 言語

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | **日本語** | [한국어](README.ko.md)

---

## プロジェクト概要

FSM ベースの Unity ゲームフロー管理パッケージ。切り替え可能なプロシージャステートにより、ゲームライフサイクルステージ（スプラッシュ、プリロード、ログイン、メインメニューなど）を駆動します。

## アーキテクチャ

```
ProcedureComponent (MonoBehaviour)
  └─ IProcedureManager (インターフェース)
       └─ ProcedureManager (FSM を管理)
            └─ ProcedureBase (抽象クラス、各プロシージャのロジック)
```

- **ProcedureComponent** — Unity コンポーネント。Inspector でプロシージャとエントランスプロシージャを登録し、`Start()` 時に自動起動します。
- **ProcedureManager** — コアマネージャ。`IFsmManager` を介して内部 FSM を作成し、プロシージャの状態遷移を駆動します。
- **ProcedureBase** — 抽象基底クラス。ライフサイクルコールバックを提供：`OnInit`、`OnEnter`、`OnUpdate`、`OnFixedUpdate`、`OnLeave`、`OnDestroy`。

## 依存関係

- [com.gameframex.unity.fsm](https://github.com/GameFrameX/com.gameframex.unity.fsm) — 有限状態機械

## クイックスタート

### インストール

Unity プロジェクトの `Packages/manifest.json` を編集し、`scopedRegistries` セクションを追加してください：

```json
{
  "scopedRegistries": [
    {
      "name": "GameFrameX",
      "url": "https://gameframex.upm.alianblank.uk",
      "scopes": [
        "com.gameframex"
      ]
    }
  ]
}
```

次に `dependencies` に追加します：

```json
{
  "dependencies": {
    "com.gameframex.unity.procedure": "1.1.1"
  }
}
```

`scopes` は、どのパッケージをこのレジストリから解決するかを制御します。`com.gameframex` で始まるパッケージのみがこのレジストリから取得されます。

## 使用例

### 1. プロシージャクラスの定義

```csharp
public class ProcedurePreload : ProcedureBase
{
    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        // アセット、設定などのロード
    }

    protected internal override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        // ロード進捗を確認し、完了したら次のプロシージャに切り替え
        ChangeToState<ProcedureMain>(procedureOwner);
    }
}

public class ProcedureMain : ProcedureBase
{
    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        // メインメニューを表示
    }
}
```

### 2. Inspector で設定

1. ゲームオブジェクトに `ProcedureComponent` を追加（`GameFrameX > Procedure`）。
2. Inspector で利用可能なプロシージャにチェックを入れます。
3. エントランスプロシージャを選択（例：`ProcedurePreload`）。

### 3. ランタイムプロシージャ管理

```csharp
// プロシージャの存在確認
bool has = procedureComponent.HasProcedure<ProcedureMain>();

// プロシージャインスタンスの取得
ProcedureMain main = procedureComponent.GetProcedure<ProcedureMain>();

// 現在のプロシージャ情報の取得
ProcedureBase current = procedureComponent.CurrentProcedure;
float time = procedureComponent.CurrentProcedureTime;

// 全プロシージャを破棄し、新しいプロシージャで再初期化
procedureComponent.DestroyProcedures();
procedureComponent.ReinitializeProcedures(newProcedures, entranceProcedure);
```

## 変更履歴

詳細は [CHANGELOG.md](CHANGELOG.md) をご覧ください。

## ライセンス

このプロジェクトは MIT ライセンスの下で公開されています - 詳細は [LICENSE.md](LICENSE.md) ファイルをご覧ください。
