# Android build instructions

## Prerequisites
- Unity 6 editor version matching ProjectSettings/ProjectVersion.txt, or update that version to your installed Unity 6 version.
- Unity Android Build Support including Android SDK, NDK and OpenJDK.
- An activated Unity editor license.

## Build
Open the V02 directory as a Unity project. From the menu select **AeroDash > Build Android APK**.

Or invoke the editor in batch mode:

```bash
Unity -batchmode -nographics -quit -projectPath /absolute/path/to/V02 -buildTarget Android -executeMethod AeroDashAndroidBuild.BuildAndroid -logFile -
```

The build script creates an empty scene if necessary. The runtime bootstrap then populates it with the playable prototype. Output: `V02/Builds/Android/AeroDash-V02.apk`.

## Status
The repository contains a build script, not a compiled APK. It has not been validated in Unity or on a physical Android device. For Play Store publication, signing, store assets, policy compliance and production QA are still required.
