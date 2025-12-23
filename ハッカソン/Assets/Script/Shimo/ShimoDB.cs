using UnityEngine;

public class ShimoDB : MonoBehaviour
{
    public static ShimoDB Instance;

    private float koudo = 30;
    public float getkoudo() { return koudo; }
    public void setkoudo(float n) { koudo = n; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
