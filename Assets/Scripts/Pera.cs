using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pera: Fruit
{
    public override void PowerUp(PlatformerCharacter2D player)
    {
        player.AddShot(this);
    }

}
