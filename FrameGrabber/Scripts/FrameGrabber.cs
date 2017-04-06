// Peter Parnes, peter@parnes.com, 20170406 
//
// Convert to movie via ImageMagick 
// convert -quality 100 Frame_20170406_020819_0* movie.m4v

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
