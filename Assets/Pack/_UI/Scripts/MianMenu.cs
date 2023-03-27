using Assets.Scripts.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MianMenu : UICanvas
{
    public void PlayButton()
    {
        GameManager.Instance.Load(GameManager.Scene.Lv1);



        //UIManager.Ins.OpenUI<GamePlay>();
        Close(0);
    }
}
