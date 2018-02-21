using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	private int lives = 3;
	private int score = 0;

	public Vector3 spawnPosition;
	public Transform playerTransform;

	private void Update()
	{
		if (playerTransform.position.y < -50)	// player falls and dies
		{
			playerTransform.position = spawnPosition;
			lives--;
		}
	}
}
