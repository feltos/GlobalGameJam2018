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
            int a = (int)(x - 0f);
            if(x - a > 0.5) {
                tmp.x = a + 1;
            } else {
                tmp.x = a;
            }

            int b = (int)(y - 0f);
            if(y - b > 0.5) {
                tmp.y = b + 1;
            } else {
                tmp.y = b;
            }
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
	    for(int i = 0; i < 18; i++) {
            for(int j = 0; j < 10; j++) {
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

            //Check where is the cursor
            Vector3 pointeur = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            coord = coord.PixelToCoord(pointeur.x, pointeur.y);

            //Manage Input
            if(Input.GetButtonDown("Fire1") && levelController.CanPlace(coord.x, coord.y) && SelectedObject != 0) {
                levelController.AddObject(coord.x, coord.y, SelectedObject);
            }

            if(Input.GetButtonDown("Fire1") && !levelController.CanPlace(coord.x, coord.y) && SelectedObject == 0) {
                levelController.RemoveObject(coord.x, coord.y);
            }

            if(tmpObjectToPlace != null) {
                Destroy(tmpObjectToPlace);
            }

            //Change selected object
            SelectObject(Input.GetAxis("Mouse ScrollWheel"));

            tmpObjectToPlace = Instantiate(levelController.prefabBrick[SelectedObject], new Vector3(coord.x, coord.y, -1), Quaternion.identity);
            tmpObjectToPlace.GetComponent<SpriteRenderer>();

            Color tmp = new Color(1,1,1,0.5f);
            if(!levelController.CanPlace(coord.x, coord.y)) {
                tmp.g = 0;
                tmp.b = 0;
            }

            if(SelectedObject == 0) {
                tmp.a = 1;
            }

            tmpObjectToPlace.GetComponent<SpriteRenderer>().color = tmp;
        }

        if(gridDispaly) {
            HideGrid();
        }
	}

    void SelectObject(float offsetIndex) {
        if(offsetIndex <= -0.1f) {
            if(SelectedObject == 0) {
                SelectedObject = levelController.prefabBrick.Capacity;
            } else {
                SelectedObject--;
            }
        }else if(offsetIndex >= 0.1f) {
            if(SelectedObject == levelController.prefabBrick.Capacity) {
                SelectedObject = 0;
            } else {
                SelectedObject++;
            }
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
