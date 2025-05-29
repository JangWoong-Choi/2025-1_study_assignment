using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager MyUIManager;

    public GameObject Character;
    public GameObject CamObj;
    
    const float CharacterSpeed = 3f;

    public int NowScore = 0;

    void Awake()
    {
        MyUIManager.DisplayScore(NowScore);
        MyUIManager.DisplayMessage("", 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    // For smooth cam moving, it's good to use LateUpdate.
    void LateUpdate()
    {
        MoveCam();
    }

    void MoveCam()
    {
        if (Character != null && CamObj != null)
        {
            Vector3 newPos = new Vector3(Character.transform.position.x, Character.transform.position.y, CamObj.transform.position.z);
            CamObj.transform.position = newPos;
        }
    }

    void MoveCharacter()
    {
        if (Character != null)
        {
            Character.transform.position += Vector3.right * CharacterSpeed * Time.deltaTime;
        }
    }

    public void GameOver()
    {
        if (Character != null)
        {
            Destroy(Character);
        }
        MyUIManager.DisplayMessage("Game Over!", 3f);
        MyUIManager.RestartButton.SetActive(true);
    }

    public void GetPoint(int point)
    {
        {
            NowScore += point;
            MyUIManager.DisplayScore(NowScore);
        }
    }

    // Restart the game
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
