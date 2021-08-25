/// Knife Backend.
///  Some of it will also be getting controlled by the UI 
///  eg : Count of knives which user wants to put
///  type of knife.as for now.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using KnifeHit.Model;
using KnifeHit.Controllers;
using KnifeHit.Strings;
using KnifeHit.View;
using KnifeHit.Value;

namespace KnifeHit.Controllers
{
    public class KnifeController : MonoBehaviour
    { 
        #region --------------------- SCRIPT REFERENCE ---------------------


        // Model Class Reference 
        Knives kniveModel;
        [SerializeField]UIController uiController;
        [SerializeField] BoardController boardController;
        [SerializeField] KnifeViewController knifeViewController;



        #endregion -------------- SCRIPT REFERENCE END ---------------------

        #region --------------------- METHOD TO INTERACT WITH KNIVE MODEL  ---------------------

        public void SetKnifeType(string KNIFETYPE)
        {
            kniveModel.knifeType = KNIFETYPE;
        }
        public string GetKnifeType()
        {
            return kniveModel.knifeType;
        }

        #endregion --------------------- LOCAL METHODS USING REFERENCE VARIABLES ENDS ---------------------

        #region -------------------- LOCAL VARIABLE -----------------------------

        #region ----------PRIVATE VARIABLES ------------------------------
        [SerializeField]
        private Vector2 attackForce;

        [SerializeField] public GameObject spawaningKnifePrefab;

        private Rigidbody2D knifeRigidBody;
        private BoxCollider2D knifeCollider;

        #endregion ----------PRIVATE VARIABLES ENDS ------------------------------

        #endregion -------------------- LOCAL VARIABLE ENDS -----------------------------

        /// <summary>
        ///  Since this script will be attached to a prefab i dont have to find it again and again and attach it manually
        /// </summary>
        private void Awake()
        {
            knifeRigidBody = spawaningKnifePrefab.GetComponent<Rigidbody2D>();
            knifeCollider = spawaningKnifePrefab.GetComponent<BoxCollider2D>();
            /// It should be initialised using this method as it is not extending monobehaviour class.
            kniveModel = new Knives();
            uiController = FindObjectOfType<UIController>();
            boardController = FindObjectOfType<BoardController>();
            // referencing other scripts. 
        }

        void FixedUpdate()
        {
            StartMechanics();
        }

        
        #region -------------------- MECHANICS OF KNIFE ATTACK -----------------------------

        private void StartMechanics()
        {
            if (Input.GetMouseButton(0) && kniveModel.isActive)
            {
                // Add force to the knife
                // It should be an instant force and impulsive force using its mass component
                // also tweeking the gravity scale.
                knifeRigidBody.AddForce(attackForce, ForceMode2D.Impulse);
                knifeRigidBody.gravityScale = 1;
                //UIController.Instance.Interactor_UIV.DecrementKnifeDisplay();
            }

            if(Input.touchCount > 0 && kniveModel.isActive)
            {
                // Add force to the knife
                // It should be an instant force and impulsive force using its mass component
                // also tweeking the gravity scale.
                knifeRigidBody.AddForce(attackForce, ForceMode2D.Impulse);
                knifeRigidBody.gravityScale = 1;
                //UIController.Instance.Interactor_UIV.DecrementKnifeDisplay();
            }
        }
        #endregion -------------------- MECHANICS OF KNIFE ATTACK ENDS -----------------------------

        #region ------------------------ COLLIDER SYSTEM OF A SINGAL KNIFE -------------------------------------------
        public void ActionOnCollision(Collider2D collision2)
        {
            if (!kniveModel.isActive)
                return;

            kniveModel.isActive = false;

            
            if (collision2.gameObject.tag == GameStrings.BOARD)
            {
                knifeRigidBody.velocity = new Vector2(0, 0);               
                knifeRigidBody.bodyType = RigidbodyType2D.Kinematic;          
                this.transform.SetParent(collision2.gameObject.transform);
                knifeCollider.offset = new Vector2(knifeCollider.offset.x, -0.4f);
                knifeCollider.size = new Vector2(knifeCollider.size.x, 1);

                
                // Spawning of the knives are done here.
                uiController.SpawnKnife();
                uiController.KnifeVisibility();
                // Score Updation is also done.
                uiController.UpdateScore(GameValues.SCORE_WITH_EACH_KNIVE);
                
                // Damage the board too.
                boardController.ReduceHealth(GameValues.DAMAGE_WITH_KNIFE);

                // redeuce the panel knives count also.


            }
            else if (collision2.gameObject.tag == GameStrings.KNIFE)
            {
                knifeRigidBody.velocity = new Vector2(knifeRigidBody.velocity.x, -2);
                knifeRigidBody.gravityScale = -14;
                
                // Game Over Sequence with a restart Button.
            }
        }

        #endregion ------------------------ COLLIDER SYSTEM OF A SINGAL KNIFE -------------------------------------------



    }
}

