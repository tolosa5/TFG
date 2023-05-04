using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeTOGameScene : MonoBehaviour
{
    public void ChangeToGame()
    {
        SceneManager.LoadScene(1);
    }
}
