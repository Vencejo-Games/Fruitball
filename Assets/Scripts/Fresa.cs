using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fresa : Fruit
{
    public override void PowerUp(PlatformerCharacter2D player)
    {
        player.AddLife();
    }
}
