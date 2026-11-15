using UnityEngine;

public class DeliveryMission : MonoBehaviour
{
    public Transform car, pickup, dropoff;
    public int coins;
    bool carrying;

    void Update()
    {
        if (car == null || pickup == null || dropoff == null) return;
        if (!carrying && Vector3.Distance(car.position,pickup.position) < 7)
        {
            carrying = true;
            pickup.gameObject.SetActive(false);
        }
        if (carrying && Vector3.Distance(car.position,dropoff.position) < 7)
        {
            coins += 100;
            carrying = false;
            pickup.position = new Vector3(Random.Range(-75,75),Random.Range(7,25),Random.Range(-75,75));
            dropoff.position = new Vector3(Random.Range(-75,75),Random.Range(7,25),Random.Range(-75,75));
            pickup.gameObject.SetActive(true);
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(15,15,Mathf.Min(350,Screen.width*.55f),90),
            "AERODASH V02  |  Coins: "+coins+"\n"+
            (carrying?"Deliver to GREEN marker":"Collect from YELLOW marker")+
            "\nWASD: fly  SPACE/SHIFT: altitude");
    }
}
