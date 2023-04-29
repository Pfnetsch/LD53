using UnityEngine;

public abstract class Activity
{
    string ActivityName { get; set; }

    int Duration { get; set; }

    // public string Description { get; set; }

    public Activity(string activityName, int duration)
    {
        ActivityName = activityName;
        Duration = duration;
    }

    public abstract bool DoIt();

}