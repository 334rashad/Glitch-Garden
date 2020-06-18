using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.7f;
    [SerializeField] Slider diffulctySlider;
    [SerializeField] float defaultDiffulcty = 0f;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefController.GetMasterVolume();
        diffulctySlider.value = PlayerPrefController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else Debug.Log("No Music Player Found");
    }

    public void SaveAndExit()
    {
        PlayerPrefController.SetMasterVolume(volumeSlider.value);
        PlayerPrefController.SetDifficulty(diffulctySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaultVolume()
    {
        volumeSlider.value = defaultVolume;
        diffulctySlider.value = defaultDiffulcty; 
    }
}
 