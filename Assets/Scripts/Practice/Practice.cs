using UnityEngine;
using UnityEngine.SceneManagement;
public  class Practice : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
