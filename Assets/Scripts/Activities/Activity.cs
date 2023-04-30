using UnityEngine;

public abstract class Activity
{
    protected string ActivityName { get; set; }

    protected int NeededTime { get; set; }

    protected float ExpiredTime { get; set; }

    public bool Finished { get; set; }

    // public string Description { get; set; }

    public Activity(string activityName, int neededTime)
    {
        ActivityName = activityName;
        NeededTime = neededTime;
        ExpiredTime = 0;
        Finished = false;
    }

    public abstract void DoIt(Cat cat);

}