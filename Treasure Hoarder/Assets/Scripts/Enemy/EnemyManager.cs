using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime;

public class EnemyManager : MonoBehaviour
{
    public GameObject skeleton;
    public GameObject barrel;
    public GameObject thief;
    public GameObject bringer;
    public GameObject parent;
    public Camera localCamera;
    public Text timer;

    private GameObject clone;
    Vector3 position;
    float times;
    int minutes;
    float seconds;
    float milliseconds;
    bool height;
    bool width;
    int count;
    bool spawning;

    void Start()
    {
        times = 0;
        minutes = 0;
        seconds = 0f;
        milliseconds = 0f;
        count = 0;
        spawning = false;
        position = localCamera.ScreenToWorldPoint((new Vector3(Random.Range(0, localCamera.scaledPixelWidth), localCamera.scaledPixelHeight, 0)));
        StartCoroutine(spawn());
    }

    void Update()
    {
        times += Time.deltaTime;
        milliseconds = findMilliSeconds(Mathf.Round(times * 100) / 100);
        if (times <= 60f)
            seconds = findSeconds(Mathf.Round(times * 100) / 100);
        else
        {
            seconds = findSeconds(Mathf.Round(((times * 100) - (minutes * 60 * 100))) / 100);
        }
            
        minutes = (int)times / 60;

        if (milliseconds < 10)
        {
            if (seconds < 10)
                timer.text = string.Concat("Time: ", minutes, ":0", seconds, ":0", milliseconds);
            else
                timer.text = string.Concat("Time: ", minutes, ":", seconds, ":0", milliseconds);
        }
        else
        {
            if (seconds < 10)
                timer.text = string.Concat("Time: ", minutes, ":0", seconds, ":", milliseconds);
            else
                timer.text = string.Concat("Time: ", minutes, ":", seconds, ":", milliseconds);
        }

        height = randomBool();
        width = randomBool();

        //South
        if(height && width)
            position = localCamera.ScreenToWorldPoint((new Vector3(Random.Range(0, localCamera.scaledPixelWidth), 0, 100)));
        //West
        else if(height && !width)
            position = localCamera.ScreenToWorldPoint((new Vector3(0, Random.Range(0, localCamera.scaledPixelHeight), 100)));
        //East
        else if(!height && width)
            position = localCamera.ScreenToWorldPoint((new Vector3(localCamera.scaledPixelWidth, Random.Range(0, localCamera.scaledPixelHeight), 100)));
        //North
        else if(!height && !width)
            position = localCamera.ScreenToWorldPoint((new Vector3(Random.Range(0, localCamera.scaledPixelWidth), localCamera.scaledPixelHeight, 100)));

        if (seconds % 30 == 0 && !spawning && seconds != 0)
        {
            //Debug.LogError(seconds);
            spawning = true;
            StartCoroutine(spawn());
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Debug.Log(position);
            Instantiate(skeleton, position, Quaternion.identity, parent.transform);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Debug.Log(position);
            Instantiate(barrel, position, Quaternion.identity, parent.transform);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Debug.Log(position);
            Instantiate(thief, position, Quaternion.identity, parent.transform);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //Debug.Log(position);
            Instantiate(bringer, position, Quaternion.identity, parent.transform);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //Debug.Log(position);
            times += 10f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            //Debug.Log(position);
            times += 60f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            //Debug.Log(position);
            times += 835f;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
            foreach (GameObject item in items)
            {
                Debug.LogError("Item Destroyed");
                Destroy(item);
            }
        }

    }

    private float findSeconds(float time)
    {
        string temp1 = time.ToString();
        if (time >= 10)
            return float.Parse(string.Concat(temp1[0], temp1[1]));
        else
            return float.Parse(string.Concat(temp1[0]));
    }

    private float findMilliSeconds(float second)
    {
        string temp1, temp2;
        temp1 = second.ToString();
        if(second >= 100f)
        {
            temp2 = string.Concat(temp1[4], temp1[5]);
            return float.Parse(temp2);
        }
        else if(second >= 10f)
        {
            temp2 = string.Concat(temp1[3], temp1[4]);
            return float.Parse(temp2);
        }
        else
        {
            temp2 = string.Concat(temp1[2], temp1[3]);
            return float.Parse(temp2);
        }
    }

    private bool randomBool()
    {
        if(Random.value >= 0.5)
        {
            return true;
        }
        return false;
    }

    IEnumerator spawn()
    {
        count = 20;
        for (int i = 0; i < count; i++)
        {
            if(minutes == 15)
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    Destroy(enemy);
                }
                yield return new WaitForSeconds(0.1f);
                GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
                foreach (GameObject item in items)
                {
                    Debug.LogError("Item Destroyed");
                    Destroy(item);
                }
                Instantiate(bringer, position, Quaternion.identity, parent.transform);
                
                count = 0;
            }
            else if (minutes >= 10)
            {
                Instantiate(thief, position, Quaternion.identity, parent.transform);
                yield return new WaitForSeconds(1);
            }
            else if (minutes >= 5)
            {
                Instantiate(barrel, position, Quaternion.identity, parent.transform);
                yield return new WaitForSeconds(1);
            }
            else
            {
                Instantiate(skeleton, position, Quaternion.identity, parent.transform);
                yield return new WaitForSeconds(1);
            }
        }

        spawning = false;
    }
}
