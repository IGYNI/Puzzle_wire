using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOrClose : MonoBehaviour
{
    public bool Open;
    public Vector3 First_pos;
    public bool StartPos;
    private GameObject _currentBox;
    
    public bool IsClose;//я хз как передать с одного скрипта в другой енумку

    public enum Stat
    {
        Open,
        Nothing,
        In,
        Close
    }

    public Stat _currentStat;

    void Awake() {
        _currentStat = Stat.Nothing;    
    }

    void Update()
    {
        Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition); 
        RaycastHit hitInfo;
        if (Physics.Raycast(mRay, out hitInfo) && hitInfo.transform.GetComponent<BoxInfo>())
        {
            if (Input.GetMouseButtonDown(0))
            {
                _currentStat = Stat.Open;
                _currentBox = hitInfo.transform.gameObject;

                Camera.main.GetComponent<Animation>().Play("Open");
            }
        }
        if (IsClose)
        {
            IsClose = false;
            _currentStat = Stat.Close;
        }
        if (_currentStat == Stat.Open)
        {
                hitInfo.transform.GetComponent<Collider>().enabled = false;

                Camera.main.transform.GetComponent<Change_Pos_Camera>().enabled = true;
                Camera.main.GetComponent<Move_Camera>().enabled = true;
                Camera.main.GetComponent<Move_Wire>().enabled = true;
                Camera.main.GetComponent<Add_Wire >().enabled = true;
                Camera.main.transform.position = _currentBox.transform.GetComponent<BoxInfo>().Pos;
                _currentStat = Stat.In;
        }
        else if (_currentStat == Stat.Close)
        {
            hitInfo.transform.GetComponent<Collider>().enabled = true;

                Camera.main.transform.GetComponent<Change_Pos_Camera>().enabled = false;
                Camera.main.GetComponent<Move_Camera>().enabled = false;
                Camera.main.GetComponent<Move_Wire>().enabled = false;
                Camera.main.GetComponent<Add_Wire >().enabled = false;
                Camera.main.transform.position = First_pos;
                _currentStat = Stat.Nothing;
        }
        else if (_currentStat == Stat.Nothing)
        {
            First_pos = GetComponent<Transform>().position;
        }
        

    }   
}
