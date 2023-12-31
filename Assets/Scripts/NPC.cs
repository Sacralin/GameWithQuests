using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public QuestMarker questMarker;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Quest quest = QuestManager.instance.quests.Find(q => q.questName == questMarker.questName);

            if(quest == null) //quest not yet started
            {
                QuestManager.instance.AddQuest(questMarker.questName, questMarker.questDesc);
                questMarker.gameObject.SetActive(true);
                Debug.Log(questMarker.questDesc);
            }
            else if(quest.isCompleted) 
            {
                Debug.Log(questMarker.questCompletionMessage);
            }
            else
            {

            }
        }
    }
}
