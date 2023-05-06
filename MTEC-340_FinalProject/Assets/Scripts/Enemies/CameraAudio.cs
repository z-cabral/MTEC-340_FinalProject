using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAudio : MonoBehaviour
{
    [SerializeField] AudioSource dxSource;
    [SerializeField] AudioClip[] dxSearchingClips, dxSuspiciousClips, dxUnsuspiciousClips, dxFoundClips, dxShutDownClips;
    [SerializeField] AudioClip SelectedClip;

    bool _isWaiting;
    float curClipLength;
    int clipIndex = 0, prevClipIndex;

    public void SuspiciousVO()
    {
        prevClipIndex = clipIndex;
        clipIndex = Random.Range(0, dxSuspiciousClips.Length - 1);
        if (clipIndex == prevClipIndex)
        {
            clipIndex = Random.Range(0, dxSuspiciousClips.Length - 1);
        }

        SelectedClip = dxSuspiciousClips[clipIndex];
        dxSource.clip = SelectedClip;
        dxSource.Play();
    }

    public void UnsuspiciousVO()
    {
        prevClipIndex = clipIndex;
        clipIndex = Random.Range(0, dxUnsuspiciousClips.Length - 1);
        if (clipIndex == prevClipIndex)
        {
            clipIndex = Random.Range(0, dxUnsuspiciousClips.Length - 1);
        }

        SelectedClip = dxUnsuspiciousClips[clipIndex];
        dxSource.clip = SelectedClip;
        dxSource.Play();
    }

    public void ShutdownVO()
    {
        prevClipIndex = clipIndex;
        clipIndex = Random.Range(0, dxShutDownClips.Length - 1);
        if (clipIndex == prevClipIndex)
        {
            clipIndex = Random.Range(0, dxShutDownClips.Length - 1);
        }

        SelectedClip = dxShutDownClips[clipIndex];
        dxSource.clip = SelectedClip;
        dxSource.Play();
    }

    public void FoundVO()
    {
        prevClipIndex = clipIndex;
        clipIndex = Random.Range(0, dxFoundClips.Length - 1);
        if (clipIndex == prevClipIndex)
        {
            clipIndex = Random.Range(0, dxFoundClips.Length - 1);
        }

        SelectedClip = dxFoundClips[clipIndex];
        dxSource.clip = SelectedClip;
        dxSource.Play();
    }

}
