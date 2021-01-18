using UnityEngine;

public class TicTACdoor : MonoBehaviour
{
    public GameObject tictactoe;
    void OnCollisionEnter(Collision col)
    {
        tictactoe.SetActive(true);
    }
}
