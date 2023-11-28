[System.Serializable]
public class Quest
{

    public string questName;
    public string questDesc;
    public bool isCompleted;


    public Quest(string name, string desc)
    {
        questName = name;
        questDesc = desc;
        isCompleted = false;

    }


}
