using UnityEngine;
public  class Practice : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
    }
}
