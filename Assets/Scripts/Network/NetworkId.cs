using Protocol;
using UnityEngine;

public class NetworkId : MonoBehaviour
{
    [SerializeField]
    private int networkId;

    void Start()
    {
        NetworkObjGroup.Instance.Add(networkId, gameObject);
    }

    private void Update()
    {
        networkId = NetworkManager.Instance.ID;
    }
}
