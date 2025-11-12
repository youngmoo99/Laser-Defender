# LASER DEFENDER

지구를 방어하라!  
2D 탄막 슈팅 기반의 아케이드 게임 — 적 웨이브를 피하며 레이저로 격추하고, 점수를 갱신하라.

<p align="center">
  <a href="#demo">🎮 플레이 영상</a> •
  <a href="#features">✨ 주요 특징</a> •
  <a href="#tech-stack">🧰 기술 스택</a> •
  <a href="#setup">⚙️ 설치/실행</a> •
  <a href="#screenshots">🖼️ 스크린샷</a>
</p>

<p>
  <img alt="Unity" src="https://img.shields.io/badge/Unity-2021.3.45-black?logo=unity"/>
  <img alt="Platform" src="https://img.shields.io/badge/Platform-Windows%20%7C%20macOS-blue"/>
</p>

---

## TL;DR

* **장르**: 2D Bullet Hell / Arcade Shooter  
* **엔진**: Unity 2021.3.45 
* **역할(Role)**: 기획 100%, 프로그래밍 100%  
* **플레이 루프**: 이동 → 발사 → 적 격파 → 점수 획득 → 게임오버 → 점수 갱신  

---

<h2 id="demo">🎮 플레이 영상</h2>

▶️ Gameplay Video: [게임 플레이 영상](https://youtu.be/WC9vJx0G150)

방향키로 비행선을 조종하고, 적의 탄막을 회피하며 레이저로 격추하세요.  
게임오버 시 최종 점수가 표시되며, **ScoreKeeper**를 통해 점수가 저장됩니다.

---

<h2 id="features">✨ 주요 특징 / Features</h2>

* 🔫 **적 웨이브 시스템** — `ScriptableObject` 기반의 `WaveConfigSO`로 다단계 적 스폰 제어  
* 💥 **탄막 충돌 & 폭발 연출** — `ParticleSystem`과 `CameraShake`를 통한 시각적 피드백  
* 🎵 **사운드 관리** — `AudioPlayer` 싱글톤으로 발사 및 피격 사운드 통합 제어  
* 💡 **플레이어 체력 및 점수 HUD** — `UIDisplay`로 실시간 체력 바와 점수 UI 표시  
* 🧠 **적 경로 이동 (Pathfinder)** — `Waypoints`를 따라 자동 이동하는 AI 경로 시스템  
* 🛰️ **배경 스크롤 효과** — `SpriteScroller`로 우주 공간 느낌의 움직이는 배경 구현  
* 💀 **게임오버 / 재시작 시스템** — `LevelManager`와 `UIGameOver`를 통한 자연스러운 씬 전환  

---

<h2 id="tech-stack">🧰 기술 스택 / Tech Stack</h2>

**엔진**: Unity 6.0  
**언어**: C#  
**툴 및 시스템**:  
- Input System  
- Rigidbody 2D Physics  
- Particle System  
- TextMeshPro  
- ScriptableObject  
- Git / VS Code  

**핵심 시스템 구성**

| 시스템 | 설명 |
|--------|------|
| **Player / Shooter** | 이동 및 발사 입력 처리, 발사체 생성 |
| **EnemySpawner / Pathfinder** | 웨이브 단위 적 스폰 및 이동 경로 제어 |
| **Health / DamageDealer** | 체력 감소 및 충돌 처리 |
| **AudioPlayer / CameraShake** | 사운드, 진동 피드백 통합 |
| **ScoreKeeper / UIDisplay** | 점수 및 체력 UI 갱신 |
| **WaveConfigSO** | ScriptableObject로 웨이브 설정 (프리팹, 속도, 스폰 간격) |

---

<h2 id="architecture">🏗️ 프로젝트 구조 / Architecture</h2>

```
Assets/
  LaserDefender/
    Scripts/
      Player/
        Player.cs
        Shooter.cs
      Enemy/
        EnemySpawner.cs
        Pathfinder.cs
        WaveConfigSO.cs
      System/
        LevelManager.cs
        ScoreKeeper.cs
        AudioPlayer.cs
      UI/
        UIDisplay.cs
        UIGameOver.cs
      FX/
        CameraShake.cs
        SpriteScroller.cs
      Prefabs/
        Player.prefab
        Enemy.prefab
      Scenes/
        MainMenu.unity
        Game.unity
        GameOver.unity
```

**설계 포인트**
- `ScriptableObject` 기반 웨이브 구조로 재사용성 극대화  
- 입력, 피드백(사운드/이펙트), UI 시스템이 모듈화되어 유지보수 용이  
- 씬 간 데이터 유지 (`ScoreKeeper` 싱글톤)  
- AI / Player 간 로직을 통합해 동일한 슈팅 메커니즘 공유  


---

<h2 id="setup">⚙️ 설치 및 실행 / Setup</h2>

저장소 클론

git clone https://github.com/<YOUR_ID>/RoyalRun.git


Unity Hub에서 프로젝트 열기

Packages 자동 복구 후, Assets/Scenes/Demo.unity 실행

▶️ Play

에셋 의존성이 있는 경우, Readme/팝업 안내에 따라 의존 패키지를 함께 설치하세요.

---

<h2 id="controls">🎮 조작법 / Controls</h2>

| 동작 | 키             | 설명      |
| -- | ------------- | ------- |
| 이동 | ← / → / ↑ / ↓ | 플레이어 이동 |
| 발사 | Space         | 레이저 발사  |

---

<h2 id="screenshots">🖼️ 스크린샷 / Screenshots</h2> <p align="center"> <img src="ea3fbbd0-6d5a-47b6-a2e0-6116be679c6c.png" width="720" alt="Laser Defender Gameplay"/> <img src="LaserDefender_MainMenu.png" width="320" alt="Laser Defender Main Menu"/> </p>

플레이어의 레이저와 적의 탄막이 교차하며, 충돌 시 진동과 폭발 파티클이 동시에 발생합니다.
이펙트와 사운드가 어우러진 박진감 넘치는 피드백이 핵심입니다.

---

<h2 id="roadmap">🚀 향후 계획 / Roadmap</h2>

* [ ]  Checkpoint 시스템 추가

* [ ]  적 AI 확장 (추적 / 투사체 공격)

* [ ]  체력 기반 데미지 시스템

* [ ]  아이템/무기 업그레이드 시스템

* [ ]  모바일 터치 대응 및 패드 지원

 ---

<h2 id="credits">👤 제작자 / Credits</h2>

* **기획·개발**: 김영무 (Kim YoungMoo)

* **아트 리소스**: Low-poly 리소스(상용/프리믹스)

* **사운드**: 자체 제작 & 무료 라이브러리 활용
  
* **참고 강의**: [강의 링크](https://www.udemy.com/course/best-c-unity-2d/?kw=c%23&src=sac&couponCode=MT251110G1)


 ---
 
<h2 id="contact">📬 연락처 / Contact</h2>

* **이메일**: [rladuan612@gmail.com](mailto:rladuan612@gmail.com)
* **포트폴리오**: [포트폴리오](https://www.naver.com)

