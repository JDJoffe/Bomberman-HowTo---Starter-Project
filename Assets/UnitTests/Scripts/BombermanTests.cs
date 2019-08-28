using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.TestTools;
using NUnit.Framework;
public class BombermanTests 
{
    //: IPreBuildSetUp
    //public void SetUp()
    // {
    //     throw new System.NotImplementedException();
    // }
    private GameObject game;
    private Player[] players;

    //get player by index
    Player GetPlayer(int index)
    {
      //loop through all players
        foreach (var player in players)
        {
            //compare players with index
            if (player.playerNumber == index)
            {
                //return that player
                return player;
            }
           
        }

        return null;
    }
    [SetUp]
   public void SetUp()
    {
        GameObject gamePrefab = Resources.Load<GameObject>("Prefabs/Game");
        game = Object.Instantiate(gamePrefab);
        players = Object.FindObjectsOfType<Player>();
       
    }
    [UnityTest]
   public IEnumerator Player1DropsBomb()
    {
        //get player
        Player player1 = GetPlayer(1);

        //simulate drop bomb
        player1.DropBomb();

        //wait for end of frame
        yield return new WaitForEndOfFrame();

        //check if bomb exists in game
        Bomb bomb = Object.FindObjectOfType<Bomb>();

        //bomb is not null
        Assert.IsTrue(bomb != null, "player1 bomb didn't spawn");

      
       
    }
    [UnityTest]
    public IEnumerator Player2DropsBomb()
    {
        //get player
        Player player2 = GetPlayer(2);

        //simulate drop bomb
        player2.DropBomb();

        //wait for end of frame
        yield return new WaitForEndOfFrame();

        //check if bomb exists in game
        Bomb bomb = Object.FindObjectOfType<Bomb>();

        //bomb is not null
        Assert.IsTrue(bomb != null, "player2 bomb didn't spawn");

        
       
    }
    [UnityTest]
    public IEnumerator PlayerCanMove()
    {
        yield return new WaitForEndOfFrame();
    }
    [UnityTest]
    public IEnumerator PlayersDieInlineWithBomb()
    {

        Player player = GetPlayer(1);

        yield return new WaitForEndOfFrame();


    }
    [TearDown]
   public void TearDown()
    {
        //  GetPlayer(2);
        Object.Destroy(game);
    }
}
