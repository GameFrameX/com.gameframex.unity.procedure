<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X Procedure

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.procedure)](https://github.com/GameFrameX/com.gameframex.unity.procedure/releases)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

인디 게임 개발자를 위한 올인원 솔루션 · 인디 개발자의 꿈을 실현

<br />

[문서](https://gameframex.doc.alianblank.com) · [빠른 시작](#빠른-시작) · [QQ 그룹](https://qm.qq.com/q/5U9Fvebw)

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

</div>
## 언어

[English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | **한국어**

---

## 프로젝트 개요

FSM 기반 Unity 게임 흐름 관리 패키지. 전환 가능한 프로시저 상태를 통해 게임 라이프사이클 단계(스플래시, 프리로드, 로그인, 메인 메뉴 등)를 구동합니다.

## 아키텍처

```
ProcedureComponent (MonoBehaviour)
  └─ IProcedureManager (인터페이스)
       └─ ProcedureManager (FSM 관리)
            └─ ProcedureBase (추상 클래스, 각 프로시저의 로직)
```

- **ProcedureComponent** — Unity 컴포넌트. Inspector로 프로시저와 진입 프로시저를 등록하고, `Start()` 시 자동 시작합니다.
- **ProcedureManager** — 핵심 관리자. `IFsmManager`를 통해 내부 FSM을 생성하여 프로시저 상태 전환을 구동합니다.
- **ProcedureBase** — 추상 기반 클래스. 라이프사이클 콜백 제공: `OnInit`, `OnEnter`, `OnUpdate`, `OnFixedUpdate`, `OnLeave`, `OnDestroy`.

## 의존성

- [com.gameframex.unity.fsm](https://github.com/GameFrameX/com.gameframex.unity.fsm) — 유한 상태 기계

## 빠른 시작

### 설치

Unity 프로젝트의 `Packages/manifest.json`을 편집하여 `scopedRegistries` 섹션을 추가하세요:

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

그런 다음 `dependencies`에 추가합니다:

```json
{
  "dependencies": {
    "com.gameframex.unity.procedure": "1.1.1"
  }
}
```

`scopes`는 이 레지스트리를 통해 어떤 패키지를 해석할지 제어합니다. `com.gameframex`로 시작하는 패키지만 이 레지스트리에서 가져옵니다.

## 사용 예시

### 1. 프로시저 클래스 정의

```csharp
public class ProcedurePreload : ProcedureBase
{
    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        // 에셋, 설정 등 로드
    }

    protected internal override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        // 로딩 진행률 확인, 완료 시 다음 프로시저로 전환
        ChangeToState<ProcedureMain>(procedureOwner);
    }
}

public class ProcedureMain : ProcedureBase
{
    protected internal override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        // 메인 메뉴 표시
    }
}
```

### 2. Inspector로 설정

1. 게임 오브젝트에 `ProcedureComponent`를 추가합니다 (`GameFrameX > Procedure`).
2. Inspector에서 사용 가능한 프로시저를 선택합니다.
3. 진입 프로시저를 선택합니다 (예: `ProcedurePreload`).

### 3. 런타임 프로시저 관리

```csharp
// 프로시저 존재 여부 확인
bool has = procedureComponent.HasProcedure<ProcedureMain>();

// 프로시저 인스턴스 가져오기
ProcedureMain main = procedureComponent.GetProcedure<ProcedureMain>();

// 현재 프로시저 정보 가져오기
ProcedureBase current = procedureComponent.CurrentProcedure;
float time = procedureComponent.CurrentProcedureTime;

// 모든 프로시저를 파괴하고 새 프로시저로 재초기화
procedureComponent.DestroyProcedures();
procedureComponent.ReinitializeProcedures(newProcedures, entranceProcedure);
```

## 변경 로그

자세한 내용은 [CHANGELOG.md](CHANGELOG.md)를 참조하세요.

## 라이선스

이 프로젝트는 MIT 라이선스에 따라 배포됩니다 - 자세한 내용은 [LICENSE.md](LICENSE.md) 파일을 참조하세요.
