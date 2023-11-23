using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;
    public Vector3 offset;
    PlayerController player;
    public bool isDead;

    //[SerializeField] ParticleSystem confeiti;
    //[SerializeField] GameObject unlockText;
    //[SerializeField] GameObject indicatedArrow;
    bool isAnim = false;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        //unlockText.SetActive(false);
    }

    void Start()
    {
        
    }
    void LateUpdate()
    {

        if (!isAnim)
        {
            if (player)
            {
                Vector3 desiredPos = new Vector3(player.transform.position.x, 0, player.transform.position.z) + offset;
                transform.position = desiredPos;
            }
            else
            {
                player = FindObjectOfType<PlayerController>();
            } 
        }
    }


    //public void CafeAnimation()
    //{
    //    //confeiti.Play();
    //    StartCoroutine(Unlocking());
    //}

    //IEnumerator Unlocking()
    //{
    //    yield return new WaitForSeconds(1f);
    //    unlockText.SetActive(true);
    //    yield return new WaitForSeconds(4f);
    //    unlockText.SetActive(false);
    //}

    public void PlaceholderAnim()
    {
        isAnim = true;
        ETCJoystick joystick = FindObjectOfType<ETCJoystick>();
        joystick.enabled = false;
        Vector3 curPos = transform.position;
        //indicatedArrow.SetActive(true);
        //transform.DOMove(new Vector3(5.5f, 0f, 18.65f) + offset, 1.5f).SetDelay(0.5f).OnComplete(() => 
        transform.DOMove(new Vector3(7f, 0f, 7.5f) + offset, 1.5f).SetDelay(0.5f).OnComplete(() => 
        {
            transform.DOMove(curPos, 1.5f).SetDelay(2f).OnComplete(() =>
            {
                isAnim = false;
                joystick.enabled = true;
                PlayerPrefs.SetInt("TutStep3", 1);
                //indicatedArrow.SetActive(false);
            });
        });
    }
}
