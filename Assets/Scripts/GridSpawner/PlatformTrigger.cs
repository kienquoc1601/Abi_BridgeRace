using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{

    public GridSpawnPrefab grid;
    public static string TAG_PLAYER = "Player";
    public static string TAG_BOT= "Bot";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag(TAG_PLAYER) )
        {
            Player player = other.GetComponent<Player>();
            grid.AddColorToPool(player.currentColor);
            Debug.Log(player.currentColor.ToString());

        }else if (other.CompareTag(TAG_BOT))
        {
            Bot bot = other.GetComponent<Bot>();
            grid.AddColorToPool(bot.currentColor);
            Debug.Log(bot.currentColor.ToString());
        }
    }
}
