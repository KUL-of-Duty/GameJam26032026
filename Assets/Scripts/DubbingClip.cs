using UnityEngine;
using UnityEngine.Playables;

public class DubbingClip : PlayableAsset
{
    public string fileName;
    [TextArea(3, 5)]
    public string dubbingText;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DubbingBehaviour>.Create(graph);
        DubbingBehaviour behaviour = playable.GetBehaviour();

        // Przekazujemy dane bezpoœrednio z klipu do logiki
        behaviour.fileName = fileName + ".mp3";
        behaviour.dubbingText = dubbingText;

        return playable;
    }
}