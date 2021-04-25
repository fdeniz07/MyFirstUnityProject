using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sahneyuklemekodu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // SceneManager: Calisma zamaninda sahne gecisleri, eski sahnelerin silinmesini yönetir

    }
}
