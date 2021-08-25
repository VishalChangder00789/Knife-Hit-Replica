using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using KnifeHit.Controllers;
using KnifeHit.Strings;
using KnifeHit.Value;

/// <summary>
/// TODO :: UIView Controller will 
///     Set the panel knife
///     Restart Button On and OFF 
///     Changes colour of used Knife
///     Decrement Display Knife --- Done Via Controller
///   
/// </summary>
/// 

namespace KnifeHit.View
{
    public class UIViewController : MonoBehaviour
    {
        
        [SerializeField] private GameObject panelOfKnives;
        [SerializeField] private GameObject knifeIcons;
        [SerializeField] private Text scoreText;
        [SerializeField] private Button restartButton;
        [SerializeField] private Color usedKnifeColour;


        [SerializeField] private UIController uiController;

        [SerializeField] private GameObject gameOverUI;


        #region ---------------------------------- LOCAL METHODS ---------------------------
        public void SetPanelKnives(int p_knifeCounts)
        {
            for (int i = 0; i < p_knifeCounts; i++)
            {
                Instantiate(knifeIcons, panelOfKnives.transform);
            }
        }

        int countIndex = 0;
        public void ReducePanelKnives()
        {
            panelOfKnives.transform.GetChild(countIndex).GetComponent<Image>().color = usedKnifeColour;
            countIndex++;
        }
        #endregion ---------------------------------- LOCAL METHODS ---------------------------



        private void Awake()
        {
           
        }

        // I need to change this code and modify it so that it does not check each time the score. Instead there can be an if statement that
        // can possibly counter that.
        private void Update()
        {
            scoreText.text = uiController.GetScore().ToString();
        }
    }

}
