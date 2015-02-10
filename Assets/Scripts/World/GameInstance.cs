using UnityEngine;
using System.Collections;

public class GameInstance : MonoBehaviour {
	/* Game instance acts as the world manager
	 * Persistent singleton, doesn't destroy on load
	 * (nor do other components on the same game object!)
	 */

	/* game instance requires a game mode object
	 * to make game mode not persist through load, it's on another object
	 */
	GameObject gameModeObject;
	public GameMode aGameMode { get; private set; }
	public int survivalHighScore;
	public int timeAttackHighScore;

	private static GameInstance _instance;
	public static GameInstance instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<GameInstance>();

				DontDestroyOnLoad(_instance.gameObject);
			}

			return _instance;
		}
	}

	void Awake()
	{
		if(_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}

	void OnLevelWasLoaded(int levelIndex)
	{
		//reset the game mode reference from the new gamemode object
		if (aGameMode == null || gameModeObject == null)
		{
			//look for game mode object in scene
			if (gameModeObject == null)
				gameModeObject = GameObject.Find("GameMode");
			
			//if there's no game mode object, make a default one
			if (gameModeObject == null)
			{
				gameModeObject = new GameObject("GameMode");
				aGameMode = gameModeObject.AddComponent<GameMode>();
			}
			
			//if game mode object exists, get its game mode component or make one
			else
			{
				aGameMode = gameModeObject.GetComponent<GameMode>();
				if (aGameMode == null)
					aGameMode = gameModeObject.AddComponent<GameMode>();
			}
		}
	}
}
