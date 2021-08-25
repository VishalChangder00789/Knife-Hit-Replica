// Font End of the board and visualisation and animation of the board.
//  Controls what all we see.
//      Such as rotation of the objects and animations if are added.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KnifeHit.Strings;
using KnifeHit.Controllers;
using KnifeHit.Model;
using UnityEngine.UI;

namespace KnifeHit.View
{
    public class BoardViewManager : MonoBehaviour
    {
        #region --------------- SCRIPT REFERENCE -----------------

        [SerializeField]private BoardController boardController;


        #endregion --------------- SCRIPT REFERENCE ENDS-----------------

        #region --------------- LOCAL VARIABLE DECLARATION FOR THE CLASS BOARDVIEWMANAGER -----------------

        [SerializeField]private GameObject boardSprite;
        private Transform boardTransform;
        [SerializeField]private Text healthText;
        [SerializeField]private GameObject brokenBoardPiece;

        private Transform boardSpriteLocation;
        [SerializeField][Range(-1,1)]public int sliderValue;
        [SerializeField] public int rotationSpeed;



        #endregion --------------- LOCAL VARIABLE DECLARATION FOR THE CLASS BOARDVIEWMANAGER -----------------

        #region ------------------------------ SYSTEM ACCESSIBLE CLASSES --------------------
        //[System.Serializable]
        //public class RotationPattern
        //{
        //    public float Speed;
        //    public float Duration;
        //}
        #endregion ------------------------------ SYSTEM ACCESSIBLE CLASSES --------------------

        #region ------------------------ CUSTOM CLASS DECLARATIONS ----------------------------

        //// An array of the class RotationPattern in order to control the Rotation Pattern
        //[SerializeField]
        //RotationPattern[] rotationPatternDetail;


        #endregion ------------------------ CUSTOM CLASS DECLARATIONS ----------------------------

        #region ------------------------ BOARD MOVEMENT PATTERN HANDLER ----------------------------

        /// <summary>
        /// This needs to be modified.
        /// </summary>
        /// <returns></returns>
        //private IEnumerator RotateBoardWithPattern()
        //{
        //    int patternIndex = 0;
        //    int currentIndex;
        //    int nextPatternIndex = patternIndex + 1;
        //    while (true)
        //    {
        //        /// Buggy Code and not workign properly logic wise correct.
        //        boardTransform.Rotate(0f, 0f, 0f);
        //        currentIndex = patternIndex;
        //        boardTransform.Rotate(0f, 0f, rotationPatternDetail[patternIndex].Speed * Time.deltaTime / 0.1f);
        //        yield return new WaitForSecondsRealtime(rotationPatternDetail[patternIndex].Duration);
        //        patternIndex++;
        //        if (patternIndex >= rotationPatternDetail.Length)
        //            patternIndex = 0;
        //    }
        //}


        #endregion ------------------------ BOARD MOVEMENT PATTERN HANDLER ENDS ----------------------------


        #region -------------------- BOARD OBJECT INTERACTION OBJECTS ----------------------------------
        // enable and disbale board.
        public void DisableBoardGameobject()
        {
            boardSprite.SetActive(false);
        }
        public void PlayBoardDestructionSequence()
        {
            Instantiate(brokenBoardPiece, boardSpriteLocation.position, Quaternion.identity);
        }
        #endregion -------------------- BOARD OBJECT INTERACTION OBJECTS ENDS ----------------------------------





        /// <summary>
        /// All the necessary components are accessed at the very beginning of the game.
        ///  Accessing the gameobjects transform and shortening the code length by assigning the transform to boardTransform variable.
        /// </summary>
        private void Start()
        {
           // little bit unecccesary code is it?

            boardTransform = boardSprite.transform;
            boardSpriteLocation = boardTransform;
        }

        /// <summary>
        /// Handling all the physics related part.
        /// </summary>
         void Update()
        {
            //StartCoroutine("RotateBoardWithPattern");
            boardTransform.Rotate(Vector3.forward * rotationSpeed * sliderValue*Time.deltaTime);
            healthText.text = boardController.GetHealth().ToString();
        }

    }

}

