using UnityEngine;
using UnityEngine.SceneManagement;

public class ShimoSceneManager : MonoBehaviour
{
    public static ShimoSceneManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void TitleSceneLoad()
    {
        Time.timeScale = 1f;
        ShimoDB.Instance.setkoudo(30);
        SceneManager.LoadScene("shimokouhei");
    }

    public void FlyingCarSceneLoad()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("shimoFlyingCar");
    }
    public void TrackSceneLoad()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("shimoTrack");
    }
    public void PeopleSceneLoad()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("shimoPeople");
    }
}
