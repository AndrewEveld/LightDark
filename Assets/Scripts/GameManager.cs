using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public int sceneToLoad;
    private AudioSource sound;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        sound = GetComponent<AudioSource>();

    }
    void Update()
    {
        if (!sound.isPlaying)
        {
            sound.Play();
        }
    }
    public void nextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
        sceneToLoad++;
    }
}
