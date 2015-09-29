using UnityEngine;
using System.Collections;

public class ChessBoardGenerator : MonoBehaviour {
    public GameObject whiteTile, blackTile;
    public float size = 1.5f;
	public int hW = 8;

    //private GameObject[,] chessBoard;
    private string[] letters = new string[8] {"A", "B", "C", "D", "E", "F", "G", "H" };
    private GameObject currentTile;
	private float startPos = 0f;

    void Start () {
		startPos = 0 - (size * (hW/2));
        //chessBoard = new GameObject[8, 8];
        generateChessboard();
    }

    void generateChessboard() {
        currentTile = blackTile;
		for(int n = 1; n <= hW; n++) {
            for(int l = 0; l < hW; l++) {
				GameObject temp = (GameObject) Instantiate(currentTile, new Vector3(startPos + (n * size), startPos + (l * size), 0), Quaternion.identity);
                temp.transform.parent = transform;
                temp.transform.name = letters[l] + n;
                //chessBoard[l, n-1] = temp;
                if(l != 7) switchTile();
            }
        }
    }

    void switchTile() {
        if(currentTile == whiteTile) {
            currentTile = blackTile;
            return;
        }
        currentTile = whiteTile;
    }
}
