using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject cell;
	public GameObject explosion;

	private GameObject[][] board;

	private float nextActionTime = 5.0f;

	public float period = 0.1f;

	private int boardSize = 50;

	private GameOfLife gol;

	void Start () {
		gol = new GameOfLife (50);

		board = createBoard ();

		addSquare (0, 0);
		addSquare (0, boardSize-5);
		addSquare (boardSize-5, boardSize-5);
		addSquare (boardSize-5, 0);

		addSquare (23, 23);
		addSquare (25, 25);

		addCell(board, 3,5);
		addCell(board, 3,6);
		addCell(board, 4,5);

		addCell(board, 6,7);
		addCell(board, 6,8);
		addCell(board, 5,8);


		addCell(board, 25,5);
		addCell(board, 25,6);
		addCell(board, 25,7);

		addCell(board, 35,30);
		addCell(board, 35,31);
		addCell(board, 35,32);

		addCell(board, 25,40);
		addCell(board, 25,41);
		addCell(board, 25,42);




		addCell(board, 10,10);
		addCell(board, 11,10);
		addCell(board, 12,10);

		addCell(board, 10,11);
		addCell(board, 12,11);

		addCell(board, 10,12);
		addCell(board, 11,12);
		addCell(board, 12,12);

		addCell(board, 10,13);
		addCell(board, 11,13);
		addCell(board, 12,13);

		addCell(board, 10,14);
		addCell(board, 11,14);
		addCell(board, 12,14);


		addCell(board, 10,15);
		addCell(board, 11,15);
		addCell(board, 12,15);

		addCell(board, 10,16);
		addCell(board, 12,16);


		addCell(board, 10,17);
		addCell(board, 11,17);
		addCell(board, 12,17);

		// glider
		addGlider (20, 10);

		addGlider (30, 4);


		addGlider (40, 15);

	}

	void addGlider(int x, int y) {
		addCell(board, x+3,y+1);
		addCell(board, x+1,y+2);
		addCell(board, x+3,y+2);
		addCell(board, x+2,y+3);
		addCell(board, x+3,y+3);

	}

	void addSquare(int x, int y) {
		addCell(board, x,y);
		addCell(board, x+1,y);
		addCell(board, x,y+1);
	}
	
	void Update () {

		if (Time.time > nextActionTime ) {
			nextActionTime += period;
			updateBoard();
		}
	
	}

	GameObject[][] createBoard() {

		GameObject[][] newBoard = new GameObject[boardSize][];
		for (int i=0; i < boardSize; i++) {
			newBoard[i] = new GameObject[boardSize];
		};
		return newBoard;
	}

	void updateBoard() {
		GameObject[][] newBoard = createBoard ();

		gol.nextGeneration ();

		for (int i=0; i < boardSize; i++) {
			for (int j=0; j < boardSize; j++) {
				if (gol.board[i][j]) {
					addCell(newBoard, i, j);
				} else if ((board[i][j]) && !gol.board[i][j]) {
					Instantiate (explosion, board[i][j].transform.position, board[i][j].transform.rotation);
				}
			}
		}

		replaceBoard (newBoard);
	}

	void replaceBoard(GameObject[][] newBoard) {

		for (int i=0; i < boardSize; i++) {
			for (int j=0; j < boardSize; j++) {
				if (board[i][j]) {
					Destroy(board[i][j]);
				}
			}
		}

		board = newBoard;
	}

	void addCell(GameObject[][] aBoard, int x, int z) {
		GameObject newcell = Instantiate<GameObject>(cell);
		newcell.transform.position = new Vector3(x, 1, z);

		aBoard [x] [z] = newcell;
		gol.addCell (x, z);
	}
}
