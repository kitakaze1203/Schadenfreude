using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class member : MonoBehaviour
{
    // Start is called before the first frame update
    public string [] members = new string[7];
    public TMP_InputField member_input;
    private int i = 0;
    public void AddMember()
    {
        if (member_input != null && !string.IsNullOrWhiteSpace(member_input.text) && i < 7)
        {
            members[i] = member_input.text;
            Debug.Log(members[i]);
            i++;
            member_input.text = null;
            if (i == 7)
            {
                for (int j = 0; j < members.Length; j++)
                {
                    Debug.Log(members[j]);
                }
            }
        }
        else if (member_input != null && !string.IsNullOrWhiteSpace(member_input.text))
        {
            Debug.Log("member is full");
        }
        else 
        {
            Debug.Log("name is empty");
        }
    }
}
