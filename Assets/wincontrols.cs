
using UnityEngine;
using UnityEngine.SceneManagement;

public class wincontrols : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball")
        {
            SceneManager.LoadScene("TestGolfScene2");
        }

    }
}
