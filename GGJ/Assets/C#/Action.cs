using UnityEngine;

public class Action : MonoBehaviour
{
    public string actionName;
    public GameObject Tool;
    public Transform Spawn;
    public void MakeAction()
    {
        GameManger manger = GetComponent<GameManger>();
        manger.Open(actionName, Tool, Spawn);
    }
}
