using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShiftScene : MonoBehaviour
{

    public void Shift_Scene(int id)
    {
        SceneManager.LoadScene(id);
    }
}
