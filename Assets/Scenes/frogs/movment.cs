using UnityEngine;

public class movment : MonoBehaviour
{
    public FrogsContrroler frogscontroler;
    void OnMouseDown()
    {

        int tag = System.Int32.Parse(gameObject.tag);
        frogscontroler = FindObjectOfType<FrogsContrroler>();
        //frogscontroler.entertTag = tag;
        frogscontroler.gameAction(tag);
    }

}
