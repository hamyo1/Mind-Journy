using UnityEngine;
using UnityEngine.SceneManagement;

public class menTouch : MonoBehaviour
{
    //public static bool GamePause = false;
    public GameObject PanelTrap;
    public GameObject endLevelPanel;
    public AudioSource trapSound;
    public AudioSource EndLevelSound;

    

    void OnCollisionEnter(Collision collision)
    {
        
        string tagName = collision.gameObject.tag;

        switch (tagName)
        {
            case "trap":
                trapSound.Play();
                PanelTrap.SetActive(true);
                pauseGame.pause();
                break;
            case "end level": //Touch on end of level
                EndLevelSound.Play();
                globalVarible.Instance.points+=100;
                endLevelPanel.SetActive(true);
                //pauseGame.pause();
                
                break;
            case "star score": //touch on star
                //Debug.Log("star");
                globalVarible.Instance.points+=10; //add score
                Destroy(collision.gameObject); //desapire the star
                
                break;
        }
        
    }

    public void passToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //pass to next level
    }
}
