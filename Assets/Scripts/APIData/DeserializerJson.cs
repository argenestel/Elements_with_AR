using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

using Chemistry;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

public class DeserializerJson : MonoBehaviour{
    public static UnityAction<string> onDeserialize;
}