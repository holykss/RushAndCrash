using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System;

class JenkinsBuilder
{
	static string[] SCENES = FindEnabledEditorScenes();

	static string APP_NAME = "RushAndCrash";
	static string TARGET_DIR = "";

	[MenuItem("Custom/CI/Build Android")]
	static void PerformAndroidBuild()
	{
		string target_dir = APP_NAME + ".app";
		GenericBuild(SCENES, TARGET_DIR + "/" + target_dir, BuildTarget.WebPlayer, BuildOptions.None);
	}

	private static string[] FindEnabledEditorScenes()
	{
		List<string> EditorScenes = new List<string>();
		foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
		{
			if (!scene.enabled) continue;
			EditorScenes.Add(scene.path);
		}
		return EditorScenes.ToArray();
	}

	static void GenericBuild(string[] scenes, string target_dir, BuildTarget build_target, BuildOptions build_options)
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(build_target);
		string res = BuildPipeline.BuildPlayer(scenes, target_dir, build_target, build_options);
		if (res.Length > 0)
		{
			throw new Exception("BuildPlayer failure: " + res);
		}
	}
}