using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HubLoader : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI progressText, level1Text;
    void Start()
    {
		progressText.text = $"Current progress is: {StaticProgress.levelsCleared}";
		if (StaticProgress.levelsCleared > 0)	//	You could do any logic here after we have checked progress. Enable and disable objects, etc
			level1Text.text = "This appeared because level 1 was cleared";
    }
}
