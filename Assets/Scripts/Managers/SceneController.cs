using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

public class SceneController : SingletonBehaviour<SceneController>
{
    public int CurrentScene;
    public override void Instantiate() { }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
    }
    public void OnSceneLoad(Scene scene, LoadSceneMode sceneMode)
    {
        CurrentScene = scene.buildIndex;

        MusicPlayer.Instance.SwitchCollection(CurrentScene, 0, 8);
    }
    public void LoadNewScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    
}
