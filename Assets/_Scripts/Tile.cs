using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tile : MonoBehaviour {
	public bool mine;

	public Sprite[] emptyTextures;
	public Sprite mineTexture;

	public Text winText;
	public Text loseText;

	// Use this for initialization
	void Start () {
		mine = Random.value < 0.13;

		winText = GameObject.Find("wintext").GetComponent<Text>();
		loseText = GameObject.Find("losetext").GetComponent<Text>();

		int x = (int)transform.position.x;
		int y = (int)transform.position.y;
		gameController.elements[x, y] = this;
	}

	public void loadTexture(int adjacentCount) {
		if (mine)
			GetComponent<SpriteRenderer>().sprite = mineTexture;
		else
			GetComponent<SpriteRenderer>().sprite = emptyTextures[adjacentCount];
	}

	public bool isCovered() {
		return GetComponent<SpriteRenderer>().sprite.texture.name == "default";
	}

	void OnMouseUpAsButton() {
		if (mine) {
			gameController.uncoverMines ();
			loseText.text = "You lose!";

		} else {
			
				int x = (int)transform.position.x;
				int y = (int)transform.position.y;

				loadTexture (gameController.adjacentMines (x, y));

				gameController.FFuncover (x, y, new bool[gameController.w, gameController.h]);

				if (gameController.isFinished ())
					winText.text = "You found all mines!";

		}

	}
	}


