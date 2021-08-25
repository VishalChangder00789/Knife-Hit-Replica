using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using KnifeHit.Value;

namespace KnifeHit.Model {
    public class Board
    {
        #region ------------------------ MODEL LOCAL VARIABLE -----------------------
        public int _health { get; set; } = GameValues.FULLHEALTH_WITH_KNIFE;
        public int _numberOfHits { get; set; } = GameValues.RESETVALUE;

        #endregion ------------------------ MODEL LOCAL VARIABLE  ENDS -----------------------

    }
}


