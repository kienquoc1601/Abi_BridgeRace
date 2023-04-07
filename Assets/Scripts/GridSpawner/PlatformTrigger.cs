using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{

    public GridSpawnPrefab grid;
    public static string TAG_PLAYER = "Player";
    public static string TAG_BOT= "Bot";
    // Start is called before the first frame update
    

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag(TAG_PLAYER) )
        {
            Player player = other.GetComponent<Player>();
            
            grid.AddColorToPool(player.currentColor);
            //Debug.Log(player.currentColor.ToString());

        }else if (other.CompareTag(TAG_BOT))
        {
            Character bot = other.GetComponent<Character>();
            bot.brickPool.Clear();
            //bot.currentGrid = grid.group;
            bot.ChangeState(new IdleState());
            grid.AddColorToPool(bot.currentColor);
            
            //Debug.Log(bot.currentColor.ToString());
        }
    }
}
