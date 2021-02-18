using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChannelControl : MonoBehaviour{
    [FMODUnity.EventRef]
    [SerializeField] private string musics;

    private float value;

    [SerializeField] private Scrollbar scrollbar;

    private FMOD.Studio.EventInstance instance;

    private void Start() {
        instance = FMODUnity.RuntimeManager.CreateInstance(musics);
        instance.start();
    }

    public void ChangeValue() {
        value = scrollbar.value;
        instance.setParameterByName("Track", value);
    }

    public void OnDestroy() {
        instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
