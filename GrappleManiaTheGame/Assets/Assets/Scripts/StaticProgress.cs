using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//	In this script (Which is NOT a MonoBehaviour and it does NOT exist on a GameObject in the scene) we track progress.
//	In theory we could also save the data from this script to a file and load it back up for persistent progress tracking.

//	We use the static keyword. That means this class does NOT behave like an object - there can only ever be a single instance of this class
//	This also means we don't need a object reference to this class. We only ever track progress in one place, that is this static "instance"
//	This is sometimes called a singleton, and should only be used sparingly because you risk having a lot of unnecessary scripts loaded
public static class StaticProgress 
{
	public static Vector3 currentCheckpoint;

	//	The following is for tracking player progress not only within a level, but between levels

	//	We can track player progress in any number of ways. Each stage could have a bool that is set when we complete it
	//	Or if the stages appear linearly one by one, we can just have a single int that updates to our progress

	public static int levelsCleared = 0;
}
