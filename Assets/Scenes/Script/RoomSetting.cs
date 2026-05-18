using UnityEngine;
using System.Collections.Generic;

public class RoomSetting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameManager gamemanager;
    [SerializeField] private JobData villager;
    [SerializeField] private JobData doctor;
    [SerializeField] private JobData priest;
    [SerializeField] private JobData knight;
    [SerializeField] private JobData undertaker;
    private void Awake()//役職振り分けテスト用
    {
        gamemanager.JobSettings(villager, 4);
        gamemanager.JobSettings(doctor, 1);
        gamemanager.JobSettings(priest, 1);
        gamemanager.JobSettings(knight, 1);
        gamemanager.JobSettings(undertaker, 1);
    }
}