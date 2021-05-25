using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        yield return new WaitForSeconds(secondsToWait);

        LoadNextScene();

    }

}
