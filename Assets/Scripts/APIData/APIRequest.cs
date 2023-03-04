using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class APIRequest : MonoBehaviour
{
    public static UnityAction<UnityWebRequest> OnRequestCompleteCallback;

    public static IEnumerator IWebRequest(string url, UnityAction<UnityWebRequest> callback, Dictionary<string, string> _headers){
        OnRequestCompleteCallback = callback;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url)){
            foreach (var _key in _headers.Keys){
                webRequest.SetRequestHeader(_key, _headers[_key]);
            }
            yield return webRequest.SendWebRequest();
            OnRequestCompleteCallback?.Invoke(webRequest);
        }
    }
}
