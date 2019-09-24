using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject restartMenu;
    public GameObject player;

    private static GameObject _restartMenu;
    private static GameObject _player;

    private void Start()
    {
        _restartMenu = restartMenu;
        _player = player;
    }

    public static void OpenRestartMenu()
    {
        _restartMenu.gameObject.SetActive(true);
        _player.SetActive(false);
    }
}
