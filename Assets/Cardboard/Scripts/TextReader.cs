using UnityEngine;
using System.Collections;
using System.Net;
using System.Text;
using System.Collections.Generic;




public class TextReader : MonoBehaviour {
    public GameObject[] planes;
    Texture2D imagetexture;
    List<string> urls = new List<string>();
    List<Texture2D> textures = new List<Texture2D>();
    int timer = 0;
    // Use this for initialization
    void Start() {
        WebClient client = new WebClient();
        //client.Encoding = Encoding.UTF8;       
        string json = client.DownloadString("http://www.reddit.com/r/wallpapers/top/.json?limit=40");

        while (json.IndexOf("url\":") != -1) {
            json = json.Substring(json.IndexOf("url\": \"") + 7);
            string url = json.Substring(0, json.IndexOf("\""));
            if (url.IndexOf("imgur") != -1 && url.IndexOf(".jpg") != -1 && url.EndsWith("jpg"))
            {
                url = url.Trim();
                urls.Add(url);
            }
        }
        
        for (var i = 0; i < urls.Count; i++) {
            string tempurl = urls[i];
            Debug.Log(tempurl);
            StartCoroutine(LoadImg(tempurl));
        }

      
    }

    IEnumerator LoadImg(string x)
    {
        yield return 0;
        WWW imgLink = new WWW(x);
        yield return imgLink;
        textures.Add(imgLink.texture);
        Debug.Log("texture added");
    }
    // Update is called once per frame
    void Update () {
        if(timer < 100)
        {
            timer++;
        }
        else
        {
            Debug.Log(textures.Count);
            for(int i = 0; i < 6; i++)
            {
                planes[i].GetComponent<Renderer>().material.mainTexture = textures[i];
            }
        }
	}


}
