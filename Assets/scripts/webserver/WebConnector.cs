using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace webserver
{
    public abstract class WebConnector
    {

        public static IEnumerator SendPostRequest(string initials,int score)
        {
            WWWForm form = new WWWForm();
            form.AddField("initials", initials);
            form.AddField("score", score);
            using (UnityWebRequest www = UnityWebRequest.Post("http://192.168.19.129:80/FifaMobile/Api/PostTest.php", form))
            {
                www.downloadHandler = new DownloadHandlerBuffer();
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ConnectionError)
                {
                    Debug.Log(www.error);
                    www.Dispose();
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                    www.Dispose();
                }
            }
        }
    }
}