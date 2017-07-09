using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score {
	private int score = Fractal.Frames + StuffSpawner.Frames + NucleonSpawner.Frames;
	private int max = 4600;

	public int getScore() {
		return score;
	}

	public int getGrade() {
		return (score*10 / max);
	}
}
