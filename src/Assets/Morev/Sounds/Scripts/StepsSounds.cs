using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StepsSounds : MonoBehaviour
{
    AudioManager audioManager;
    List<string> groundSteps = new List<string>();
    List<string> snowSteps = new List<string>();
    List<string> usualSteps = new List<string>();
    GameObject currentGround;
    private void Start()
    {
        string soundName;
        audioManager = GetComponent<AudioManager>();
        for(int i = 1; i < 20; i++)
        {
            soundName = "stepGround" + i.ToString();
            Sound s = Array.Find(audioManager.sounds, sound => sound.name == soundName);
            if (s != null)
            {
                groundSteps.Add(s.name);
            }
        }
        for (int i = 1; i < 20; i++)
        {
            soundName = "stepSnow" + i.ToString();
            Sound s = Array.Find(audioManager.sounds, sound => sound.name == soundName);
            if (s != null)
            {
                snowSteps.Add(s.name);
            }
        }
        for (int i = 1; i < 20; i++)
        {
            soundName = "stepUsual" + i.ToString();
            Sound s = Array.Find(audioManager.sounds, sound => sound.name == soundName);
            if (s != null)
            {
                usualSteps.Add(s.name);
            }
        }
        //StartCoroutine(StepSounds());
        //StartCoroutine(StepSoundsStop());
    }


    int currentStep = 0;
    IEnumerator StepSounds()
    {
        while (true)
        {
            if (currentGround.CompareTag("ground") && GetComponent<CharacterController>().isGrounded && isPlayerMoving())
            {
                currentStep = UnityEngine.Random.Range(0, groundSteps.Count);
                audioManager.Play(groundSteps[currentStep]);
                yield return new WaitForSeconds(0.5f);
            }
            if (currentGround.CompareTag("snow") && GetComponent<CharacterController>().isGrounded && isPlayerMoving())
            {
                currentStep = UnityEngine.Random.Range(0, snowSteps.Count);
                audioManager.Play(snowSteps[currentStep]);
                yield return new WaitForSeconds(0.5f);
            }
            if (currentGround.CompareTag("usual") && GetComponent<CharacterController>().isGrounded && isPlayerMoving())
            {
                currentStep = UnityEngine.Random.Range(0, usualSteps.Count);
                audioManager.Play(usualSteps[currentStep]);
                yield return new WaitForSeconds(0.5f);
            }
            yield return null;
        }
    }
    IEnumerator StepSoundsStop()
    {
        int oldCurrentStep = currentStep;
        while(true)
        {
            if (!(currentGround.CompareTag("ground") && GetComponent<CharacterController>().isGrounded && isPlayerMoving()) && (oldCurrentStep != currentStep))
            {
                audioManager.SoftStop(groundSteps[currentStep],1000);
                oldCurrentStep = currentStep;
            }
            if (!(currentGround.CompareTag("snow") && GetComponent<CharacterController>().isGrounded && isPlayerMoving()) && (oldCurrentStep != currentStep))
            {
                audioManager.SoftStop(snowSteps[currentStep], 1000);
                oldCurrentStep = currentStep;
            }
            if (!(currentGround.CompareTag("usual") && GetComponent<CharacterController>().isGrounded && isPlayerMoving()) && (oldCurrentStep != currentStep))
            {
                audioManager.SoftStop(usualSteps[currentStep], 1000);
                oldCurrentStep = currentStep;
            }
            yield return null;
        }
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.normal.y > 0.9f)
            currentGround = hit.collider.gameObject;
    }

    bool isPlayerMoving()
    {
        return (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D));
    }
    private void Update()
    {
    }
}
