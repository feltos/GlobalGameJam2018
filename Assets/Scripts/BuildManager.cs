using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    bool isRunning = true;
    bool gridDispaly = false;

    List<GameObject> grid;
    public GameObject cellForGrid;

    LevelController levelController;

    int SelectedObject = 1;
    GameObject tmpObjectToPlace;

    struct Coord {
        public int x;
        public int y;

        public Coord PixelToCoord(float x, float y) {
            Coord tmp;
            tmp.x = (int)x - 1;
            tmp.y = (int)y;

            return tmp;
        }

        public string Write() {
            return "x = " + x + ", y = " + y;
        }
    }

    Coord coord;

	// Use this for initialization
	void Start () {
        levelController = FindObjectOfType<LevelController>();

        grid = new List<GameObject>();
	    for(int i = 0; i < 50; i++) {
            for(int j = 0; j < 20; j++) {
                GameObject tmpCell = Instantiate(cellForGrid, new Vector2(i, j), Quaternion.identity);
                grid.Add(tmpCell);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(isRunning) {

            if(!gridDispaly) {
                DisplayGrid();
            }

            Vector3 pointeur = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            coord = coord.PixelToCoord(pointeur.x, pointeur.y);
            Debug.Log(coord.Write());

            if(Input.GetButtonDown("Fire1")) {
                Instantiate(levelController.prefabBrick[SelectedObject], new Vector2(coord.x, coord.y), Quaternion.identity);
            }

            if(tmpObjectToPlace != null) {
                Destroy(tmpObjectToPlace);
            }
            tmpObjectToPlace = Instantiate(levelController.prefabBrick[SelectedObject], new Vector2(coord.x, coord.y), Quaternion.identity);
        }

        if(gridDispaly) {
            HideGrid();
        }
	}

    void DisplayGrid() {
        //for(int i = 0; i < grid.Capacity;i++) {
        //    grid[i].SetActive(true);
        //}

        //gridDispaly = true;
    }

    void HideGrid() {
        for(int i = 0;i < grid.Capacity;i++) {
            grid[i].SetActive(false);
        }

        gridDispaly = false;
    }

    public bool IsRunning() {
        return isRunning;
    }
}
