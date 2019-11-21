using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAttack : MonoBehaviour
{
    public Slider ammoSlider; //Declares ammoSlide as a UI slider component
    public Text ammoText;  //Declares ammoText as a UI text component

    public static int currAmmo;  //Declares currAmmo as an int 
    public static int maxAmmo;  //Declares maxAmmo as an int
    public static int ammoMags;  //Declares ammoMags as an int
    public static int attackDamage;  //Declares attackDamage as an int

    public GameObject bullet;  //Declares bullet as a GameObject

    public Camera camMain;  //Declares camMain as a Camera
    private Vector3 target;  //Declares target as a Vector3

    private Vector3 diff;  //Declares diff as a Vector3
    private float rotZ;  //Declares rotZ as a float

    public Weapon equippedWeapon;  //Declares equippedWeapon as a Weapon
    public GameObject playerGun;  //Declares playerGun as a GameObject

    // Start is called before the first frame update
    void Start()
    {
        maxAmmo = equippedWeapon.ammoPerMag; //Sets the value for maxAmmo as equal to the value in the ammoPerMag variable for the current weapon equipped
        attackDamage = equippedWeapon.fireDamage; //Sets the value for attackDamage as equal to the value in the fireDamage variable for the current weapon equipped
        currAmmo = maxAmmo; //Sets the value of currAmmo as equal to maxAmmo 
        ammoMags = 10; //Sets the value for ammoMags as 10
    }

    // Update is called once per frame
    void Update()
    {
        playerGun.GetComponent<SpriteRenderer>().sprite = equippedWeapon.weaponSprite; //Changes the sprite of the gun that the player has equipped to the sprite belonging to the weapon
        ammoSlider.maxValue = maxAmmo;
        ammoSlider.value = currAmmo;

        ammoText.text = currAmmo + " / " + ammoMags; //Displays values of currAmmo and ammoMags using ammoText component


        target = camMain.ScreenToWorldPoint(Input.mousePosition);
        diff = target - transform.position;
        diff.Normalize();

        rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.Euler(0f, 0f, rotZ + 270.0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * 5.0f);

        if (Input.GetMouseButtonDown(0)) //Conditional to check if LMB has been pressed
        {
            currAmmo--; //Decrements currAmmo value

            GameObject instantiatedBullet = Instantiate(bullet, playerGun.transform.position, playerGun.transform.rotation); //Creates instance of bullet object

            instantiatedBullet.GetComponent<Rigidbody>();
            instantiatedBullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector2(0, 10)); //Gets RigidBody component from bullet Prefab and uses velocity component to propel it forward from the player

            Destroy(instantiatedBullet, 1.25f); //Destroys the bullet
        }

        if (currAmmo == 0 && ammoMags > 0) //Conditional to check if currAmmo equals 0 and ammoMags is greater than 0
        {
            Reload(); //Calls Reload function
        }

        else if(Input.GetKeyDown(KeyCode.R) && ammoMags > 0 && currAmmo < maxAmmo) //Conditional to check if R key has been pressed and ammoMags is greater than 0 and currAmmo is less than maxAmmo
        {
            Reload(); //Calls Reload function
        }

        void Reload()
        {
            currAmmo = maxAmmo; //Resets currAmmo's value
            ammoMags--; //Decrements ammoMags
        }
    }
}
