using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    float timeForARound = 10;

    enum State {
        IDLE,
        P1_PLAYING,
        P1_BUILDING,
        P2_PLAYING,
        P2_BUILDING
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

    State state = State.IDLE;
    float currentTimer = 0;

    bool objectHasBeenDrop = false;

	// Use this for initialization
	void Start () {
        state = State.P1_BUILDING;
        buildManager = FindObjectOfType<BuildManager>();
        levelController = FindObjectOfType<LevelController>();
	}
	
	// Update is called once per frame
	void Update () {
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
                if(!buildManager.IsRunning()) {
                    buildManager.Launch();
                }
                if(objectHasBeenDrop) {
                    currentTimer = 0;
                    state = State.P2_PLAYING;
                    player2Instance = Instantiate(player2Prefab, levelController.GetStartPosition(), Quaternion.identity);
                    buildManager.Stop();
                    objectHasBeenDrop = false;
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
                if(!buildManager.IsRunning()) {
                    buildManager.Launch();
                }
                if(objectHasBeenDrop) {
                    currentTimer = 0;
                    state = State.P1_PLAYING;
                    player1Instance = Instantiate(player1Prefab, levelController.GetStartPosition(), Quaternion.identity);
                    buildManager.Stop();
                    objectHasBeenDrop = false;
                }
                break;
        }
	}

    public void AddObject() {
        objectHasBeenDrop = true;
    }

    public void PlayerWin() {
        currentTimer = timeForARound;
    }

    public void PlayerDie() {
        currentTimer = timeForARound;
    }
}
