using System.Runtime.InteropServices;
using UnityEngine;

public class language : MonoBehaviour
{
    [DllImport ("__Internal")]
    private static extern string GetLang();

    public string CurrentLanguage;

    public void Awake()
    {
        CurrentLanguage = GetLang();
    }
}
