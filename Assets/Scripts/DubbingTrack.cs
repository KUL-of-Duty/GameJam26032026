using TMPro;
using UnityEngine;
using UnityEngine.Timeline;

[TrackColor(0.1f, 0.5f, 0.8f)] // Kolor paska w Timeline
[TrackClipType(typeof(DubbingClip))] // Jakie klipy przyjmuje ta œcie¿ka
[TrackBindingType(typeof(DubbingPlayer))]
public class DubbingTrack : TrackAsset { }