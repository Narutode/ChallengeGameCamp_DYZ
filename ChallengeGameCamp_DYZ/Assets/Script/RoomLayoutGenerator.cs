using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLayoutGenerator : MonoBehaviour
{
    public GameObject startRoom;
    public GameObject endRoom;
    public List<GameObject> availableRooms;
    public List<GameObject> spawnedRooms = new List<GameObject>();
    public List<GameObject> allRooms = new List<GameObject>();
    public int maxLevel = 1;
    public int curLevel = 0;
    public bool coroutineStop = true;
    public bool endPlaced = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject room1 = Instantiate(startRoom);
        room1.transform.position = new Vector3(0, 0, 0);
        var link1 = room1.transform.Find("Link0").position;
        allRooms.Add(room1);
        room1.tag = "Placed";
    }

    // Update is called once per frame
    void Update()
    {
        if (curLevel < maxLevel)
        {
            if(coroutineStop)
            {
                curLevel++;
                StartCoroutine(spawnAllRooms());
            }
        }
    }

    IEnumerator spawnAllRooms()
    {
        coroutineStop = false;
        List<GameObject> spawnedRooms = new List<GameObject>();
        allRooms.RemoveAll(t => t == null);
        foreach (var room in allRooms)
        {
            if (room != null)
            {
                var linksParent = getLinks(room);
                foreach (var linkP in linksParent)
                {
                    List<GameObject> currentSpawnedRooms = new List<GameObject>();

                    if (room != null)
                    {
                        if (curLevel == maxLevel && !endPlaced)
                        {
                            currentSpawnedRooms.AddRange(spawnRoom4Orientation(endRoom, room, linkP.position));
                            yield return null;
                            currentSpawnedRooms.RemoveAll(t => t == null);
                        }
                        else
                        {
                            foreach (var aRoom in availableRooms)
                            {
                                currentSpawnedRooms.AddRange(spawnRoom4Orientation(aRoom, room, linkP.position));
                            }
                            yield return null;
                            currentSpawnedRooms.RemoveAll(t => t == null);
                        }
                        if (currentSpawnedRooms.Count > 0)
                        {
                            int randIndex = Random.Range(0, currentSpawnedRooms.Count);
                            currentSpawnedRooms[randIndex].tag = "Placed";
                            if(linkP != null && linkP.childCount > 0) {
                                var door = linkP.GetChild(0);            
                                if (door != null)
                                    door.GetComponent<Door>().canOpen = true;
                            }
                            spawnedRooms.AddRange(currentSpawnedRooms);
                        }
                    }
                }
            }
        }
        spawnedRooms.RemoveAll(t => t == null);
        allRooms.Clear();
        allRooms = spawnedRooms;
        coroutineStop = true;

        yield return null;
    }

    List<GameObject> spawnRoom4Orientation(GameObject room2spawn, GameObject parentRoom, Vector3 linkP)
    {
        List<GameObject> spawnedRooms = new List<GameObject>();
        int nbLinkRoom = room2spawn.GetComponent<Room>().linkCount;
        for (int i = 0; i < 4; i++)
        {
            for(int l = 0; l < nbLinkRoom; l++)
            {
                GameObject room2 = Instantiate(room2spawn);
                room2.transform.position = Vector3.zero;
                room2.transform.Rotate(new Vector3(0, i * 90, 0));
                var link2 = room2.transform.Find("Link" + l);
                room2.transform.position = linkP - link2.position;
                Destroy(link2.gameObject);
                spawnedRooms.Add(room2);
            }
        }
        return spawnedRooms;
    }

    List<Transform> getLinks(GameObject room)
    {
        List<Transform> links = new List<Transform>();
        int linkCount = room.GetComponent<Room>().linkCount;
        for (int i = 0; i < linkCount; i++)
        {
            var transform = room.transform.Find("Link" + i);
            if (transform != null)
                links.Add(transform);
        }
        return links;
    }
}
