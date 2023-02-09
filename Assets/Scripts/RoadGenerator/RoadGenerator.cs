using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoadPrefabs
{
    public GameObject prefab;
    public int roadId;
    public Vector3 offset;
    public bool hasPoint;
}

public class RoadGenerator : MonoBehaviour
{
    public List<RoadPrefabs> roads = new List<RoadPrefabs>();
    [SerializeField] private int _roadLength;

    private Vector3 _prevPos;
    private RoadPrefabs _last;
    private bool _isRightCond;
    private int _helperCounter;
    private int _roadValue;

    private void Start()
    {
        for(int i = 0; i <_roadLength; i++)
        {
            BuildRoad();
            _helperCounter++;
        }
    }

    private void BuildRoad()
    {
        if(_helperCounter == 0)
        {
            _prevPos = Vector3.zero;
            GameObject firstRoad = Instantiate(roads[0].prefab, _prevPos, Quaternion.identity);
        }
        else if(_helperCounter > 0 && _helperCounter <= 1)
        {
            GameObject curRoad = Instantiate(roads[0].prefab, _prevPos + roads[0].offset, Quaternion.identity);
            _prevPos = curRoad.transform.position;
            _last = roads[0];
        }
        else if(_helperCounter > 1 && _helperCounter <= _roadLength)
        {
            int randNum;
            if(_last == roads[0])
            {
                randNum = Random.Range(2, 4);
                if(randNum == 2)
                {
                    GameObject curRoad = Instantiate(roads[2].prefab, _prevPos + roads[0].offset, Quaternion.identity);
                    _prevPos = curRoad.transform.position;
                    _last = roads[2];
                }
                else
                {
                    GameObject curRoad = Instantiate(roads[3].prefab, _prevPos + roads[0].offset, Quaternion.identity);
                    _prevPos = curRoad.transform.position;
                    _last = roads[3];
                }
            }
            else if(_last == roads[1])
            {
                if (_isRightCond)
                {
                    randNum = Random.Range(0, 2);
                    if(randNum == 0)
                    {
                        GameObject curRoad = Instantiate(roads[4].prefab, _prevPos + roads[1].offset, Quaternion.Euler(0f, 90f, 0f));
                        _prevPos = curRoad.transform.position;
                        _last = roads[4];
                    }
                    else
                    {
                        GameObject curRoad = Instantiate(roads[6].prefab, _prevPos + roads[1].offset, Quaternion.Euler(0f, 90f, 0f));
                        _prevPos = curRoad.transform.position;
                        _last = roads[6];
                    }
                }
                else
                {
                    randNum = Random.Range(0, 2);
                    if (randNum == 0)
                    {
                        GameObject curRoad = Instantiate(roads[5].prefab, _prevPos - roads[1].offset, Quaternion.Euler(0f, 90f, 0f));
                        _prevPos = curRoad.transform.position;
                        _last = roads[5];
                    }
                    else
                    {
                        GameObject curRoad = Instantiate(roads[7].prefab, _prevPos - roads[1].offset, Quaternion.Euler(0f, 90f, 0f));
                        _prevPos = curRoad.transform.position;
                        _last = roads[7];
                    }
                }               
            }
            else if (_last == roads[2])
            {
                _roadValue++;
                _isRightCond = false;
                if (_roadValue % 15 != 0)
                {
                    GameObject curRoad = Instantiate(roads[1].prefab, _prevPos + roads[2].offset - new Vector3(30f, 0f, 0f), Quaternion.identity);
                    _prevPos = curRoad.transform.position;
                    _last = roads[1];
                }
                else
                {
                    GameObject curRoad = Instantiate(roads[9].prefab, _prevPos + roads[2].offset - new Vector3(60f, 0f, 0f), Quaternion.identity);
                    _prevPos = curRoad.transform.position;
                    _last = roads[9];

                }

            }
            else if (_last == roads[3])
            {
                _roadValue++;
                _isRightCond = true;
                if (_roadValue % 15 != 0)
                {
                    GameObject curRoad = Instantiate(roads[1].prefab, _prevPos + roads[3].offset + new Vector3(30f, 0f, 0f), Quaternion.identity);
                    _prevPos = curRoad.transform.position;
                    _last = roads[1];
                }
                else
                {
                    GameObject curRoad = Instantiate(roads[9].prefab, _prevPos + roads[3].offset + new Vector3(60f, 0f, 0f), Quaternion.identity);
                    _prevPos = curRoad.transform.position;
                    _last = roads[9];

                }


            }
            else if (_last == roads[4])
            {
                _roadValue++;
                if (_roadValue % 15 != 0)
                {
                    GameObject curRoad = Instantiate(roads[0].prefab, _prevPos + roads[4].offset, Quaternion.identity);
                    _prevPos = curRoad.transform.position;
                    _last = roads[0];
                }
                else
                {
                    GameObject curRoad = Instantiate(roads[8].prefab, _prevPos + roads[4].offset, Quaternion.identity);
                    _prevPos = curRoad.transform.position;
                    _last = roads[8];

                }

            }
            else if (_last == roads[5])
            {
                _roadValue++;
                if (_roadValue % 15 != 0)
                {
                    GameObject curRoad = Instantiate(roads[0].prefab, _prevPos + roads[5].offset, Quaternion.identity);
                    _prevPos = curRoad.transform.position;
                    _last = roads[0];
                }
                else
                {
                    GameObject curRoad = Instantiate(roads[8].prefab, _prevPos + roads[5].offset, Quaternion.identity);
                    _prevPos = curRoad.transform.position;
                    _last = roads[8];

                }

            }
            else if (_last == roads[6])
            {
                _roadValue++;
                _isRightCond = false;
                if (_roadValue % 15 != 0)
                {
                    GameObject curRoad = Instantiate(roads[1].prefab, _prevPos + roads[6].offset, Quaternion.identity);
                    _prevPos = curRoad.transform.position;
                    _last = roads[1];
                }
                else
                {
                    GameObject curRoad = Instantiate(roads[9].prefab, _prevPos + roads[6].offset - new Vector3(30f, 0f, 0f), Quaternion.identity);
                    _prevPos = curRoad.transform.position;
                    _last = roads[9];

                }

            }
            else if (_last == roads[7])
            {
                _roadValue++;
                _isRightCond = true;
                if (_roadValue % 15 != 0)
                {
                    GameObject curRoad = Instantiate(roads[1].prefab, _prevPos + roads[7].offset, Quaternion.identity);
                    _prevPos = curRoad.transform.position;
                    _last = roads[1];
                }
                else
                {
                    GameObject curRoad = Instantiate(roads[9].prefab, _prevPos + roads[6].offset + new Vector3(90f, 0f, 0f), Quaternion.identity);
                    _prevPos = curRoad.transform.position;
                    _last = roads[9];

                }

            }
            else if (_last == roads[8])
            {
                randNum = Random.Range(2, 4);
                if (randNum == 2)
                {
                    GameObject curRoad = Instantiate(roads[2].prefab, _prevPos + roads[8].offset, Quaternion.identity);
                    _prevPos = curRoad.transform.position;
                    _last = roads[2];
                }
                else
                {
                    GameObject curRoad = Instantiate(roads[3].prefab, _prevPos + roads[8].offset, Quaternion.identity);
                    _prevPos = curRoad.transform.position;
                    _last = roads[3];
                }
            }
            else if (_last == roads[9])
            {
                if (_isRightCond)
                {
                    randNum = Random.Range(0, 2);
                    if (randNum == 0)
                    {
                        GameObject curRoad = Instantiate(roads[4].prefab, _prevPos + roads[9].offset, Quaternion.Euler(0f, 90f, 0f));
                        _prevPos = curRoad.transform.position;
                        _last = roads[4];
                    }
                    else
                    {
                        GameObject curRoad = Instantiate(roads[6].prefab, _prevPos + roads[9].offset, Quaternion.Euler(0f, 90f, 0f));
                        _prevPos = curRoad.transform.position;
                        _last = roads[6];
                    }
                }
                else
                {
                    randNum = Random.Range(0, 2);
                    if (randNum == 0)
                    {
                        GameObject curRoad = Instantiate(roads[5].prefab, _prevPos - roads[9].offset, Quaternion.Euler(0f, 90f, 0f));
                        _prevPos = curRoad.transform.position;
                        _last = roads[5];
                    }
                    else
                    {
                        GameObject curRoad = Instantiate(roads[7].prefab, _prevPos - roads[9].offset, Quaternion.Euler(0f, 90f, 0f));
                        _prevPos = curRoad.transform.position;
                        _last = roads[7];
                    }
                }
            }
        }
    }

}
