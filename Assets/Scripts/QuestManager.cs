using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    //public TMP_Text text;

    //private string questLog = "Quest Log\n";

    [SerializeField] public List<Quest> quests = new List<Quest>();
    public Dictionary<string, QuestMarker> questMarkers = new Dictionary<string, QuestMarker>();

    private void Awake()
    {
        //text = GetComponent<TMP_Text>();
        instance = this;
    }

    public void RegisterQuestMarker(QuestMarker marker)
    {
        if (!questMarkers.ContainsKey(marker.questName)) 
        {
            questMarkers.Add(marker.questName, marker);
            marker.gameObject.SetActive(false);
            //text.text = questLog + marker.questName;
        }
    }

    public void AddQuest(string name, string desc)
    {
        quests.Add(new Quest(name, desc));
        EnableQuestMarker(name);
    }

    public void EnableQuestMarker(string name)
    {
        if (questMarkers.ContainsKey(name))
        {
            questMarkers[name].gameObject.SetActive(true);
        }
    }

    public void CompleteQuest(string name)
    {
        Quest quest = quests.Find(q => q.questName == name);

        if (quest != null)
        {
            quest.isCompleted = true;
            //text.text = questLog;
        }
    }



}
