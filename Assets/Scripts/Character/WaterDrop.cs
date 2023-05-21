using UnityEngine;

public class WaterDrop : CharacterBase
{
    protected override void FailGame()
    {
        base.FailGame();
        Rigidbody.isKinematic = false;
    }
}
