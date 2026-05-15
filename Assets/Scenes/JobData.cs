using UnityEngine;


[CreateAssetMenu(fileName = "NewJob", menuName = "Schadenfreude/JobData")]
public class JobData : ScriptableObject
{
    public string job_name;
    public string display_job_name;
    public bool has_devil;
    public bool third;
    [TextArea]
    public string description;
}
