using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadingPopUp : MonoBehaviour
{
    public Image black_background;
    Vector3 tempPos;

    private void Start()
    {
        fading_if_clicked(false);
        tempPos = transform.position;
    }

    public void fading_if_clicked(bool test)
    {
        if (test)
        {
            tempPos.x = 0f;
            transform.position = tempPos;
        }
        else
        {
            tempPos.x = -20f;
            transform.position = tempPos;
        }

        CanvasGroup canvasGr = GetComponent<CanvasGroup>();
        canvasGr.alpha = test ? 1 : 0;
        canvasGr.interactable = test;

        black_background.enabled = test;
    }
}
