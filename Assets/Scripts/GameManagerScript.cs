using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    public List<GameObject> gameObjects;
    public Button BackButton;
    private int _currentStep = -1;
    private GameObject _goalObject;
    private List<GameObject> _workingObjects;
    private IRecipe _recipe = null;
    private Vector3 _postionOfAnchor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_currentStep > 0)
            BackButton.gameObject.SetActive(true);
        else
            BackButton.gameObject.SetActive(false);
        

        if (_recipe != null)
        {
            var amountSteps = _recipe.CookingSteps.Count;
            if (0 <= _currentStep && _currentStep < amountSteps)
                GameObject.Find("next_button").GetComponentInChildren<Text>().text = "Next step";
            else if(_currentStep == _recipe.CookingSteps.Count)
                GameObject.Find("next_button").GetComponentInChildren<Text>().text = "Finish! Back to menu";

            if (_workingObjects.Count > 0)
            {
                var goalObjectPosition = GameObject.FindGameObjectWithTag(_goalObject.name).transform.position;
                List<GameObject> objectsToRemove = new List<GameObject>();
                foreach (var workingObject in _workingObjects)
                {
                    var obj = GameObject.FindGameObjectWithTag(workingObject.name);
                    if(obj != null)
                    {
                        var workingObjectPosition = obj.transform.position;
                        var distanceSqr = (goalObjectPosition - workingObjectPosition).sqrMagnitude;
                        if (distanceSqr <= 2)
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
            else if(_currentStep < _recipe.CookingSteps.Count)
            {
                _currentStep++;
                NextStep();
            }
            
        }
    }

    

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

    public void StartRecipe()
    {
        _currentStep = 0;
        var participants = 4;

        _recipe = new Carbonara(participants);
        
        _workingObjects = new List<GameObject>();
        var cookingStep = _recipe.CookingSteps[_currentStep];

        //place goal object
        _goalObject = GetGameObject(cookingStep.GoalObject);
        //get position of anchor board and remove the board
        var board = GameObject.Find(GameObjects.BOARD);
        _postionOfAnchor = board.transform.position;
        ObjectHandler.RemoveObject(board);
        PlaceManager(new List<GameObject> { _goalObject }, new List<Vector3> { _postionOfAnchor });

        //place working objects
        List<Vector3> positionOfWorkingObjects = new List<Vector3>();
        positionOfWorkingObjects.Add(new Vector3(_postionOfAnchor.x + 5, _postionOfAnchor.y, _postionOfAnchor.z));
        for(int objectIndex = 0; objectIndex < cookingStep.WorkingObjects.Count; objectIndex++)
        {
            if (objectIndex > 0)
            {
                var oldPosition = positionOfWorkingObjects[objectIndex - 1];
                var position = new Vector3(oldPosition.x + 5, oldPosition.y, oldPosition.z);
                positionOfWorkingObjects.Add(position);
            }
            var workingObjectName = cookingStep.WorkingObjects[objectIndex];
            _workingObjects.Add(GetGameObject(workingObjectName));
        }
        PlaceManager(_workingObjects, positionOfWorkingObjects);
                
    }

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
                    ObjectHandler.RemoveObject(GameObject.FindGameObjectWithTag(obj.name));
                _workingObjects.Clear();
                _currentStep++;
                NextStep();
            }
            // Recipe finished
            else
            {
                // Do stuff when Finished
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
            foreach (var obj in _workingObjects)
                ObjectHandler.RemoveObject(GameObject.FindGameObjectWithTag(obj.name));
            _workingObjects.Clear();
            _currentStep--;
            NextStep();
        }
        

    }

    private void NextStep()
    {
        ObjectHandler.RemoveObject(GameObject.FindGameObjectWithTag(_goalObject.name));
        if (_currentStep < _recipe.CookingSteps.Count)
        {
            _workingObjects = new List<GameObject>();
            var cookingStep = _recipe.CookingSteps[_currentStep];

            //place goal object
            _goalObject = GetGameObject(cookingStep.GoalObject);
            //get position of anchor board and remove the board
            PlaceManager(new List<GameObject> { _goalObject }, new List<Vector3> { _postionOfAnchor });

            //place working objects
            List<Vector3> positionOfWorkingObjects = new List<Vector3>();
            positionOfWorkingObjects.Add(new Vector3(_postionOfAnchor.x + 5, _postionOfAnchor.y, _postionOfAnchor.z));
            for (int objectIndex = 0; objectIndex < cookingStep.WorkingObjects.Count; objectIndex++)
            {
                if (objectIndex > 0)
                {
                    var oldPosition = positionOfWorkingObjects[objectIndex - 1];
                    var position = new Vector3(oldPosition.x + 5, oldPosition.y, oldPosition.z);
                    positionOfWorkingObjects.Add(position);
                }
                var workingObjectName = cookingStep.WorkingObjects[objectIndex];
                _workingObjects.Add(GetGameObject(workingObjectName));
            }
            PlaceManager(_workingObjects, positionOfWorkingObjects);
        }
        /*
        else
        {
            GameObject.Find("next_button").GetComponentInChildren<Text>().text = "Finish! Back to menu";
        }*/

    }


    private GameObject GetGameObject(string name)
    {
        foreach(var obj in gameObjects)
        {
            if(obj.name == name)
            {
                return obj;
            }
        }
        return null;
    }


}
