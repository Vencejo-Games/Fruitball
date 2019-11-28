using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : Fruit
{
    public override void PowerUp(PlatformerCharacter2D player)
    {
        player.DoHurt();
    }
}
