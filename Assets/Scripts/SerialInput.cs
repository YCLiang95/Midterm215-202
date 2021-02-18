using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using UnityEngine.UI;

public class SerialInput : MonoBehaviour{
    private static SerialPort _serial;

    [SerializeField] Scrollbar slider;
    [SerializeField] CameraController mainCamera;

    [SerializeField] Light _ledGreen;
    [SerializeField] Light _ledRed;
    [SerializeField] Light _ledBlue;

    private void Start() {
        _serial = new SerialPort("COM3", 9600);
        _serial.ReadTimeout = 50;
        _serial.Open();
    }

    private void Update() {
        string input;
        try {
            input = _serial.ReadLine();
        } catch (Exception e) {
            Debug.Log(e.Message);
            return;
        }

        if (input != null) {
            string[] t = input.Split(' ');
            int value = int.Parse(t[1]);

            if (t.Length == 1) { 

            } else if (t[0].Equals("Rotary:")) {
                slider.value = ((float)value) / 1023;
                ChangeLED();
            } else {
                value -= 512;
                if (t[0].Equals("JoystickX:")) {
                    mainCamera.ChangeX(((float)value));
                } else if (t[0].Equals("JoystickY:")) {
                    mainCamera.ChangeY(((float)value));
                }
            }
        }
    }

    void ChangeLED() {
        _ledBlue.enabled = false;
        _ledGreen.enabled = false;
        _ledRed.enabled = false;
        if (slider.value < 0.33f) {
            _ledGreen.enabled = true;
        } else if (slider.value < 0.67f) {
            _ledRed.enabled = true;
        } else {
            _ledBlue.enabled = true;
        }
    }

    private void OnDestroy() {
        _serial.Close();
    }
}
