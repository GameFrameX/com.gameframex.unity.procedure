<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Procedure

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使

<br />

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#快速開始) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>
## 語言

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## 項目簡介

基於有限狀態機（FSM）的 Unity 遊戲流程管理套件。透過可切換的流程狀態驅動遊戲生命週期階段（閃屏、預載入、登入、主選單等）。

## 架構概覽

```
ProcedureComponent (MonoBehaviour)
  └─ IProcedureManager (介面)
       └─ ProcedureManager (管理 FSM)
            └─ ProcedureBase (抽象類別，每個流程的邏輯)
```

- **ProcedureComponent** — Unity 元件，透過 Inspector 註冊流程和入口流程，`Start()` 時自動啟動。
- **ProcedureManager** — 核心管理器，透過 `IFsmManager` 建立內部 FSM 驅動流程狀態切換。
- **ProcedureBase** — 抽象基底類別，提供生命週期回呼：`OnInit`、`OnEnter`、`OnUpdate`、`OnFixedUpdate`、`OnLeave`、`OnDestroy`。

## 依賴

- [com.gameframex.unity.fsm](https://github.com/GameFrameX/com.gameframex.unity.fsm) — 有限狀態機

## 快速開始

### 安裝

編輯 Unity 專案的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：

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

然後在 `dependencies` 中添加：

```json
{
  "dependencies": {
    "com.gameframex.unity.procedure": "1.1.1"
  }
}
```

`scopes` 控制哪些套件透過此註冊表解析。只有以 `com.gameframex` 開頭的套件才會從這個註冊表取得。

## 使用範例

### 1. 定義流程類別

```csharp
public class ProcedurePreload : ProcedureBase
{
    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        // 載入資源、設定等
    }

    protected internal override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        // 檢查載入進度，完成後切換到下一個流程
        ChangeToState<ProcedureMain>(procedureOwner);
    }
}

public class ProcedureMain : ProcedureBase
{
    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        // 顯示主選單
    }
}
```

### 2. 透過 Inspector 設定

1. 將 `ProcedureComponent` 添加到遊戲物件（透過 `GameFrameX > Procedure`）。
2. 在 Inspector 中勾選可用的流程。
3. 選擇入口流程（如 `ProcedurePreload`）。

### 3. 執行時流程管理

```csharp
// 檢查流程是否存在
bool has = procedureComponent.HasProcedure<ProcedureMain>();

// 取得流程實例
ProcedureMain main = procedureComponent.GetProcedure<ProcedureMain>();

// 取得當前流程資訊
ProcedureBase current = procedureComponent.CurrentProcedure;
float time = procedureComponent.CurrentProcedureTime;

// 銷毀所有流程並使用新流程重新初始化
procedureComponent.DestroyProcedures();
procedureComponent.ReinitializeProcedures(newProcedures, entranceProcedure);
```

## 更新日誌

詳見 [CHANGELOG.md](CHANGELOG.md)。

## 開源協議

本專案基於 MIT 協議開源 - 詳見 [LICENSE.md](LICENSE.md) 檔案。
