using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement ;
public class PlayVideo : MonoBehaviour {

    RawImage video;
    AudioSource au;
    // Use this for initialization

    public MovieTexture t;
    public AudioClip c;

    void Start()
    {
        au = this.GetComponent<AudioSource>();
        video = this.GetComponent<RawImage>();
        video.color = new Vector4(video.color.r, video.color.g, video.color.b, 0);

        ReproducirVideo(t, c);


    }

    // Update is called once per frame
    void Update()
    {

    }



    public void ReproducirVideo(MovieTexture Movie, AudioClip Clip)
    {
        movie = Movie;
        clip = Clip;
        StartCoroutine("ReproducirIntro");
    }
    MovieTexture movie;
    AudioClip clip;

    IEnumerator ReproducirIntro()
    {
        video.color = new Vector4(video.color.r, video.color.g, video.color.b, 1);
        movie.Play();
        au.clip = clip;
        au.Play();
        yield return new WaitForSeconds(movie.duration);
        movie.Stop();
        au.Stop();
        video.color = new Vector4(video.color.r, video.color.g, video.color.b, 0);

	 
		SceneManager.LoadScene ("KinectAvatarsDemo");
    }
}