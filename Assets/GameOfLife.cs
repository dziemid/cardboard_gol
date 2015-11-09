using System.Collections;

public class GameOfLife {
	
	private int boardSize;
	
	public bool[][] board;
	
	public GameOfLife(int boardSize) {
		this.boardSize = boardSize;
		this.board = createBoard ();
	}
	
	bool[][] createBoard() {
		
		bool[][] newBoard = new bool[boardSize][];
		for (int i=0; i < boardSize; i++) {
			newBoard[i] = new bool[boardSize];
		};
		return newBoard;
	}
	
	public void nextGeneration() {
		bool[][] newBoard = createBoard ();
		for (int i=0; i < boardSize; i++) {
			for (int j=0; j < boardSize; j++) {
				int neighboursCount = aliveNeighbours(i, j);
				
				if (board[i][j] && (neighboursCount == 2 || neighboursCount == 3)) {
					addCell(newBoard, i, j);
				}
				
				else if (!board[i][j] && neighboursCount == 3) {
					addCell(newBoard, i, j);
				}
			}
		}
		
		board = newBoard;
	}
	
	public void addCell(int x, int z) {
		addCell (board, x, z);
	}
	
	void addCell(bool[][] aBoard, int x, int z) {
		aBoard [x] [z] = true;
	}
	
	int aliveNeighbours(int x, int y) {
		int neighboursCount = 0;
		
		if (y - 1 >= 0) {
			if (x - 1 >= 0 && board [x - 1] [y - 1]) {
				neighboursCount++;
			}
			if (board [x] [y - 1]) {
				neighboursCount++;
			}
			if (x + 1 < boardSize && board [x + 1] [y - 1]) {
				neighboursCount++;
			}
		}
		
		if (x - 1 >= 0 && board[x-1][y]) {
			neighboursCount++;
		}
		if (x + 1 < boardSize && board[x+1][y]) {
			neighboursCount++;
		}
		
		if (y + 1 < boardSize) {
			if (x - 1 >= 0 && board [x - 1] [y + 1]) {
				neighboursCount++;
			}
			if (board [x] [y + 1]) {
				neighboursCount++;
			}
			if (x + 1 < boardSize && board [x + 1] [y + 1]) {
				neighboursCount++;
			}
		}
		
		return neighboursCount;
	}
}

