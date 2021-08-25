/// Back end of the Board
///  Calculations and assigning the values.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using KnifeHit.Model;
using KnifeHit.Strings;
using KnifeHit.Value;
using KnifeHit.View;



/// <summary>
/// Class Contains :
/// 
///         At the very beginning resets the values to RESET VALUE in KnifeHit.Value namespace.
///         Controlling Health using getter and setter
///         Detects Collision with knife and sets the health and damage.
///         
/// </summary>



namespace KnifeHit.Controllers {
    public class BoardController : MonoBehaviour
    { 

        #region --------------- SCRIPT INSTANCE FROM DIFFERENT CLASSES -----------------
        /// <summary>
        /// Object to access the attributes and local methods of the class Board.
        /// </summary>
        Board boardModel;
        [SerializeField] private BoardViewManager boardView;
        [SerializeField] private UIController uiController;


        #endregion --------------- SCRIPT REFERENCE FROM DIFFERENT CLASSES ENDS -----------------
        
        #region ------------ METHODS TO INTERACT WITH BOARD MODEL -------------

             #region ----------------------------- HEALTH SYSTEM ------------------------
        public void ResetHealth()
        {
            boardModel._health = GameValues.FULLHEALTH_WITH_KNIFE;
        }
        public void ReduceHealth(int _dmg)
        {
            boardModel._health -= _dmg; 
        }
        public int GetHealth()
        {
            return boardModel._health;
        }
             #endregion --------------------------- HEALTH SYSTEM ENDS ----------------------------

             #region ---------------------------------- HIT SYSTEM ------------------------
        public int GetHitInfo()
        {
            return boardModel._numberOfHits;
        }
        public void SetHitInfo(int hits)
        {
            boardModel._numberOfHits += hits;
        }
        #endregion ---------------------------------- HIT SYSTEM ENDS ------------------------

        #endregion -------  METHODS TO INTERACT WITH BOARD MODEL ENDS-------------


        /// <summary>
        /// When will this script start :
        /// 
        ///     The Script will start when the game will start
        ///      so the initial value of health must he set
        ///         and the number of hits must also be set
        /// </summary>
        /// 


        void Start()
        {
            boardModel = new Board();
            
        }
        void Update()
        {
            if (boardModel._health <= 0)
            {
                Debug.Log("Board is Destroyed");
                // Getting a problem here.
                boardView.DisableBoardGameobject();
                boardView.PlayBoardDestructionSequence();

                // Game Complete Sequence 
            }

            //if (uiController.GetPanelKnifeCount() <= 0)
            //{
            //    Debug.Log("Board is Destroyed");
            //    // Getting a problem here.
            //    boardView.DisableBoardGameobject();
            //    boardView.PlayBoardDestructionSequence();
            //}


        }  
    }
}
