using UnityEngine;
using Cinemachine;
public class SwitchCamera : MonoBehaviour
{
    [SerializeField]private CinemachineVirtualCamera VCam1;
    [SerializeField]private CinemachineVirtualCamera VCam2;
    [SerializeField]private CinemachineVirtualCamera VCam3;
    [SerializeField]private CinemachineVirtualCamera VCam4;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "BackCam")
        {
            VCam1.Priority = 3;
            VCam2.Priority = 2;
            VCam3.Priority = 1;
            VCam4.Priority = 0;
        }
        else if(other.GetComponent<Collider>().tag == "RightCam")
        {
            VCam2.Priority = 3;
            VCam1.Priority = 2;
            VCam3.Priority = 1;
            VCam4.Priority = 0;
        }
        else if(other.GetComponent<Collider>().tag == "LeftCam")
        {
            VCam3.Priority = 3;
            VCam2.Priority = 2;
            VCam1.Priority = 1;
            VCam4.Priority = 0;
        }
        else if(other.GetComponent<Collider>().tag == "FrontCam")
        {
            VCam4.Priority = 3;
            VCam3.Priority = 2;
            VCam2.Priority = 1;
            VCam1.Priority = 0;
        }
        
    }
}
