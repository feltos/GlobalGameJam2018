using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField]
    Text text;

    [SerializeField]
    float timeForARound = 20;

    enum State {
        IDLE,
        P1_PLAYING,
        P1_BUILDING,
        P2_PLAYING,
        P2_BUILDING,
        END
    }

    [SerializeField]
    GameObject player1Prefab;
    [SerializeField]
    GameObject player2Prefab;

    GameObject player1Instance;
    GameObject player2Instance;

    Transform startPosition;

    LevelController levelController;
    BuildManager buildManager;
    TimeRemaning timeRemaning;

    int round = 0;
    const int MAX_ROUND = 16;

    State state = State.IDLE;
    float currentTimer = 0;

    bool objectHasBeenDrop = false;

    int p1win = 0;
    int p2win = 0;

	// Use this for initialization
	void Start () {
        timeRemaning = FindObjectOfType<TimeRemaning>();

        state = State.P1_BUILDING;
        buildManager = FindObjectOfType<BuildManager>();
        levelController = FindObjectOfType<LevelController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(round > MAX_ROUND) {
            state = State.END;
        }
        
        switch(state) {
            case State.IDLE:
                break;

            case State.P1_PLAYING:
                currentTimer += Time.deltaTime;

                if(currentTimer > timeForARound) {
                    state = State.P1_BUILDING;
                    Destroy(player1Instance);
                    buildManager.Launch();
                }
                break;

            case State.P1_BUILDING:
                if(round == MAX_ROUND) {
                    state = State.END;
                } else {
                    if(!buildManager.IsRunning()) {
                        buildManager.Launch();
                    }
                    if(objectHasBeenDrop) {
                        currentTimer = 0;
                        state = State.P2_PLAYING;
                        player2Instance = Instantiate(player2Prefab, levelController.GetStartPosition(), Quaternion.identity);
                        buildManager.Stop();
                        objectHasBeenDrop = false;
                        timeRemaning.SetTimeForLevel(timeForARound);
                        round++;
                    }
                }
                break;

            case State.P2_PLAYING:
                currentTimer += Time.deltaTime;

                if(currentTimer > timeForARound) {
                    state = State.P2_BUILDING;
                    Destroy(player2Instance);
                    buildManager.Launch();
                }
                break;

            case State.P2_BUILDING:
                if(round == MAX_ROUND) {
                    state = State.END;
                } else {
                    if(!buildManager.IsRunning()) {
                        buildManager.Launch();
                    }
                    if(objectHasBeenDrop) {
                        currentTimer = 0;
                        state = State.P1_PLAYING;
                        player1Instance = Instantiate(player1Prefab, levelController.GetStartPosition(), Quaternion.identity);
                        buildManager.Stop();
                        objectHasBeenDrop = false;
                        timeRemaning.SetTimeForLevel(timeForARound);
                        round++;
                    }
                }
                break;

            case State.END:
                buildManager.Stop();
                if(p1win == p2win) {
                    text.text = "DRAW";
                }else if(p1win > p2win) {
                    text.text = "PLAYER 1 WIN";
                } else {
                    text.text = "PLAYER 2 WIN";
                }
                break;
        }
	}

    public void AddObject() {
        objectHasBeenDrop = true;
    }

    public void PlayerWin() {
        currentTimer = timeForARound;
        if(state == State.P1_PLAYING) {
            p1win++;
        }
        if(state == State.P2_PLAYING) {
            p2win++;
        }
    }

    public void PlayerDie() {
        currentTimer = timeForARound;
    }
}
