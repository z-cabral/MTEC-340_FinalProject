using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAudio : MonoBehaviour
{
    [SerializeField] float _minTime=10, _maxTime=30;
    [SerializeField] AudioSource dxSource;
    [SerializeField] AudioClip[] dxSearchingClips, dxSuspiciousClips, dxUnsuspiciousClips, dxFoundClips, dxShutDownClips;
    [SerializeField] AudioClip SelectedClip;


    bool _isWaiting;
    float curClipLength;
    int clipIndex=0, prevClipIndex;

    private void Start()
    {
        _isWaiting = false;
        dxSource = GetComponent<AudioSource>();
        dxSource.playOnAwake = false;
        dxSource.loop = false;
        dxSource.spatialBlend = 1.0f;
    }

    public void SearchingVO()
    {
        //
        if (dxSource.isPlaying == false && _isWaiting==false)
        {
            StopCoroutine(WaitToPlayNextClip());
            prevClipIndex = clipIndex;
            clipIndex = Random.Range(0, dxSearchingClips.Length - 1);
            if (clipIndex == prevClipIndex)
            {
                clipIndex = Random.Range(0, dxSearchingClips.Length - 1);
            }

            SelectedClip = dxSearchingClips[clipIndex];
            curClipLength = SelectedClip.length;
            dxSource.clip = SelectedClip;
            dxSource.Play();

            StartCoroutine(WaitToPlayNextClip());
        }
    }

    IEnumerator WaitToPlayNextClip()
    {
        _isWaiting = true;
        float waitTime = Random.Range(_minTime, _maxTime);
        Debug.Log(waitTime);
        yield return new WaitForSeconds(waitTime);
        _isWaiting = false;
    }

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
