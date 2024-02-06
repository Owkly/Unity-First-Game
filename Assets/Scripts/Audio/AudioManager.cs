using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;

    public AudioMixerGroup soundEffectMixer;


    public static AudioManager instance;

    //fonction lu avant toutes les autres fonctions, même avant start
    //Ca permet d'accéder au scrip inventory n'importe où
    //grâce à static
    //C'est ce qu'on appelle un singleton
    private void Awake()
    {
        if (instance != null)
        {
            //Permet de faire en sorte qu'il y ait un seul inventaire
            Debug.LogWarning("Il y a plus d'une instance de AudioManager dans la scène");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("alreadyLauched", 0) == 0)
        {
            audioSource.clip = playlist[0];
            audioSource.Play();
            PlayerPrefs.SetInt("alreadyLauched", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            //permet de vérifier si la musique est terminé ou non
            playNextSong();
        }
    }

    void playNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        //temporary game object
        GameObject tempGO = new GameObject("TempAudio");

        //Met le son à la position pos 
        tempGO.transform.position = pos;
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();

        //Permet de lancer le clip que l'on a mit en paramètre
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;

        //Permet de jouer le son
        audioSource.Play();

        //Permet de détruire l'objet seulement lorsque le son s'est fini
        Destroy(tempGO, clip.length);
        return audioSource;
    }
}