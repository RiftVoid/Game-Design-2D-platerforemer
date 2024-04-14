using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //mouse inputs (x,y,click)
    //need to take into account of charter direction 
    //need contact info ( can outsouce it to the emeny)
    //if want to turn into a combat moduel need state change

    enum WeaponState
    {
        Sword,
        Bow,

    }

    enum ArrowDirection
    {
        left,
        right,
    }

    [SerializeField] private WeaponState state;
    [SerializeField] private ArrowDirection arrowDirection;
    [SerializeField] private GameObject sword;
    [SerializeField] private GameObject actualSword;
    [SerializeField] private GameObject bow;
    [SerializeField] private GameObject arrowPrefab;

    [SerializeField] private float swordSpeed;
    [SerializeField] private float swordTime;
    [SerializeField] private float swordTimer;
    [SerializeField] private bool swordStabing;

    [SerializeField] private bool bowDelay;
    [SerializeField] private float arrowSpeed;


    private GameObject currentArrow;

    private Vector2 vectorSword;
    private Vector3 swordStabDirection;

    // Start is called before the first frame update
    void Start()
    {
        state = WeaponState.Sword;


        //HOW to arrow
        //currentArrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        //Sets sword or bow active
        if (state == WeaponState.Sword)
        {
            actualSword.SetActive(true);
            bow.SetActive(false);

        }
        else if (state == WeaponState.Bow)
        {
            actualSword.SetActive(false) ;
            bow.SetActive(true) ;
        }


        //changes weaponstate
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(state == WeaponState.Sword)
            {
                state = WeaponState.Bow;
            }
            else if (state == WeaponState.Bow)
            {
                state = WeaponState.Sword;
            }
        }


        Vector3 position = Input.mousePosition;
        position.z = 5;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(position);

        //sword.transform.position = worldPos;    

        //Debug.Log(Input.mousePosition);

        vectorSword = (Vector2)transform.position - worldPos;
        
        if (state == WeaponState.Sword)
        {

            sword.transform.right = - vectorSword;
            //sword.transform.rotation = Quaternion.LookRotation(vectorSword);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(state == WeaponState.Sword && swordStabing == false)
            {
                //actualSword.transform.right = actualSword.transform.right + (swordSpeed * Time.deltaTime); 
                swordStabing = true;   
                
              
            }
            else if (state == WeaponState.Bow && bowDelay == false)
            {

                currentArrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
                bowDelay = true;
            }
        }
        //Debug.Log(sword.transform.right*Vector2.right);
        if ((sword.transform.right * Vector2.right).x <= 0)
        {
            
            //Debug.Log("is facing left");
            
            arrowDirection = ArrowDirection.left;
        }
        else
        {
            //Debug.Log("is facing right");
           
            arrowDirection = ArrowDirection.right;
        }
        swordStabDirection = vectorSword.normalized;
        if (swordStabing == true)
        {
            float stabSpeed = swordSpeed * Time.deltaTime;
            swordTimer += Time.deltaTime;
            if (swordTimer < swordTime / 2)
            {
                actualSword.transform.position -= swordStabDirection * stabSpeed;
            }
            else if (swordTimer > swordTime)
            {
                swordStabing = false;
                swordTimer = 0;
                actualSword.transform.localPosition = Vector3.right;
            }
            else
            {
                actualSword.transform.position += swordStabDirection * stabSpeed;

            }
        }

        if (arrowDirection == ArrowDirection.right && currentArrow != null)
        {
            currentArrow.transform.position += arrowSpeed * Vector3.right * Time.deltaTime;
        }
        else if (arrowDirection == ArrowDirection.left && currentArrow != null)
        {
            currentArrow.transform.position += arrowSpeed * Vector3.left * Time.deltaTime;
        }


        if (currentArrow == null) 
        {

            bowDelay = false;
        }
    }

}
