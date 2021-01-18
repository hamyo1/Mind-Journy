using System;
using TMPro;
using UnityEngine;


public class langHendler : MonoBehaviour
{
    public TMP_InputField question;
    public TMP_InputField ans1;
    public TMP_InputField ans2;
    public TMP_InputField ans3;
    public TMP_InputField ans4;
    public int langStatus = 0;
    public void OnChangeInputBox( int index)
    {
        if (langStatus == 0)
        {
            if (index == 0) question.text = Reverse(question.text);
            if (index == 1) ans1.text = Reverse(ans1.text);
            if (index == 2) ans2.text = Reverse(ans2.text);
            if (index == 3) ans3.text = Reverse(ans3.text);
            if (index == 4) ans4.text = Reverse(ans4.text);

        }
    }
    public string Reverse(string text)
    {
        char[] cArray = text.ToCharArray();
        string reverse = String.Empty;
        for (int i = cArray.Length - 1; i > -1; i--)
        {
            reverse += cArray[i];
        }
        return reverse;
    }
    public void langDropDown(int val)
    {
        if (val == 1)
        {
            langStatus = 1;

        }

    }
    public string convertHeb(string HebStr)
    {
        //char[] cArray = HebStr.ToCharArray();
        string englishStr = String.Empty;
        for (int i = 0; i < HebStr.Length; i++)
        {
            if (HebStr[i] == 'א')
            {
                englishStr += 'a';
            }
            else if (HebStr[i] == 'ב')
            {
                englishStr += 'b';
            }
            else if (HebStr[i] == 'ג')
            {
                englishStr += 'c';
            }
            else if (HebStr[i] == 'ד')
            {
                englishStr += 'd';
            }
            else if (HebStr[i] == 'ה')
            {
                englishStr += 'e';
            }
            else if (HebStr[i] == 'ו')
            {
                englishStr += 'f';
            }
            else if (HebStr[i] == 'ז')
            {
                englishStr += 'g';
            }
            else if (HebStr[i] == 'ח')
            {
                englishStr += 'h';
            }
            else if (HebStr[i] == 'ט')
            {
                englishStr += 'i';
            }
            else if (HebStr[i] == 'י')
            {
                englishStr += 'j';
            }
            else if (HebStr[i] == 'כ')
            {
                englishStr += 'k';
            }
            else if (HebStr[i] == 'ך')
            {
                englishStr += 'K';
            }
            else if (HebStr[i] == 'ל')
            {
                englishStr += 'l';
            }
            else if (HebStr[i] == 'מ')
            {
                englishStr += 'm';
            }
            else if (HebStr[i] == 'ם')
            {
                englishStr += 'M';
            }
            else if (HebStr[i] == 'נ')
            {
                englishStr += 'n';
            }
            else if (HebStr[i] == 'ן')
            {
                englishStr += 'N';
            }
            else if (HebStr[i] == 'ס')
            {
                englishStr += 'o';
            }
            else if (HebStr[i] == 'ע')
            {
                englishStr += 'p';
            }
            else if (HebStr[i] == 'פ')
            {
                englishStr += 'q';
            }
            else if (HebStr[i] == 'ף')
            {
                englishStr += 'Q';
            }
            else if (HebStr[i] == 'צ')
            {
                englishStr += 'r';
            }
            else if (HebStr[i] == 'ץ')
            {
                englishStr += 'R';
            }
            else if (HebStr[i] == 'ק')
            {
                englishStr += 's';
            }
            else if (HebStr[i] == 'ר')
            {
                englishStr += 't';
            }
            else if (HebStr[i] == 'ש')
            {
                englishStr += 'u';
            }
            else if (HebStr[i] == 'ת')
            {
                englishStr += 'v';
            }
            else
            {
                englishStr += HebStr[i];
            }
        }
        return englishStr;
    }
    public string convertEnglish(string engStr)
    {

        //char[] cArray = HebStr.ToCharArray();
        string HebStr = String.Empty;
        for (int i = 0; i < engStr.Length; i++)
        {
            if (engStr[i] == 'a')
            {
                HebStr += 'א';
            }
            else if (engStr[i] == 'b')
            {
                HebStr += 'ב';
            }
            else if (engStr[i] == 'c')
            {
                HebStr += 'ג';
            }
            else if (engStr[i] == 'd')
            {
                HebStr += 'ד';
            }
            else if (engStr[i] == 'e')
            {
                HebStr += 'ה';
            }
            else if (engStr[i] == 'f')
            {
                HebStr += 'ו';
            }
            else if (engStr[i] == 'g')
            {
                HebStr += 'ז';
            }
            else if (engStr[i] == 'h')
            {
                HebStr += 'ח';
            }
            else if (engStr[i] == 'i')
            {
                HebStr += 'ט';
            }
            else if (engStr[i] == 'j')
            {
                HebStr += 'י';
            }
            else if (engStr[i] == 'k')
            {
                HebStr += 'כ';
            }
            else if (engStr[i] == 'K')
            {
                HebStr += 'ך';
            }
            else if (engStr[i] == 'l')
            {
                HebStr += 'ל';
            }
            else if (engStr[i] == 'm')
            {
                HebStr += 'מ';
            }
            else if (engStr[i] == 'M')
            {
                HebStr += 'ם';
            }
            else if (engStr[i] == 'n')
            {
                HebStr += 'נ';
            }
            else if (engStr[i] == 'N')
            {
                HebStr += 'ן';
            }
            else if (engStr[i] == 'o')
            {
                HebStr += 'ס';
            }
            else if (engStr[i] == 'p')
            {
                HebStr += 'ע';
            }
            else if (engStr[i] == 'q')
            {
                HebStr += 'פ';
            }
            else if (engStr[i] == 'Q')
            {
                HebStr += 'ף';
            }
            else if (engStr[i] == 'r')
            {
                HebStr += 'צ';
            }
            else if (engStr[i] == 'R')
            {
                HebStr += 'ץ';
            }
            else if (engStr[i] == 's')
            {
                HebStr += 'ק';
            }
            else if (engStr[i] == 't')
            {
                HebStr += 'ר';
            }
            else if (engStr[i] == 'u')
            {
                HebStr += 'ש';
            }
            else if (engStr[i] == 'v')
            {
                HebStr += 'ת';
            }
            else
            {
                HebStr += engStr[i];
            }
        }
        return HebStr;
    }

    public void beforSendAction()
    {
        question.text= convertHeb(question.text);
        ans1.text=convertHeb(ans1.text);
        ans2.text = convertHeb(ans2.text);
        ans3.text = convertHeb(ans3.text);
        ans4.text = convertHeb(ans4.text);
    }
}
