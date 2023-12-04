using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private float fade_speed = 1f;

    IEnumerator Start()
    {
        _player.GetComponent<playerMovementOlegVer>().enabled = false;
        _player.GetComponent<lookAround>().enabled = false;

        Image fade_image = GetComponent<Image>();
        Color color = fade_image.color;

        while (color.a < 1f)
        {
            color.a += fade_speed * Time.deltaTime;
            fade_image.color = color;
            yield return null;
        }

        SceneManager.LoadScene("MainGame");
    }
}
