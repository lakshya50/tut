public class ending : MonoBehaviour
{
    public float fadeDuration=1f;
    public float displayImageDuration=1f;
    public GameObject player;
    public CanvasGroup exitBackground;
    public CanvasGroup loseBackground;
    public AudioSource exitAudio;
    public AudioSource caughtAudio;
    bool atExit=false;
    bool caught=false;
    float timer=0f;
    bool hasAudioPlayed=false;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==player)
            atExit=true;
    }
    public void CaughtPlayer()
    {
        caught=true;
    }
    void Update()
    {
        if(atExit) EndLevel(exitBackground,false,exitAudio);
        else if(caught) EndLevel(loseBackground,true,caughtAudio);
    }
    void EndLevel(CanvasGroup image,bool reset,AudioSource audioSource)
    {
        if(!hasAudioPlayed)
        {
            audioSource.Play();
            hasAudioPlayed=true;
        }
        timer+=Time.deltaTime;
        image.alpha=timer/fadeDuration;
        if(timer>fadeDuration+displayImageDuration)
        {
            if(reset)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
