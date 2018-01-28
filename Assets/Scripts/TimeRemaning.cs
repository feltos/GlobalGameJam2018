using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRemaning : MonoBehaviour {

    [SerializeField]
    Text textSeconds;

    float timeInSeconds = 0;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void SetTimeForLevel(float time) {
        timeInSeconds = time;
        StartCoroutine(ClockAnimation());
    }

    IEnumerator ClockAnimation() {
        while(timeInSeconds > 0) {
            timeInSeconds -= 1;
            DisplayTime();

            yield return new WaitForSeconds(1);
        }
    }

    void DisplayTime() {
        if((timeInSeconds % 60) < 10) {
            textSeconds.text = "0" + (timeInSeconds % 60).ToString();
        } else {
            textSeconds.text = (timeInSeconds % 60).ToString();
        }
    }
}
