using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    GameObject Prefab;
    public int Size { get; private set; }
    Queue<GameObject> Pool = new Queue<GameObject>();
    Transform Trans_Parent;

    public void InitPool(int _size, GameObject _obj,Transform _parent)
    {
        Size = _size;
        Prefab = _obj;
        Trans_Parent = _parent;
        Pool = new Queue<GameObject>();

        for (int i = 0; i < Size; i++)
        {
            GameObject go = Instantiate(Prefab, Vector3.zero, Quaternion.identity) as GameObject;
            go.transform.SetParent(Trans_Parent);
            go.transform.localScale = Vector3.one;
            go.SetActive(false);
            Pool.Enqueue(go);
        }
    }
    public GameObject GetOjb()
    {
        if (Pool.Count > 0)
        {
            GameObject go = Pool.Dequeue();
            go.SetActive(true);
            return go;
        }
        else
        {
            GameObject go = Instantiate(Prefab, Vector3.zero, Quaternion.identity) as GameObject;
            go.transform.SetParent(Trans_Parent);
            go.transform.localScale = Vector3.one;
            return go;
        }

    }
    public void GiveBack(GameObject _go)
    {
        _go.SetActive(false);
        Pool.Enqueue(_go);
    }
}
