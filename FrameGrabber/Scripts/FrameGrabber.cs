// Peter Parnes, peter@parnes.com, 20170406 
//
// Convert to movie using ffmpeg // fast 
// ffmpeg -v verbose -framerate 60 -i 'Frame_20170411_094556_%04d.png' movie.m4v
//
// Convert to movie via ImageMagick // slow 
// convert -quality 100 Frame_20170406_020819_0* movie.m4v  // slow 

using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;

public class FrameGrabber : MonoBehaviour {

	static string defaultPath = "Assets/Capture";

	public bool capture = false; 
	public string path = defaultPath;
	public int superSize = 1;
	public int frameRate = 60;

	string baseName = "Frame";
	string startFileName = "";

	void Start () {
		Time.captureFramerate = frameRate;

		if (path == "") {
			path = defaultPath;
		}
			
		if (!Directory.Exists (path)) { 
			Directory.CreateDirectory (path);
		}
	}

	void Update() {
		if (capture) {
			string filename = CreateFileName ();
			// Debug.Log (filename);
			Application.CaptureScreenshot (filename, superSize); 
		}
	}

	string CreateFileName() {
		if (startFileName == "") {
			startFileName = path + "/" + baseName + "_" + System.DateTime.Now.ToString ("yyyyMMdd") + "_" + System.DateTime.Now.ToString ("hhmmss");
		}

		return name = string.Format ("{0}_{1:D04}.png", startFileName, Time.frameCount);
	}

}
