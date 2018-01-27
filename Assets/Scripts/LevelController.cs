using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField]
    int nbCaseHeight = 20;
    [SerializeField]
    int nbCaseLength = 50;
    
    int[,] map;

    #region CONSTANT

    int IDEmptyCase = 0;

    #endregion

    public List<GameObject> prefabBrick;

    // Use this for initialization
    void Start () {
        map = new int[nbCaseLength, nbCaseHeight];

        for(int i = 0;i < nbCaseLength;i++) {
            for(int j = 0;j < nbCaseHeight;j++) {
                map[i, j] = IDEmptyCase;
            }
        }

        BuildDefaultMap();
    }

    void BuildDefaultMap() {
        map[0, 10] = 1;
        Instantiate(prefabBrick[1], new Vector2(0, 10), Quaternion.identity);
        map[1, 10] = 1;
        Instantiate(prefabBrick[1], new Vector2(1, 10), Quaternion.identity);
        map[2, 10] = 1;
        Instantiate(prefabBrick[1], new Vector2(2, 10), Quaternion.identity);

        map[6, 10] = 1;
        Instantiate(prefabBrick[1], new Vector2(6, 10), Quaternion.identity);
        map[7, 10] = 1;
        Instantiate(prefabBrick[1], new Vector2(7, 10), Quaternion.identity);
        map[8, 10] = 1;
        Instantiate(prefabBrick[1], new Vector2(8, 10), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    bool CanPlace(int i, int j) {
        bool isFree = true;

        if(!IsEmpty(i, j)) {
            isFree = false;
        }

        return isFree;
    }

    bool IsEmpty(int i, int j) {
        return map[i, j] == IDEmptyCase;
    }

    void WriteMapDebug() {
        for(int i = 0; i < nbCaseLength;i++) {
            for(int j = 0;j < nbCaseHeight;j++) {
                Debug.Log("[" + i + "," + j + "] = " + map[i, j]);
            }
        }
    }
}
