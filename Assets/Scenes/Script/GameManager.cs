using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<JobSetting> job_set = new List<JobSetting>();
    [SerializeField] private List<Player> players = new List<Player>();
    [SerializeField] private UIManager uimanager;
    [SerializeField] private TMP_InputField member_name;
    public List<string> players_name = new List<string>();
    int total_member = 0;

    public void NameSet()
    {
        if (!string.IsNullOrEmpty(member_name.text))
        {
            players_name.Add(member_name.text);
            member_name.text = "";
            if (total_member <= players_name.Count)
            {
                uimanager.DestroyMemberName();
                StartGame();
            }
        }
    }
    public async void StartGame()
    {
        List<JobData> jobpool = CreateJobPool();

        JobSet(jobpool);

        for (int i = 0;i < jobpool.Count;i++)
        {
            players.Add(new Player(i, players_name[i], jobpool[i]));
        }

        PossessDevil();

        for (int i = 0; i < players.Count; i++)
        {
            await uimanager.NameDisclosure(players[i]);
        }
    }

    private List<JobData> CreateJobPool()
    {
        List<JobData> pool = new List<JobData>();
        foreach(var set in job_set)
        {
            for(int i = 0; i < set.count; i++)
            {
                pool.Add(set.job);
            }
        }
        return pool;
    }

    private void JobSet(List<JobData> list)
    {
        for(int i = 0;i < list.Count;i++)
        {
            JobData tmp = list[i];
            int random = Random.Range(i, list.Count);
            list[i] = list[random];
            list[random] = tmp;
        }
    }

    public void JobSettings(JobData set_job, int amount)
    {
        for(int i = 0;i < job_set.Count;i++)
        {
            if (job_set[i].job == set_job)
            {
                total_member += amount - job_set[i].count;
                job_set[i] = new JobSetting
                {
                    job = set_job,
                    count = amount
                };
                Debug.Log($"set job:{set_job} count:{amount}");
                return;
            }
        }

        job_set.Add(new JobSetting { job = set_job, count=amount });
        total_member += amount;
        Debug.Log($"add job:{set_job} count:{amount}");
    }

    public void PossessDevil()
    {
        bool isDevil = false;
        while(!isDevil)
        {
            int devil_player = Random.Range(0, players.Count);
            if (players[devil_player].job.has_devil)
            {
                players[devil_player].SetDevil();
                isDevil = true;
            }

        }
    }

}
