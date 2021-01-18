
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    public GameObject hintPanel;
    public GameObject tictactoe;
    public int level=0;
    public Text[] spaceList;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;
    private string side;
    private int moves;
    public Button[] buttonList;
    // Start is called before the first frame update
    void Start()
    {

        SetGameControllerReferenceForButtons();
        side = "X";
        gameOverPanel.SetActive(false);
        moves = 0;
        restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetGameControllerReferenceForButtons()
    {
        for (int i = 0; i < spaceList.Length; i++)
            spaceList[i].GetComponentInParent<Space1>().SetControllerReference(this);
    }


    public string GetSide()
    {
        return side;
    }


    public void changeLevel(int levelVal)
    {
        level = levelVal;
    }
    void ChangeSide()
    {
        if (side == "X")
        {
            side = "O";
            
            int num= ComputerTurn();
            if (num != -1) react(num);
        }
            
        else
            side = "X";
    }

    public void EndTurn()
    {
        moves++;
        if (spaceList[0].text == side && spaceList[1].text == side && spaceList[2].text == side)
            GameOver();
        else if (spaceList[3].text == side && spaceList[4].text == side && spaceList[5].text == side)
            GameOver();
        else if (spaceList[6].text == side && spaceList[7].text == side && spaceList[8].text == side)
            GameOver();
        else if (spaceList[0].text == side && spaceList[3].text == side && spaceList[6].text == side)
            GameOver();
        else if (spaceList[1].text == side && spaceList[4].text == side && spaceList[7].text == side)
            GameOver();
        else if (spaceList[2].text == side && spaceList[5].text == side && spaceList[8].text == side)
            GameOver();
        else if (spaceList[0].text == side && spaceList[4].text == side && spaceList[8].text == side)
            GameOver();
        else if (spaceList[2].text == side && spaceList[4].text == side && spaceList[6].text == side)
            GameOver();
        if (moves >= 9)
        {
            gameOverPanel.SetActive(true);
            gameOverText.text = "teco!";
            restartButton.SetActive(true);
        }
        ChangeSide();
    }

    void GameOver()
    {
        if(side=="O")
        {
            gameOverPanel.SetActive(true);
            gameOverText.text = side + " wins!";
            restartButton.SetActive(true);
            for (int i = 0; i < spaceList.Length; i++)
                SetInteractable(false);
        }
        else
        {
            hintPanel.SetActive(true);
        }

    }

    void SetInteractable(bool setting)
    {
        for (int i = 0; i < spaceList.Length; i++)
            spaceList[i].GetComponentInParent<Button>().interactable = setting;
    }


    public void Restart()
    {
        side = "X";
        moves = 0;
        gameOverPanel.SetActive(false);
        SetInteractable(true);
        restartButton.SetActive(false);
        for (int i = 0; i < spaceList.Length; i++)
            spaceList[i].text = "";
    }

    
    public int rcnum(int r, int c)
    {
        if ((r == 0) && (c == 0))
        {
            return 0;
        }
        if ((r == 0) && (c == 1))
        {
            return 1;
        }
        if ((r == 0) && (c == 2))
        {
            return 2;
        }
        if ((r == 1) && (c == 0))
        {
            return 3;
        }
        if ((r == 1) && (c == 1))
        {
            return 4;
        }
        if ((r == 1) && (c == 2))
        {
            return 5;
        }
        if ((r == 2) && (c == 0))
        {
            return 6;
        }
        if ((r == 2) && (c == 1))
        {
            return 7;
        }
        if ((r == 2) && (c == 2))
        {
            return 8;
        }
        return 9;
    }
    public void react(int i)
    {
        spaceList[i].text = "O";
        buttonList[i].interactable = false;
        EndTurn();
    }
    public int ComputerTurn()
    {

        int[,] gameGird = new int[3,3];
        int i, sum=0, j=0,r=0, c=0, secondS=0,mainS=0,rawS=0,colS=0,p,globalsum=0;
        for (i = 0; i < 9; i++)//arrange things befor checks create tow demntion array
        {
            if (i == 3)
            {
                c = 0;
                r = 1;
            }
            if (i == 6)
            {
                c = 0;
                r = 2;
            }
            if (spaceList[i].text == "X")
            {
                gameGird[r, c] = 1;
                sum++;
            }
            if (spaceList[i].text == "O") gameGird[r, c] = 2;
            if (spaceList[i].text != "O" && spaceList[i].text != "X") gameGird[r, c] = 0;
            if (gameGird[r, c] != 0) globalsum++;
            c++;

        }
        if (level==2|| moves==3&&level==0||level==1&&moves==2)
        {
            ///check 1

            if ((sum < 2) && (spaceList[4].text != "X"))
            {
                return 4;
            }
            //check 2,3

            for (p = 2; p > 0; p--)
            {
                mainS = 0;
                secondS = 0;
                for (i = 0; i < 3; i++)
                {
                    rawS = 0;
                    colS = 0;

                    for (j = 0; j < 3; j++)
                    {

                        if (gameGird[i, j] == p)//raw
                        {
                            rawS++;
                            if (rawS == 2) for (r = 0; r < 3; r++) if (gameGird[i, r] == 0) return rcnum(i, r);
                        }

                        if (gameGird[j, i] == p)//col
                        {
                            colS++;
                            if (colS == 2) for (c = 0; c < 3; c++) if (gameGird[c, i] == 0) return rcnum(c, i);
                        }
                        if (i == j && gameGird[i, j] == p)//main salant
                        {
                            mainS++;
                            if (mainS == 2) for (r = 0; r < 3; r++) if (gameGird[r, r] == 0) return rcnum(r, r);
                        }
                        if (i == 2 - j && gameGird[i, j] == p)
                        {
                            secondS++;
                            if (secondS == 2) for (c = 0; c < 3; c++) if (gameGird[c, 2 - c] == 0) return rcnum(c, 2 - c);
                        }

                    }

                }
            }
            //check 4
            if (globalsum == 3 && gameGird[1, 1] == 2)
            {
                for (i = 0; i < 3; i++)
                {
                    rawS = 0;
                    colS = 0;
                    for (j = 0; j < 3; j++)
                    {
                        if (gameGird[i, j] == 1)//raw
                        {
                            rawS++;
                            if (rawS == 2) for (r = 0; r < 3; r += 2) if (gameGird[i, r] == 0) return rcnum(i, r);
                            if (rawS == 2) return rcnum(i, 1);
                        }

                        if (gameGird[j, i] == 1)//col
                        {
                            colS++;
                            if (colS == 2) for (c = 0; c < 3; c += 2) if (gameGird[c, i] == 0) return rcnum(c, i);
                            if (colS == 2) return rcnum(1, i);
                        }
                    }
                }
            }
            //check 5
            sum = 0;
            if (gameGird[0, 0] == 0) for (i = 1; i < 3; i++) if (gameGird[0, i] == 0 && gameGird[i, 0] == 0) sum++;
            if (sum == 2) return rcnum(0, 0);
            sum = 0;
            if (gameGird[0, 2] == 0) for (i = 0; i < 3; i++) if (gameGird[0, i] == 0 && gameGird[i, 2] == 0) sum++;
            if (sum == 3) return rcnum(0, 2);
            sum = 0;
            if (gameGird[2, 0] == 0) for (i = 0; i < 3; i++) if (gameGird[2, i] == 0 && gameGird[i, 0] == 0) sum++;
            if (sum == 3) return rcnum(2, 0);
            sum = 0;
            if (gameGird[2, 2] == 0) for (i = 0; i < 2; i++) if (gameGird[2, i] == 0 && gameGird[i, 2] == 0) sum++;
            if (sum == 2) return rcnum(2, 2);

            //check 6
            if (gameGird[1, 1] == 0) return rcnum(1, 1);

            //check 7
            mainS = 0;
            secondS = 0;
            for (i = 0; i < 3; i++)
            {
                rawS = 0;
                colS = 0;
                for (j = 0; j < 3; j++)
                {
                    if (gameGird[i, j] == 0)//raw
                    {
                        rawS++;
                        if (rawS == 3) return rcnum(i, j);
                    }

                    if (i == j && gameGird[i, j] == 0)//raw
                    {
                        mainS++;
                        if (mainS == 3) return rcnum(i, j);
                    }
                    if (i == 2 - j && gameGird[i, j] == 0)//raw
                    {
                        secondS++;
                        if (secondS == 3) return rcnum(i, j);
                    }
                }
            }

            //check 8

            for (i = 0; i < 3; i++)
                for (j = 0; j < 3; j++) if (gameGird[i, j] == 0) return rcnum(i, j);

        }
        if(level==0||level==1)
        {
            int randx = Random.Range(0, 2);
            int randy= Random.Range(0, 2);
            if (gameGird[randx, randy] != 0) for (i = randx; i < 3; i++) for (j = randy; j < 3; j++) if (gameGird[i, j] == 0) return rcnum(i,j);
            if(gameGird[randx,randy]!=0) for (i = 0; i < randx; i++) for (j =0 ; j < randy; j++) if (gameGird[i, j] == 0) return rcnum(i, j);

            return rcnum(randx, randy);
        }
        return -1;

    }
    
    public void EndOfGame()
    {
        //hintPanel.SetActive(false);
        globalVarible.Instance.points += 20;
        tictactoe.SetActive(false);
    }
}
