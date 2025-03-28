using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : BaseCounter
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;    
    

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // There is no kitchen object, therefore player can pass the object
            if (player.HasKitchenObject())
            {
                //Player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //Player not carrying anything
            }
        }
        else
        {
            // there is kitchen object, player cant pass the object
            if (player.HasKitchenObject())
            {
                //player is carrying something
            }
            else
            {
                // player not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
    
}
