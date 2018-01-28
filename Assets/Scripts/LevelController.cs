using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField]
    int nbCaseHeight = 20;
    [SerializeField]
    int nbCaseLength = 50;
    [SerializeField]
    GameObject start;
    [SerializeField]
    GameObject end;

    int[,] map;

    #region CONSTANT

    int IDEmptyCase = 0;
    int IDStartCase = -1;

    #endregion

    public List<GameObject> prefabBrick;

    List<GameObject> allObjectInLevel;

    // Use this for initialization
    void Start () {
        map = new int[nbCaseLength + 1, nbCaseHeight + 1];

        allObjectInLevel = new List<GameObject>();
        for(int i = 0; i < nbCaseLength * nbCaseHeight;i++) {
            allObjectInLevel.Add(null);
        }

        for(int i = 0;i != nbCaseLength;i++) {
            for(int j = 0;j != nbCaseHeight;j++) {
                map[i, j] = IDEmptyCase;
            }
        }

        BuildDefaultMap();
    }

    void BuildDefaultMap() {
        AddObject(0, 3, IDStartCase);
        AddObject(1, 3, 1);
        AddObject(0, 0, 1);
        AddObject(1, 0, 1);
        AddObject(0, 7, 1);
        AddObject(1, 7, 1);
    }

    public void AddObject(int x, int y, int index) {
        map[x, y] = index;
        if(index < 0) {
            allObjectInLevel[x + (y * x)] = Instantiate(start, new Vector2(x, y), Quaternion.identity);
        } else {
            allObjectInLevel[x + (y * x)] = Instantiate(prefabBrick[index], new Vector2(x, y), Quaternion.identity);
        }
    }

    public void RemoveObject(int x, int y) {
        map[x, y] =IDEmptyCase;
        Destroy(allObjectInLevel[x + (y * x)]);
        allObjectInLevel[x + (y * x)] = null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public Vector3 GetStartPosition() {
        return new Vector3(0,4,0);
    }

    public bool CanPlace(int i, int j) {
        bool isFree = true;
        if(i < 0 || i > nbCaseLength || j < 0 || j > nbCaseHeight) {
            return false;
        }

        if(!IsEmpty(i, j)) {
            isFree = false;
        }

        if(i == 0 || i == nbCaseLength) {
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
