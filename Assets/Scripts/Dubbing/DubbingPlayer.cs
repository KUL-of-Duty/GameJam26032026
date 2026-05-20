using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class DubbingPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public TMP_Text subtitleText;

    public void PlayFrase(string fileName, string subtitleTextValue)
    {
        StartCoroutine(LoadAndPlayAudio(fileName + ".mp3", subtitleTextValue));
    }

    public IEnumerator ShowAndHideText(float time)
    {
        yield return new WaitForSeconds(time);
        subtitleText.text = "";
    }

    public IEnumerator LoadAndPlayAudio(string fileName, string subtitlesTextValue)
    {
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
        if (!path.Contains("://")) path = "file://" + path;

        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                AudioClip clip = DownloadHandlerAudioClip.GetContent(www);
                StartCoroutine(ShowAndHideText(clip.length));
                audioSource.PlayOneShot(clip);
                subtitleText.text = subtitlesTextValue;
            }
            else
            {
                Debug.Log($"[Timeline Error] Brak pliku: {path} | B��d: {www.error}");
            }
        }
    }
}