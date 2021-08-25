using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

using KnifeHit.Model;
using KnifeHit.View;


namespace KnifeHit.Controllers
{
    public class UIController : MonoBehaviour
    {
        #region ------------------------------------------------- SCRIPT REFERENCE ------------------------------------------

        UI uiModel;
        [SerializeField] private UIViewController uiView;
        [SerializeField] private KnifeController knifeController;

        #endregion ------------------------------------------------- SCRIPT REFERENCE ------------------------------------------


        private void Awake()
        {
            // My new UI object
            uiModel = new UI();
            SetPanelKnifeCount(knifeCount);
            uiView.SetPanelKnives(knifeCount);
            SpawnKnife();
        }


        #region ---------- SERIALIZED PRIVATE VARIABLES ------------------------------

        //[SerializeField] private GameObject spawningKnifePrefab;
        [SerializeField] private GameObject spawnKnifePosition;
        [SerializeField] private int knifeCount = 0;

        #endregion ----------SERIALIZED PRIVATE VARIABLES ENDS -----------------------------------------------


        #region ----------------------- METHODS TO INTERACT WITH UI MODEL---------------------
        public int GetPanelKnifeCount()
        {
            return uiModel._panelKnivesCount;
        }

        public void SetPanelKnifeCount(int givenKnifeCount)
        {
            uiModel._panelKnivesCount = givenKnifeCount;
        }

        public int GetScore()
        {
            return uiModel._score;
        }
        public void SetScore(int initialScore)
        {
            uiModel._score = initialScore;
        }

       public void UpdateScore(int addScore)
        {
            uiModel._score += addScore;
        }
        #endregion ----------------------- METHODS TO INTERACT WITH UI MODEL---------------------

        
        #region --------------------------------------- LOCAL METHODS ---------------------------------------


         #region ---------------------------------- KNIFE SPAWNING SYSTEM --------------------------
        // definition of spawn will be contained by this only.
        public void SpawnKnife()
        {
            if (knifeCount <= 0)
                return;
            knifeCount--;
            Instantiate(knifeController.spawaningKnifePrefab, spawnKnifePosition.transform.position, Quaternion.identity);
        }
        #endregion ---------------------------------- KNIFE SPAWNING SYSTEM ENDS --------------------------

        #region --------------------------- PANEL KNIVES CONTROL ---------------------------

        public void KnifeVisibility()
        {
            uiView.ReducePanelKnives();
        }
        
        #endregion --------------------------- PANEL KNIVES CONTROL ENDS ---------------------------



        #endregion --------------------------------------- LOCAL METHODS ENDS ---------------------------------------







    }

}
