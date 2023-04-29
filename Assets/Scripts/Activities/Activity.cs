using UnityEngine;

public abstract class Activity
{
    protected string ActivityName { get; set; }

    protected int Duration { get; set; }

    protected bool Finished { get; set; }

    // public string Description { get; set; }

    public Activity(string activityName, int duration)
    {
        ActivityName = activityName;
        Duration = duration;
        Finished = false;
    }

    public abstract void DoIt(Cat cat);

}