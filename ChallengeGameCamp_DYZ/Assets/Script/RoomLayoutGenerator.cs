using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLayoutGenerator : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject startRoom;
    public GameObject endRoom;
=======
    GameObject osef;
    public GameObject startRoom;
>>>>>>> 02cb60623ccc53fb8498f98de08e313cee594d1e
    public List<GameObject> availableRooms;
    public List<GameObject> spawnedRooms = new List<GameObject>();
    public List<GameObject> allRooms = new List<GameObject>();
    public int maxLevel = 1;
    public int curLevel = 0;
    public bool coroutineStop = true;
<<<<<<< HEAD
    public bool endPlaced = false;
=======
>>>>>>> 02cb60623ccc53fb8498f98de08e313cee594d1e

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
<<<<<<< HEAD
        if (curLevel <= maxLevel)
        {
            if(coroutineStop)
            {
                StartCoroutine(spawnAllRooms());
=======
        if (curLevel < maxLevel)
        {
            if(coroutineStop)
            {
                StartCoroutine(spawnAllRooms(null, maxLevel - 1));
>>>>>>> 02cb60623ccc53fb8498f98de08e313cee594d1e
                curLevel++;
            }
        }
    }

<<<<<<< HEAD
    IEnumerator spawnAllRooms()
=======
    IEnumerator spawnAllRooms(GameObject parentRoom, int lvl)
>>>>>>> 02cb60623ccc53fb8498f98de08e313cee594d1e
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
<<<<<<< HEAD
                    if(curLevel == maxLevel && !endPlaced)
                    {
                        spawnedRooms.AddRange(spawnRoom4Orientation(endRoom, room, linkP.transform.position));
                        yield return null;
                        spawnedRooms.RemoveAll(t => t == null);
                        endPlaced = true;
                    }
                    else
                    {
                        foreach (var aRoom in availableRooms)
                        {
                            spawnedRooms.AddRange(spawnRoom4Orientation(aRoom, room, linkP.transform.position));
                        }
                        yield return null;
                        spawnedRooms.RemoveAll(t => t == null);
                    }
=======
                    foreach (var aRoom in availableRooms)
                    {
                        spawnedRooms.AddRange(spawnRoom4Orientation(aRoom, room, linkP, lvl));
                    }
                    yield return null;
                    spawnedRooms.RemoveAll(t => t == null);
>>>>>>> 02cb60623ccc53fb8498f98de08e313cee594d1e
                    if (spawnedRooms.Count > 0)
                    {
                        int randIndex = Random.Range(0, spawnedRooms.Count);
                        spawnedRooms[randIndex].tag = "Placed";
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

<<<<<<< HEAD
    List<GameObject> spawnRoom4Orientation(GameObject room2spawn, GameObject parentRoom, Vector3 linkP)
=======
    List<GameObject> spawnRoom4Orientation(GameObject room2spawn, GameObject parentRoom,
        Vector3 linkP, int lvl)
>>>>>>> 02cb60623ccc53fb8498f98de08e313cee594d1e
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
<<<<<<< HEAD
                var link2 = room2.transform.Find("Link" + l);
                room2.transform.position = linkP - link2.position;
                Destroy(link2.gameObject);
=======
                room2.GetComponent<Room>().parent = parentRoom; 
                room2.GetComponent<Room>().level = maxLevel-lvl;
                var link2 = room2.transform.Find("Link" + l).position;
                //room2.transform.rotation = linkP.rotation;
                room2.transform.position = linkP - link2;
>>>>>>> 02cb60623ccc53fb8498f98de08e313cee594d1e
                spawnedRooms.Add(room2);
            }
        }
        return spawnedRooms;
    }

<<<<<<< HEAD
    List<Transform> getLinks(GameObject room)
    {
        List<Transform> links = new List<Transform>();
=======
    List<Vector3> getLinks(GameObject room)
    {
        List<Vector3> links = new List<Vector3>();
>>>>>>> 02cb60623ccc53fb8498f98de08e313cee594d1e
        int linkCount = room.GetComponent<Room>().linkCount;
        for (int i = 0; i < linkCount; i++)
        {
            var transform = room.transform.Find("Link" + i);
            if (transform != null)
<<<<<<< HEAD
                links.Add(transform);
=======
                links.Add(transform.position);
>>>>>>> 02cb60623ccc53fb8498f98de08e313cee594d1e
        }
        return links;
    }
}
