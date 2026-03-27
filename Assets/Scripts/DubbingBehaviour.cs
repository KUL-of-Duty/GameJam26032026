using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class DubbingBehaviour : PlayableBehaviour
{
    public string fileName;
    public string dubbingText;
    private bool hasStartedLoading = false;
    private TMP_Text activeTextDisplay; // Zapamiêtujemy, gdzie czyœciæ tekst

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        if (string.IsNullOrEmpty(fileName) || hasStartedLoading) return;

        // Pobieramy nasz "Manager" z bindingu Tracka
        DubbingPlayer player = info.output.GetUserData() as DubbingPlayer;

        if (player != null)
        {
            activeTextDisplay = player.subtitleText;

            // Ustawiamy napisy od razu
            if (activeTextDisplay != null) activeTextDisplay.text = dubbingText;

            // Odpalamy dŸwiêk
            if (player.audioSource != null)
            {
                player.gameObject.GetComponent<MonoBehaviour>().StartCoroutine(LoadAndPlayAudio(player.audioSource));
            }

            hasStartedLoading = true;
        }
    }

    public IEnumerator LoadAndPlayAudio(AudioSource source)
    {
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
        if (!path.Contains("://")) path = "file://" + path;

        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                AudioClip clip = DownloadHandlerAudioClip.GetContent(www);
                source.PlayOneShot(clip);
            }
            else
            {
                Debug.LogError($"[Timeline Error] Brak pliku: {path} | B³¹d: {www.error}");
            }
        }
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        hasStartedLoading = false;

        // Czyœcimy tekst, gdy g³owica Timeline wyjdzie poza klip
        if (activeTextDisplay != null)
        {
            activeTextDisplay.text = "";
        }
    }
}