using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using KnifeHit.Controllers;
using KnifeHit.Model;
using KnifeHit.Strings;

namespace KnifeHit.View
{
    public class KnifeViewController : MonoBehaviour
    {
        // This will only be the view of a isngle knife and nothing else.
        // do not think of any panel of count or anything.
        // it will come all under the UI part.
        // So the only thing visible for a single knife is the collision that's it.
        // and its spawning sequence.

        [SerializeField] private KnifeController knifeController;
      
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == GameStrings.BOARD)
            {
                knifeController.ActionOnCollision(other);
            }
        }


    }
}
