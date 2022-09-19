using UnityEngine;

public class PhoneMessengerView : TextMessageLayoutView
{
    [SerializeField]
    GameObject[] bubblePrefabs;

    protected override void DoStart()
    {
        base.DoStart();
    }

    protected override TextMessageView MakeView(TextMessage textMessage)
    {
        return Instantiate(GetBubblePrefab(textMessage.SpeakerId), 
            transform.parent).GetComponent<PhoneTextMessageView>();

    }

    private GameObject GetBubblePrefab(int id)
    {
        return bubblePrefabs[id % bubblePrefabs.Length];
    }
}