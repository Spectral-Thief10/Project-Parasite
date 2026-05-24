using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    public void Resume() => GameManager.Instance.Resume();
    public void Retry() => GameManager.Instance.Retry();
    public void Quit() => GameManager.Instance.QuitGame();
}
