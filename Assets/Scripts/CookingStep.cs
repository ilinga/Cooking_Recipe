using System;
using System.Collections.Generic;

/// <summary>
/// Descrip
/// </summary>
public class CookingStep
{
    private string _goalObject;
    private List<string> _workingObjects;
    private string _discription;

    public string Discription { get => _discription; }
    public string GoalObject { get => _goalObject; }
    public List<string> WorkingObjects { get => _workingObjects; set => _workingObjects = value; }


    public CookingStep(string goalObject, List<string> workingObjects, string description)
    {
        _discription = description;
        _goalObject = goalObject;
        _workingObjects = workingObjects;
    }


    public List<string> GetAllObjectsOfStep()
    {
        var allObjects = new List<string>();
        allObjects.Add(GoalObject);
        foreach (var obj in WorkingObjects)
            allObjects.Add(obj);
        return allObjects;
    }
}
