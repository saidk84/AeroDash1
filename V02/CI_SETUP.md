# GitHub Actions APK build

Workflow: `.github/workflows/aerodash-v02-android.yml`

1. Configure a valid Unity license via repository Actions secrets. The GameCI Unity Builder supports `UNITY_LICENSE` or appropriate Unity account credentials, depending on license type. Do not commit credentials.
2. Open GitHub > Actions > AeroDash V02 Android APK > Run workflow.
3. After a successful run, download `AeroDash-V02-Android-APK` from the workflow artifacts.

The workflow is manual to avoid failing every push before license setup. It has not been executed or validated yet. Build failures may require updating Unity version, packages, Android SDK settings or GameCI configuration. No APK exists until a successful build completes.
