using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuCam;
    public GameObject inGameCam;
    public Player player;
    public float playTime;

    public GameObject menuPanel;
    public GameObject gamePanel;
    public GameObject overPanel;
    public Text friChickenAText;
    public Text friChickenBText;
    public Text playTimeText;
    public Text playerChicknText;

    void Awake()
    {

    }

    public void GameStart()
    {
        menuCam.SetActive(false);
        inGameCam.SetActive(true);

        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    void Update()
    {
        playTime += Time.deltaTime;
    }

    void LateUpdate()
    {
        //시간UI
        int hour = (int)(playTime / 3600);
        int min = (int)((playTime - hour * 3600) / 60);
        int second = (int)(playTime % 60);
        playTimeText.text = string.Format("{0:00}", hour) + ":"
                           + string.Format("{0:00}", min) + ":"
                           + string.Format("{0:00}", second);

        //완성된 치킨UI
        friChickenAText.text = player.friChickenA + "  /  " + player.maxFriChickenA;
        friChickenBText.text = player.friChickenB + "  /  " + player.maxFriChickenB;

        //치킨 재료UI
        playerChicknText.text = player.chicken + "  /  " + player.maxChicken;
    }

    public void GameOver()
    {
        gamePanel.SetActive(false);
        overPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
