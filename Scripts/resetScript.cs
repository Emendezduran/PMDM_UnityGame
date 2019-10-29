using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetScript : MonoBehaviour
{
    //metodo que reinicia la escena
    public void resetGame()
    {
        SceneManager.LoadScene("MiniGame");
    }
}
