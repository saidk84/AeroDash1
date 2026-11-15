using UnityEngine;

public class AeroDashBootstrap : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void StartGame()
    {
        if (Object.FindFirstObjectByType<AeroDashBootstrap>() != null) return;
        new GameObject("AeroDash V02 Bootstrap").AddComponent<AeroDashBootstrap>();
    }

    void Start()
    {
        RenderSettings.ambientLight = new Color(.7f, .75f, .85f);
        var sun = new GameObject("Sun").AddComponent<Light>();
        sun.type = LightType.Directional;
        sun.intensity = 1.2f;
        sun.transform.rotation = Quaternion.Euler(50, -35, 0);

        var ground = MakeCube("Desert ground", new Vector3(0,-1,0), new Vector3(260,2,260), new Color(.73f,.66f,.52f));
        for (int x = -5; x <= 5; x++)
        for (int z = -5; z <= 5; z++)
        {
            if (Mathf.Abs(x) < 2 && Mathf.Abs(z) < 2) continue;
            float height = 8 + Mathf.Abs((x * 17 + z * 31) % 37);
            MakeCube("Dubai-inspired tower", new Vector3(x*19,height/2,z*19),new Vector3(9,height,9),new Color(.22f,.38f,.5f));
        }

        var car = new GameObject("Flying Car");
        car.transform.position = new Vector3(0,7,0);
        MakeCube("Body",Vector3.zero,new Vector3(2.3f,.6f,4.2f),new Color(.05f,.7f,.95f),car.transform);
        MakeCube("Cabin",new Vector3(0,.55f,-.25f),new Vector3(1.6f,.65f,1.8f),new Color(.1f,.18f,.3f),car.transform);
        MakeCube("Left wing",new Vector3(-1.6f,0,0),new Vector3(1.4f,.15f,1.2f),Color.gray,car.transform);
        MakeCube("Right wing",new Vector3(1.6f,0,0),new Vector3(1.4f,.15f,1.2f),Color.gray,car.transform);
        car.AddComponent<FlyingCarController>();

        var camera = Camera.main;
        if (camera == null)
        {
            var go = new GameObject("Main Camera");
            go.tag = "MainCamera";
            camera = go.AddComponent<Camera>();
            go.AddComponent<AudioListener>();
        }
        camera.clearFlags = CameraClearFlags.Skybox;
        var follow = camera.gameObject.AddComponent<FollowFlyingCar>();
        follow.target = car.transform;

        var mission = new GameObject("Delivery Mission").AddComponent<DeliveryMission>();
        mission.car = car.transform;
        mission.pickup = MakeMarker("Pickup",new Vector3(38,9,38),Color.yellow);
        mission.dropoff = MakeMarker("Dropoff",new Vector3(-45,12,40),Color.green);
    }

    static GameObject MakeCube(string name,Vector3 pos,Vector3 scale,Color color,Transform parent=null)
    {
        var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.name = name;
        if (parent != null) obj.transform.SetParent(parent,false);
        obj.transform.localPosition = pos;
        obj.transform.localScale = scale;
        var material = new Material(Shader.Find("Standard"));
        material.color = color;
        obj.GetComponent<Renderer>().material = material;
        return obj;
    }

    static Transform MakeMarker(string name,Vector3 pos,Color color)
    {
        var obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        obj.name = name;
        obj.transform.position = pos;
        obj.transform.localScale = Vector3.one * 4;
        var material = new Material(Shader.Find("Standard"));
        material.color = color;
        obj.GetComponent<Renderer>().material = material;
        return obj.transform;
    }
}
