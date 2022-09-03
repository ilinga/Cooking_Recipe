using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManagerScript : MonoBehaviour
{

    public List<GameObject> gameObjects;
    private int _currentStep = 0;
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
        if (_recipe != null)
        {
            if(_workingObjects.Count > 0)
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
            else
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
