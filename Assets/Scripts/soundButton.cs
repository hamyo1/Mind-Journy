using UnityEngine;

public class soundButton : MonoBehaviour
{
    public AudioSource myfx;
    public AudioClip clickFx;

    public void ClickSound()
    {
        myfx.PlayOneShot(clickFx);

    }

}
