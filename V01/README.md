# AeroDash V01 - Skyline Courier

An offline Android package of the Skyline Courier WebGL flying-car game. All files for this version are in `V01`.

## Install the APK

Download **[AeroDash-V01-test.apk](apk/AeroDash-V01-test.apk)** using GitHub's **Download raw file** button, then open it on an Android phone or tablet. Android may ask you to allow installation from the app used to open the APK.

- Android 8.0 (API 26) or newer; WebGL-capable Android System WebView required.
- Landscape orientation, touch controls, offline game assets, saved local progress.
- Package: `com.saidk84.aerodash`, version `0.1`, version code `1`, target API `35`.
- Signed with a development/test certificate. This is a sideloadable test APK, not a Play Store release or AAB.
- No network permission, public chat, ads, analytics, purchases, login or native JavaScript bridge.
- Reinstalling with a different signing key requires uninstalling the previous build; uninstalling clears progress.

## Play

Accept a mission from the board. Use **Guided flight** for a complete assisted pickup and delivery, or hold the touch controls to accelerate, turn, climb and descend. Slow below 35 km/h in the dock ring to pick up or deliver. Coins unlock cars and cities; visiting docks collects passport stamps.

Desktop controls: W/S speed, A/D turn, up/down altitude, Space brake, Shift boost on upgraded vehicles, G guided flight, C camera, P pause.

## Included

| Path | Contents |
| --- | --- |
| `web/` | Authoritative HTML, CSS, JavaScript, manifest and icon source |
| `Skyline-Courier.html` | Original self-contained browser edition |
| `android/` | Android Studio/Gradle project and native WebView activity |
| `build-apk.ps1` | Offline build with installed Android SDK tools and JDK |
| `tests/verify.cjs` | Headless game-logic checks (not a rendered-device test) |
| `apk/` | Installable test APK, checksum and build report |

The Android build copies `web/` into APK assets. It serves those packaged assets through an intercepted HTTPS origin; external requests and navigation are blocked. Progress is stored in WebView DOM storage. Backgrounding pauses flight; resume with the play button. Active missions are not restored across app restarts.

## Rebuild on Windows without Gradle downloads

Install Android SDK Build Tools 36.0.0, an Android SDK platform >=35 and a JDK (Android Studio's bundled JDK works). In PowerShell:

```powershell
cd V01
./build-apk.ps1 -Sdk "$env:LOCALAPPDATA/Android/Sdk" -Jdk 'C:/Program Files/Android/Android Studio/jbr' -Platform 'android-35'
```

For the platform used by this checked-in APK, use `-Platform 'android-37.0'`. The app still targets API 35 and has min API 26. The script verifies signing and ZIP alignment and writes `apk/SHA256SUMS.txt`. The local test keystore is generated in ignored `private/`; never commit it. Use a separately secured production signing key for store releases.

## Android Studio / Gradle

Open `V01/android`. This project pins Android Gradle Plugin 8.9.2; use Gradle 8.11.1 and JDK 17 or newer. Install SDK platform 35. With Gradle installed, run `gradle :app:assembleDebug` from `V01/android`. Initial Gradle builds require network access to fetch build dependencies. There is no downloaded Gradle wrapper JAR in this repository.

## Tests and scope

Run `node tests/verify.cjs` from `V01` (Node.js required). It checks guided delivery completion in all five cities, altitude limits, pause, upgrade gating and duplicate reward protection.

This is an early browser-engine game packaged for Android, not a Unity/Unreal implementation. City geometry is stylized and geographically approximate. No photorealistic models, device thermal API, real traffic simulation or app-store compliance certification is claimed. Compilation and APK integrity checks do not replace testing on physical phones. See the build report for verification actually completed.

