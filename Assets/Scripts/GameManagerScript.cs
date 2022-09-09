using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    #region gloabl variables

    public List<GameObject> gameObjects;
    public GameObject CookingBook;
    private int _currentStep = -1;
    private GameObject _goalObject;
    private List<GameObject> _workingObjects;
    private IRecipe _recipe = null;
    private Vector3 _postionOfAnchor;
    private bool _animationIsOn = false;
    private int _workinObjectAnimationIndex = 0;
    private GameObject _currentAnimationObject;
    private bool _goalObjectAnimation = false;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag(GameObjects.COOKING_BOOK).transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_animationIsOn)
        {
            // Handle back button if it should be visible or not
            // Not visible when Recipe did not start or first step so you cannot go back
            if (_currentStep > 0)
                GameObject.FindGameObjectWithTag("back_button").transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            else if (_recipe != null)
                GameObject.FindGameObjectWithTag("back_button").transform.localScale = new Vector3(0, 0, 0);


            if (_recipe != null)
            {

                // Check if there are working objects so that step is not done yet
                if (_workingObjects.Count > 0)
                {
                    // Checking distance of working objects to goal object
                    var goalObjectPosition = GameObject.FindGameObjectWithTag(_goalObject.name).transform.position;
                    List<GameObject> objectsToRemove = new List<GameObject>();
                    foreach (var workingObject in _workingObjects)
                    {
                        var obj = GameObject.FindGameObjectWithTag(workingObject.name).gameObject.transform.GetChild(0).gameObject;
                        if (obj != null)
                        {
                            var workingObjectPosition = obj.transform.position;
                            var distanceSqr = (goalObjectPosition - workingObjectPosition).sqrMagnitude;
                            if (distanceSqr <= 0.05)
                            {
                                objectsToRemove.Add(workingObject);
                            }
                        }
                    }
                    foreach (var obj in objectsToRemove)
                    {
                        _workingObjects.Remove(obj);
                        ObjectHandler.RemoveObject(GameObject.FindGameObjectWithTag(obj.name));
                    }
                }
                // Step is done and prevents incrementing steps when whole recipe is finished
                // (so that back button still works from last step, otherwise it gets incremented each frame)
                else if (_currentStep < _recipe.CookingSteps.Count)
                {
                    _currentStep++;
                    NextStep();
                }

            }
        }
        else
        {
            var anim = GameObject.FindGameObjectWithTag(_currentAnimationObject.name).GetComponentInChildren<Animator>();
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
                AnimationEnd();
            
        }

        
    }



    #region Recipe functions

    /// <summary>
    /// Starts recipe and first step appears
    /// </summary>
    public void StartRecipe()
    {

        _currentStep = 0;
        _recipe = RecipeList.Recipes[RecipeList.selectedRecipeNo];

        //get position of anchor board and remove the board
        var board = GameObject.Find(GameObjects.BOARD);
        _postionOfAnchor = board.transform.position;
        ObjectHandler.RemoveObject(board);

        // set cooking book
        GameObject.FindGameObjectWithTag(GameObjects.COOKING_BOOK).transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        GameObject.FindGameObjectWithTag(GameObjects.COOKING_BOOK).transform.position = new Vector3(_postionOfAnchor.x, _postionOfAnchor.y + 0.15f, _postionOfAnchor.z + 0.4f);

        StepHandler();

        //DropAnimationStart(GetGameObject(GameObjects.PAN), GetGameObject(GameObjects.OLIVE_OIL));

    }


    /// <summary>
    /// Loads new step (defined by _currentStep variable)
    /// </summary>
    private void NextStep()
    {
        if (GameObject.FindGameObjectWithTag(_goalObject.name))
            ObjectHandler.RemoveObject(GameObject.FindGameObjectWithTag(_goalObject.name));
        if (_currentStep < _recipe.CookingSteps.Count)
            StepHandler();
    }



    /// <summary>
    /// Places goal object and working objects of specific step
    /// </summary>
    private void PlaceObjectsOfCurrentStep()
    {
        //place goal object
        //PlaceManager(new List<GameObject> { _goalObject }, new List<Vector3> { _postionOfAnchor });

        //place working objects
        List<Vector3> positionOfWorkingObjects = new List<Vector3>();
        positionOfWorkingObjects.Add(new Vector3(_postionOfAnchor.x + 0.4f, _postionOfAnchor.y, _postionOfAnchor.z));
        for (int objectIndex = 0; objectIndex < _workingObjects.Count; objectIndex++)
        {
            if (objectIndex > 0)
            {
                var oldPosition = positionOfWorkingObjects[objectIndex - 1];
                var position = new Vector3(oldPosition.x + 0.4f, oldPosition.y, oldPosition.z);
                positionOfWorkingObjects.Add(position);
            }
        }

        PlaceManager(_workingObjects, positionOfWorkingObjects);
    }


    private void StepHandler()
    {
        // Set and place goal object
        var cookingStep = _recipe.CookingSteps[_currentStep];
        _goalObject = GetGameObject(cookingStep.GoalObject);
        PlaceManager(new List<GameObject> { _goalObject }, new List<Vector3> { _postionOfAnchor });

        // Set working objects
        _workingObjects = null;
        _workingObjects = new List<GameObject>();
        foreach (var obj in cookingStep.WorkingObjects)
            _workingObjects.Add(GetGameObject(obj));

        // Make animation
        AnimationHandler();


        // Place objects Platziert for drag and drop
        //PlaceObjectsOfCurrentStep();

    }

    #endregion


    #region Object Handling

    public void PlaceManager(List<GameObject> gameObjects, List<Vector3> position)
    { 
        for(int i = 0; i < gameObjects.Count; i++)
        {
            ObjectHandler.AddObject(gameObjects[i], position[i]);
        }
    }

    public void RemoveManager(List<GameObject> gameObjects)
    {
        for(int i = 0; i < gameObjects.Count; i++)
        {
            ObjectHandler.RemoveObject(gameObjects[i]);
        }
    }

    /// <summary>
    /// Returns GameObject from list gameObjects by its name
    /// </summary>
    /// <param name="name"></param>
    /// <returns>GameObject</returns>
    private GameObject GetGameObject(string name)
    {
        foreach (var obj in gameObjects)
        {
            if (obj)
            {
                if (obj.name == name)
                {
                    return obj.gameObject;
                }
            }
            
        }
        return null;
    }

    #endregion


    #region Button functions

    /// <summary>
    /// Function for Button, to go to next step or start recipe at the beginning
    /// </summary>
    public void NextStepViaButton()
    {
        if(_recipe != null)
        {
            // Recipe not finished yet
            if(_currentStep < _recipe.CookingSteps.Count)
            {
                
                foreach (var obj in _workingObjects)
                {
                    //_workingObjects.Remove(obj);
                    ObjectHandler.RemoveObject(GameObject.FindGameObjectWithTag(obj.name));
                }

                _workingObjects.Clear();
                _currentStep++;
                NextStep();
            }
            // Recipe finished
            else
            {
                // Do stuff when Finished
                BackToMenu();
            }

        }
        else
        {
            StartRecipe();
        }
        

    }

    /// <summary>
    /// Function for Button, to go one step back
    /// </summary>
    public void BackStepViaButton()
    {
        if(_currentStep > 0)
        {
           
            foreach(var obj in _workingObjects)
                ObjectHandler.RemoveObject(GameObject.FindGameObjectWithTag(obj.name));

            _workingObjects.Clear();
            _currentStep--;
            NextStep();
        }
        

    }


    /// <summary>
    /// Function for Button, to go one step back
    /// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadScene("Recipe_Selector", LoadSceneMode.Single);
    }

    #endregion


    #region Animation functions

    private void AnimationHandler()
    {
        var currentStep = _recipe.CookingSteps[_currentStep];

        // As long as Index in range, working objects gets picked and its animation played
        if(_workinObjectAnimationIndex < currentStep.WorkingObjects.Count)
        {
            var workingObjectName = currentStep.WorkingObjects[_workinObjectAnimationIndex];
            var animaterObject = GetGameObject(workingObjectName + "_animator");

            if (!_animationIsOn)
            {
                _animationIsOn = true;

                if(workingObjectName == GameObjects.WATER_BOTTLE && _goalObject.name == GameObjects.DEEPPAN)
                {
                    _goalObjectAnimation = true;
                    ObjectHandler.RemoveObject(GameObject.FindGameObjectWithTag(_goalObject.name));
                    // Place DEEPPAN Animator object
                    var goalObjectAnimator = GetGameObject(GameObjects.DEEPPAN + "_animator");
                    ObjectHandler.AddObject(goalObjectAnimator, new Vector3(_postionOfAnchor.x, _postionOfAnchor.y, _postionOfAnchor.z));
                    // Place Water bottle
                    ObjectHandler.AddObject(animaterObject, new Vector3(_postionOfAnchor.x + 0.2f, _postionOfAnchor.y + 0.4f, _postionOfAnchor.z));

                    _currentAnimationObject = animaterObject;
                    GameObject.FindGameObjectWithTag(animaterObject.name).GetComponentInChildren<Animator>().SetBool("makeAnimation", true);
                    // Set Animation of DEEPPAN Animator Object
                    GameObject.FindGameObjectWithTag(goalObjectAnimator.name).gameObject.transform.GetChild(0).gameObject.GetComponentInChildren<Animator>().SetBool("makeAnimation", true);

                } else
                {
                    try
                    {
                        switch (_recipe.Ingredients[workingObjectName].animation)
                        {
                            case AnimationType.DROP:
                                DropAnimation(animaterObject);
                                break;
                            case AnimationType.MOVE_IN_CIRCLE:
                                CircleMovementAnimation(animaterObject);
                                break;
                            case AnimationType.ROTATE_VERTICAL:
                                RotateAnimation(animaterObject);
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        DropAnimation(animaterObject);
                    }
                    _currentAnimationObject = animaterObject;
                    GameObject.FindGameObjectWithTag(animaterObject.name).GetComponentInChildren<Animator>().SetBool("makeAnimation", true);
                }

                

            }

            
        }
        // Reset index as all animations are shown
        else
        {
            _workinObjectAnimationIndex = 0;
            PlaceObjectsOfCurrentStep();   
        }
        

    }

    
    /// <summary>
    /// Places object for drop animation
    /// </summary>
    /// <param name="animaterObject"></param>
    private void DropAnimation(GameObject animaterObject)
    {
        ObjectHandler.AddObject(animaterObject, new Vector3(_postionOfAnchor.x, _postionOfAnchor.y + 0.3f, _postionOfAnchor.z));
    }

    /// <summary>
    /// Places object for circle movement animation
    /// </summary>
    /// <param name="animaterObject"></param>
    private void CircleMovementAnimation(GameObject animaterObject)
    {
        switch (_goalObject.name)
        {
            case GameObjects.PAN:
                ObjectHandler.AddObject(animaterObject, new Vector3(_postionOfAnchor.x, _postionOfAnchor.y + 0.06f, _postionOfAnchor.z));
                break;
            case GameObjects.DEEPPAN:
                ObjectHandler.AddObject(animaterObject, new Vector3(_postionOfAnchor.x, _postionOfAnchor.y + 0.15f, _postionOfAnchor.z));
                break;
            case GameObjects.BOWL:
                ObjectHandler.AddObject(animaterObject, new Vector3(_postionOfAnchor.x, _postionOfAnchor.y + 0.06f, _postionOfAnchor.z));
                break;
            default:
                ObjectHandler.AddObject(animaterObject, new Vector3(_postionOfAnchor.x, _postionOfAnchor.y + 0.06f, _postionOfAnchor.z));
                break;
        }

    }

    /// <summary>
    /// Places object for rotation animation
    /// </summary>
    /// <param name="animaterObject"></param>
    private void RotateAnimation(GameObject animaterObject)
    {
        switch (_goalObject.name)
        {
            case GameObjects.PAN:
                ObjectHandler.AddObject(animaterObject, new Vector3(_postionOfAnchor.x + 0.2f, _postionOfAnchor.y + 0.4f, _postionOfAnchor.z));
                break;
            case GameObjects.BOWL:
                ObjectHandler.AddObject(animaterObject, new Vector3(_postionOfAnchor.x, _postionOfAnchor.y + 0.3f, _postionOfAnchor.z));
                break;
            default:
                ObjectHandler.AddObject(animaterObject, new Vector3(_postionOfAnchor.x + 0.2f, _postionOfAnchor.y + 0.4f, _postionOfAnchor.z));
                break;
        }   

    }

    private void AnimationEnd()
    {
        if (_goalObjectAnimation)
        {
            _goalObjectAnimation = false;
            var goalAnimatorObjectName = _goalObject.name + "_animator";
            GameObject.FindGameObjectWithTag(goalAnimatorObjectName).gameObject.transform.GetChild(0).gameObject.GetComponentInChildren<Animator>().SetBool("makeAnimation", true);
            ObjectHandler.RemoveObject(GameObject.FindGameObjectWithTag(goalAnimatorObjectName));
            // new goal object with water inside
            _goalObject = GetGameObject(GameObjects.DEEPPAN_WITH_WATER);
            PlaceManager(new List<GameObject> { _goalObject }, new List<Vector3> { _postionOfAnchor });
        }
            
        GameObject.FindGameObjectWithTag(_currentAnimationObject.name).GetComponentInChildren<Animator>().SetBool("makeAnimation", false);
        ObjectHandler.RemoveObject(GameObject.FindGameObjectWithTag(_currentAnimationObject.name));
        _animationIsOn = false;
        _workinObjectAnimationIndex++;
        AnimationHandler();
    }

    #endregion

}
