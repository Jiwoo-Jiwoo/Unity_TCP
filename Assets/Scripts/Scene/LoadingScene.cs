using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net;

using ServerCore;

public class LoadingScene : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("GameScene");
        op.allowSceneActivation = false;

        string host = Dns.GetHostName();
        IPHostEntry ipHostEntry = Dns.GetHostEntry(host);
        IPAddress ipAddress = ipHostEntry.AddressList[0];

        NetworkManager.Instance.ConnectAsync(new IPEndPoint(ipAddress, 8001));

        while (false == NetworkManager.Instance.IsConnected) yield return null;

        while (false == op.isDone)
        {
            text.text = op.progress.ToString();

            if (0.9f <= op.progress) break;

            yield return null;
        }

        op.allowSceneActivation = true;
    }
}
