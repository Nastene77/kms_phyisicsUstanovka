using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewScroll : MonoBehaviour
{
    [SerializeField]
    Transform targetPos;//������� �������
    [SerializeField]
    int sensivity = 3;//���������������� ��� �������� � ��������
    [SerializeField]
    float scrollSpeed = 1f;//�������� ��������� ������ ���� ��� ��������� �����������.
    [SerializeField]
    int maxdistance = 20;// ������������ ���������� �� ����.
    [SerializeField]
    int mindistance = 1;// ���������� ���������� �� ����.


    void Update()
    {//�������� ������ ����������� ����� ��������� � ������� ������ ������� ����
        if (Input.GetMouseButton(1))
        {
            float yy = Input.GetAxis("Mouse X") * sensivity;  //�������� ��������������� �������� ����
            Debug.Log(transform.rotation.y);                    //y ���� �������� ������� transform � ������� �������
            if (yy != 0)
            {
                transform.RotateAround(targetPos.position, Vector3.up, yy); //�������� �������, �������� yy
            }

        }
                                                                    //�������������� � ������������ �������� ������
        float x = Input.GetAxis("Horizontal") / sensivity;
        float y = Input.GetAxis("Vertical") / sensivity;            // ������� A, D
        if (x != 0)
        {
            Vector3 newpos = transform.position + transform.TransformDirection(new Vector3(x, 0, 0));  //�� ��������� ��������� � ����������, ����� ������ �������� � ���������� �����������.

            if (ControlDistance(Vector3.Distance(newpos, targetPos.position))) //��������� ���������� �����,�������� �� ���������� ����� ��������� ����������
                transform.position = newpos;
        }

        if (y != 0)
        {
            Vector3 newpos = transform.position + transform.TransformDirection(new Vector3(0, y, 0));

            if (ControlDistance(Vector3.Distance(newpos, targetPos.position))) 
                transform.position = newpos;
        }
                                                                // ����������� � �������� ������ � ��������� �� ����� ���������� ������ ����
        float z = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed; //��������� �������� ��������� ������ ����
        if (z != 0)
        {
            Vector3 newpos = transform.position + transform.TransformDirection(Vector3.forward * z);
            if (ControlDistance(Vector3.Distance(newpos, targetPos.position))) 
                transform.position = newpos;
        }


    }
                                                            //   ����������� �������� �������� ������ �� ���������
    private bool ControlDistance(float distance)
    {
        if (distance > mindistance && distance < maxdistance) return true;
        return false;
    }


}
