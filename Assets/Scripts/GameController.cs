using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameController instance;

    public static GameController Instance { get { return instance; } }
    public Button loadNextSceneButton;

    private int coinAmount;
    [SerializeField] TMPro.TMP_Text text;
    [SerializeField] float secondsToWait = 2f;
    

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
        Load();

    }
    void Start()
    {       //TODO Bu buttonu scene index 0 ise koddan yaratýp kullanmayý dene?
        loadNextSceneButton.onClick.AddListener(LoadNextScene);

  

    }

    // Update is called once per frame
    void Update()
    {
        

    }


    public void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


    }




    public void IncreaseCoins(int coinAmountToIncrease)
    {

        coinAmount += coinAmountToIncrease;

        text.text = coinAmount.ToString();
    }

    public void WinGame(int coinAmountToIncrease)
    {
        StartCoroutine(WinGameSchedule(coinAmountToIncrease));

    }

    private IEnumerator WinGameSchedule(int coinAmountToIncrease)
    {
        IncreaseCoins(coinAmountToIncrease);

        Save();
        yield return new WaitForSeconds(secondsToWait);

        LoadNextScene();

    }



    private void Save()
    {
        PlayerPrefs.SetInt("coinAmount", coinAmount);
        PlayerPrefs.Save();

    }

    private void Load()
    {
        coinAmount = PlayerPrefs.GetInt("coinAmount");


    }

}


[Serializable]
class PlayerCoinData
{
    public int coinAmount;
}