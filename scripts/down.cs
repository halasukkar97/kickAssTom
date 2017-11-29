using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class down : MonoBehaviour
{

    public tom player;
    public gamescore _gamescore;

    public void Press()
    {
        if (player.AIdown_is_in == true)
        {
            WrongPress();
            Destroy(player.enemyDown);
            _gamescore.currentScore += (10 + _gamescore.GetBonusPoints());
            player.AIdown_is_in = false;

            _gamescore._currentscore();
            _gamescore.AddToBonusPoints(1);

        }
    }

    public void WrongPress()
    {
        if (player.AIup_is_in == true || player.AImiddle_is_in == true)
        {
            _gamescore.ResetBonusPoints();
        }


    }

    public void PauseDisable()
    {

        this.GetComponent<Button>().interactable = false;
    }

    public void Resume()
    {
        this.GetComponent<Button>().interactable = true;
    }


}
