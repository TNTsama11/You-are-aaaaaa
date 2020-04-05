using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using LitJson;
using System;

public class Poems : MonoBehaviour
{
    private string url = "https://v1.jinrishici.com/all.json";
    public Transform containerL;
    public Transform containerR;
    public GameObject textPrefab;
    private Queue<Transform> queue;
    
    void Awake()
    {
        queue = new Queue<Transform>();
    }

    public void StartPoems()
    {
        StartCoroutine(GetRequest());
    }

    private void ShowPoems(string poems)
    {
        if (queue.Count != 0)
        {
            StartCoroutine(CleanPoems(()=> {
                StartCoroutine(AddText(poems));
            }));
        }
        else
        {
            StartCoroutine(AddText(poems));
        }
    }

    private IEnumerator AddText(string poems)
    {
        foreach (var item in poems)
        {
            GameObject go;
            if (queue.Count < 10)
            {
                go = Instantiate(textPrefab, containerL);
                queue.Enqueue(go.transform);
            }
            else
            {
                go = Instantiate(textPrefab, containerR);
                queue.Enqueue(go.transform);
            }
            go.GetComponent<Text>().text = item.ToString();
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator CleanPoems(Action action=null)
    {
        while (queue.Count > 0)
        {
            yield return new WaitForSeconds(0.03f);
            Transform temp = queue.Dequeue();
            Destroy(temp.gameObject);
        }
        if (action != null)
        {
            action();
        }
    }

    private IEnumerator GetRequest()
    {
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
                JsonData data = JsonMapper.ToObject(request.downloadHandler.text);
            //Debug.Log(data["content"].ToString());
            try
            {
                string poems = data["content"].ToString();
                ShowPoems(poems);
            }
            catch(Exception ex)
            {
                Debug.Log(ex);
            }
            }
    }
}
