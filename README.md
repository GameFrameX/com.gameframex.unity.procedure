<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Procedure

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

<br />

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · QQ Group: 467608841 / 233840761

<br />

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## Language

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

---

## Project Overview

FSM-based game flow management package for Unity. Drives game lifecycle stages (splash, preload, login, main menu, etc.) through swappable procedure states.

## Architecture

```
ProcedureComponent (MonoBehaviour)
  └─ IProcedureManager (interface)
       └─ ProcedureManager (manages FSM)
            └─ ProcedureBase (abstract, per-state logic)
```

- **ProcedureComponent** — Unity component, registers procedures and entrance procedure via Inspector, auto-starts on `Start()`.
- **ProcedureManager** — Core manager, creates an internal FSM via `IFsmManager` to drive procedure state transitions.
- **ProcedureBase** — Abstract base class with lifecycle callbacks: `OnInit`, `OnEnter`, `OnUpdate`, `OnFixedUpdate`, `OnLeave`, `OnDestroy`.

## Dependencies

- [com.gameframex.unity.fsm](https://github.com/GameFrameX/com.gameframex.unity.fsm) — Finite State Machine

## Quick Start

### Installation

Edit your Unity project's `Packages/manifest.json` and add the `scopedRegistries` section:

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

Then add the package to `dependencies`:

```json
{
  "dependencies": {
    "com.gameframex.unity.procedure": "1.1.1"
  }
}
```

`scopes` controls which packages are resolved through this registry. Only packages whose names start with `com.gameframex` will be fetched from it.

## Usage Examples

### 1. Define Procedure Classes

```csharp
public class ProcedurePreload : ProcedureBase
{
    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        // Load assets, configs, etc.
    }

    protected internal override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        // Check loading progress, switch to next procedure when done
        ChangeToState<ProcedureMain>(procedureOwner);
    }
}

public class ProcedureMain : ProcedureBase
{
    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        // Show main menu
    }
}
```

### 2. Configure via Inspector

1. Add `ProcedureComponent` to your game object (via `GameFrameX > Procedure`).
2. In the Inspector, check the available procedures.
3. Select the entrance procedure (e.g., `ProcedurePreload`).

### 3. Runtime Procedure Management

```csharp
// Check if a procedure exists
bool has = procedureComponent.HasProcedure<ProcedureMain>();

// Get a procedure instance
ProcedureMain main = procedureComponent.GetProcedure<ProcedureMain>();

// Get current procedure info
ProcedureBase current = procedureComponent.CurrentProcedure;
float time = procedureComponent.CurrentProcedureTime;

// Destroy all procedures and reinitialize with new ones
procedureComponent.DestroyProcedures();
procedureComponent.ReinitializeProcedures(newProcedures, entranceProcedure);
```

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for details.


## Documentation & Resources

- [Documentation](https://gameframex.doc.alianblank.com)

## Community & Support

- QQ Group: 467608841 / 233840761
## License

See [LICENSE.md](LICENSE.md) for license information.
