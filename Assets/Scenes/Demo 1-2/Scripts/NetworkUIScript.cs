using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkUIScript : MonoBehaviour
{
    [SerializeField] GameObject disconnectButton; //Assigned in editor.
#if UNITY_SERVER && !UNITY_EDITOR
    // Start is called before the first frame update
    public void Start()
    {
        NetworkManager.Singleton.StartServer();
    }
#else
    public void ButtonStartHost()
    {
        NetworkManager.Singleton.StartHost();
        disconnectButton.SetActive(true);
    }
    public void ButtonStartServer()
    {
        NetworkManager.Singleton.StartServer();
        disconnectButton.SetActive(true);
    }
    public void ButtonStartClient()
    {
        NetworkManager.Singleton.StartClient();
        disconnectButton.SetActive(true);
    }
    public void ButtonDisconnect()
    {
        NetworkManager.Singleton.Shutdown();
        disconnectButton.SetActive(false);
    }
#endif
}
