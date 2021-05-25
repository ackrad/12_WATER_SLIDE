using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameController instance;

    public static GameController Instance { get { return instance; } }

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
    {

  

    }

    // Update is called once per frame
    void Update()
    {
        

    }


    public void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCount)
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
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerCoinData data = new PlayerCoinData
        {
            coinAmount = coinAmount
        };

        bf.Serialize(file, data);

        file.Close();

    }

    private void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath+"/playerInfo.dat", FileMode.Open);
            PlayerCoinData data = (PlayerCoinData) bf.Deserialize(file);
            file.Close();

            coinAmount = data.coinAmount;
            IncreaseCoins(0); // burayý daha düzgün yaz sonra stringi update etmek için kullanýyorsun
        }



    }

}


[Serializable]
class PlayerCoinData
{
    public int coinAmount;
}