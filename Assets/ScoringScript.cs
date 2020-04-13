using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI scoringtextP1, scoringtextP2;
    public static int scoreP1=0, scoreP2=0;
    void Start()//void: tidak ada nilai kembalian
    {
        scoringtextP1.text = scoreP1.ToString();
        scoringtextP2.text = scoreP2.ToString();
    }

    public void UpdateScore(string namaWall){
        if (namaWall=="WallKiri"){
            scoreP2 += 1;
            scoringtextP2.text = scoreP2.ToString();
        }else if(namaWall=="WallKanan"){
            scoreP1 +=1;
            scoringtextP1.text = scoreP1.ToString();
        }
    }

}
