using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject spikePrefab;
    public float summonInterval = 5.0f; // time interval between each spike summon
    public int maxSummons = 3; // maximum number of spikes that can be on the ground at once
    public float moveDuration = 1.0f; // duration of the move animation
    public float waitDuration = 2.0f; // duration of the wait time

    private int currentSummons = 0; // current number of spikes on the ground
    private float lastSummonTime = 0.0f; // time when the last spike was summoned

    void Update()
    {
        if (Time.time - lastSummonTime > summonInterval && currentSummons < maxSummons)
        {
            SummonSpike();
            lastSummonTime = Time.time;
        }
    }

    void SummonSpike()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 spawnPos = new Vector3(playerPos.x, -20f, playerPos.z); // spawn spike below player
        GameObject spike = Instantiate(spikePrefab, spawnPos, Quaternion.identity);
        currentSummons++;

        // move spike upward
        Vector3 targetPos = spike.transform.position + new Vector3(0.0f, 20f, 0.0f); // move upward by 2 units
        LeanTween.move(spike, targetPos, moveDuration).setEaseInOutSine().setOnComplete(() =>
        {
            // wait for 2 seconds
            StartCoroutine(WaitAndMove(spike, 2f, -20.0f));
        });
    }

    IEnumerator WaitAndMove(GameObject spike, float waitTime, float yOffset)
    {
        yield return new WaitForSeconds(waitTime);

        // move spike downward
        Vector3 targetPos = spike.transform.position + new Vector3(0.0f, yOffset, 0.0f);
        LeanTween.move(spike, targetPos, moveDuration).setEaseInOutSine().setOnComplete(() =>
        {
            // wait for 2 seconds and destroy spike
            StartCoroutine(DestroySpike(spike, 2.0f));
        });
    }

    IEnumerator DestroySpike(GameObject spike, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(spike);
        currentSummons--;
    }
}
