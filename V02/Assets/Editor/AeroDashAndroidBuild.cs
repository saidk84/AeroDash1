using System;
using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class AeroDashAndroidBuild
{
    const string ScenePath = "Assets/Scenes/AeroDash.unity";

    [MenuItem("AeroDash/Build Android APK")]
    public static void BuildAndroid()
    {
        Directory.CreateDirectory("Assets/Scenes");
        if (!File.Exists(ScenePath))
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            EditorSceneManager.SaveScene(scene, ScenePath);
        }
        PlayerSettings.companyName = "AeroDash";
        PlayerSettings.productName = "AeroDash V02";
        PlayerSettings.SetApplicationIdentifier(NamedBuildTarget.Android, "com.aerodash.skylinecourier");
        PlayerSettings.defaultInterfaceOrientation = UIOrientation.LandscapeLeft;
        PlayerSettings.Android.bundleVersionCode = 2;
        PlayerSettings.bundleVersion = "0.2.0";
        EditorUserBuildSettings.buildAppBundle = false;
        Directory.CreateDirectory("Builds/Android");
        var report = BuildPipeline.BuildPlayer(
            new[] { ScenePath },
            "Builds/Android/AeroDash-V02.apk",
            BuildTarget.Android,
            BuildOptions.None);
        if (report.summary.result != BuildResult.Succeeded)
            throw new Exception("Android build failed: " + report.summary.result);
        Debug.Log("APK created at Builds/Android/AeroDash-V02.apk");
    }
}
