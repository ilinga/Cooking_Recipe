using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManagerScript : MonoBehaviour
{

    public List<GameObject> gameObjects;
    private int _currentStep;
    private GameObject _goalObject;
    private List<GameObject> _workingObjects;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
        var carbonara = new Carbonara(participants);

        for(int stepIndex = 0; stepIndex < carbonara.CookingSteps.Count; stepIndex++)
        {
            _workingObjects = new List<GameObject>();
            var cookingStep = carbonara.CookingSteps[stepIndex];

            //place goal object
            _goalObject = GetGameObject(cookingStep.GoalObject);
            //get position of anchor board and remove the board
            var board = GameObject.Find(GameObjects.BOARD);
            var positionOfAnchor = board.transform.position;
            ObjectHandler.RemoveObject(board);
            PlaceManager(new List<GameObject> { _goalObject }, new List<Vector3> { positionOfAnchor });

            //place working objects
            List<Vector3> positionOfWorkingObjects = new List<Vector3>();
            positionOfWorkingObjects.Add(new Vector3(positionOfAnchor.x + 5, positionOfAnchor.y, positionOfAnchor.z));
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
                //positionOfWorkingObjects.Add()
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
