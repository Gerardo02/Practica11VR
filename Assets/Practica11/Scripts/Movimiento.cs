using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpeechLib;

public class Movimiento : MonoBehaviour
{

    [SerializeField] float m_speed = 10f;

    //panel
    [SerializeField] GameObject panel;

    //Variable para sonido a voz
    private SpVoice voice;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        voice = new SpVoice();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.right * -m_speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(Vector3.forward * -m_speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right * m_speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        voice.Volume = 100;
        voice.Rate = 0;
        
        if(collider.gameObject.tag == "CajaSigno")
        {
            panel.gameObject.SetActive(true);
            //finaltext puede ser la variable que vena de una caja de texto u otro objeto
            voice.Speak("Holy shit thank you for moving the cube 77777777777777777", SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }
    }
    void OnTriggerExit(Collider collider)
    {
        
        if(collider.gameObject.tag == "CajaSigno")
        {
            panel.gameObject.SetActive(false);
            //finaltext puede ser la variable que vena de una caja de texto u otro objeto
            voice.Speak("Fuck off nerd", SpeechVoiceSpeakFlags.SVSFlagsAsync);
        }
    }
}
