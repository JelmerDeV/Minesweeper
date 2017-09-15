using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController {

	public static int w = 16; 
	public static int h = 16; 
	public static Tile[,] elements = new Tile[w, h];



	public static void uncoverMines() {
		foreach (Tile elem in elements)
			if (elem.mine)
				elem.loadTexture(0);
	}

	public static bool mineAt(int x, int y) {
		// Coordinates in range? Then check for mine.
		if (x >= 0 && y >= 0 && x < w && y < h)
			return elements[x, y].mine;
		return false;
	}

	public static int adjacentMines(int x, int y) {
		int count = 0;

		if (mineAt(x,   y+1)) ++count; 
		if (mineAt(x+1, y+1)) ++count; 
		if (mineAt(x+1, y  )) ++count; 
		if (mineAt(x+1, y-1)) ++count; 
		if (mineAt(x,   y-1)) ++count; 
		if (mineAt(x-1, y-1)) ++count; 
		if (mineAt(x-1, y  )) ++count; 
		if (mineAt(x-1, y+1)) ++count; 

		return count;
	}

	public static void FFuncover(int x, int y, bool[,] visited) {
		if (x >= 0 && y >= 0 && x < w && y < h) {
			// visited already?
			if (visited [x, y])
				return;


			elements[x, y].loadTexture(adjacentMines(x, y));

		
			if (adjacentMines(x, y) > 0)
				return;



			visited [x, y] = true;

		
			FFuncover (x - 1, y, visited);
			FFuncover (x + 1, y, visited);
			FFuncover (x, y - 1, visited);
			FFuncover (x, y + 1, visited);
		}
	}


	public static bool isFinished() {
		
		foreach (Tile elem in elements)
			if (elem.isCovered() && !elem.mine)
				return false;
		
		return true;
	}
}
