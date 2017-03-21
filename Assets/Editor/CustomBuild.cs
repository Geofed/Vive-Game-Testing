using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class CustomBuild {


	[MenuItem("File/Build Server")]
	static void BuildWindowsServer() {
		string path = Path.Combine (Application.dataPath, "../Build");
		path = Path.Combine (path, "testserver.exe");
		PlayerSettings.virtualRealitySupported = false;
		BuildPipeline.BuildPlayer (EditorBuildSettings.scenes, path, BuildTarget.StandaloneWindows64, BuildOptions.AutoRunPlayer | BuildOptions.AllowDebugging | BuildOptions.Development);
		PlayerSettings.virtualRealitySupported = true;
	}

}
