using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioSource sound1, sound2, sound3;

    public void Play_Sound_Now(int number)
    {
        switch (number)
        {
            case 1: sound1.Play();
                break;
            case 2: sound2.Play();
                break;
            case 3: sound3.Play();
                break;
        }
    }

}
