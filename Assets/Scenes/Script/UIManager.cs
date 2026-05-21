using TMPro;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine.Experimental.AI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gamemaneger;
    [SerializeField] private TMP_InputField member_name;
    [SerializeField] private GameObject add_button;
    [SerializeField] private GameObject name_disclosure;
    [SerializeField] private Transform canvas;
    [SerializeField] private Button name_accept;
    [SerializeField] private GameObject job_announce;
    [SerializeField] private Button job_accept;
    [SerializeField] private GameObject attribute_announce;
    [SerializeField] private Button attribute_accept;
    [SerializeField] private Button go_vote;
    [SerializeField] private GameObject vote_list;
    [SerializeField] private Button vote;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void DestroyMemberName()
    {
            Destroy(this.member_name.gameObject);
            Destroy(this.add_button);
    }
    public async Task NameDisclosure(Player player)
    {
       
        GameObject name_announce = Instantiate(this.name_disclosure, canvas);
        TextMeshProUGUI name = name_announce.GetComponent<TextMeshProUGUI>();
        name.text = $"あなたは{player.name}ですか";
        Button button = Instantiate(this.name_accept, this.canvas);
        await button.OnClickAsync(this.GetCancellationTokenOnDestroy());

        Destroy(name_announce.gameObject);
        Destroy(button.gameObject);
    }

    public async Task JobDisclosure(Player player)
    {
        GameObject job_announce = Instantiate(this.job_announce, this.canvas);
        TextMeshProUGUI job_text = job_announce.GetComponent<TextMeshProUGUI>();
        job_text.text = $"あなたの役職は\r\n{player.job.display_job_name}です。";
        Button button = Instantiate(this.job_accept, this.canvas);
        await button.OnClickAsync(this.GetCancellationTokenOnDestroy());
        Destroy(button.gameObject);
        Destroy(job_text.gameObject);
    }
   
    public async Task AttributeDisclosure(Player player)
    {
        GameObject attribute_announce = Instantiate(this.attribute_announce, this.canvas);
        TextMeshProUGUI attribute_text = attribute_announce.GetComponent <TextMeshProUGUI>();
        switch (player.attribute)
        {
            case Attribute.villager : attribute_text.text = $"あなたは人間です。\r\n他の人間と協力しながら\r\n悪魔を追放しましょう。\r\nもちろん、あなた自身が\r\n死ぬことのないように。"; break;
            case Attribute.devil : attribute_text.text = $"悪魔に魅入られました。\r\nあなたの周りの汚れた魂を\r\n残らず救済しましょう。\r\nもちろん、悟られることなく\r\n死ぬことのないように。"; break;
            case Attribute.third : attribute_text.text = $"あなたは人外です。\r\n他のものを利用し\r\n目標を達成しましょう。\r\nもちろん、あなた自身が\r\n死ぬことのないように。"; break;
            default: attribute_text.text = $"これはエラーです。\r\nあなたはこのゲームの\r\n理から外れた存在\r\nぜひこの世界の作者に\r\n伝えてあげてください"; break;
        }
        Button button = Instantiate(this.attribute_accept, this.canvas);
        await button.OnClickAsync(this.GetCancellationTokenOnDestroy());
        Destroy(button.gameObject);
        Destroy(attribute_text.gameObject);
    }
    public async Task DisscussionUI()
    {
        Button button = Instantiate(this.go_vote, this.canvas);
        await button.OnClickAsync(this.GetCancellationTokenOnDestroy());
        Destroy(button.gameObject);
    }

    public async Task<int> WhoVote(List<string> name)
    {
        GameObject vote_list = Instantiate(this.vote_list, this.canvas);
        TMP_Dropdown dropdown = vote_list.GetComponent<TMPro.TMP_Dropdown>();
        dropdown.ClearOptions();
        dropdown.AddOptions(name);
        dropdown.value = 0;
        Button button = Instantiate(this.vote, this.canvas);
        await button.OnClickAsync(this.GetCancellationTokenOnDestroy());
        int vote_target = dropdown.value;
        Debug.Log($"vote:{vote_target}");
        Destroy(button.gameObject);
        Destroy(dropdown.gameObject);
        return vote_target;
    }
}
