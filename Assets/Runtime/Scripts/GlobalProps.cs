using UnityEngine;

public class GlobalProps : MonoBehaviour
{
    public static bool IsLogin;
    public static string UserName;

    private void Awake()
    {
        GlobalProps[] props = FindObjectsOfType<GlobalProps>();

        if (props.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
