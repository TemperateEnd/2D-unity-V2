using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAttack : MonoBehaviour
{
    public Weapon[] weaponList; //Array to store weapons of player
    public Slider ammoSlider; //Declares ammoSlide as a UI slider component
    public Text ammoText;  //Declares ammoText as a UI text component

    public static int ammoMags;  //Declares ammoMags as an int
    public static int attackDamage;  //Declares attackDamage as an int

    public GameObject bullet;  //Declares bullet as a GameObject
    public GameObject pellets; //Declares pellets as a GameObject

    public Camera camMain;  //Declares camMain as a Camera
    private Vector3 target;  //Declares target as a Vector3

    private Vector3 diff;  //Declares diff as a Vector3
    private float rotZ;  //Declares rotZ as a float

    Weapon equippedWeapon;  //Declares equippedWeapon as a Weapon
    public GameObject playerGun;  //Declares playerGun as a GameObject

    int weaponListIndex; //Int to store position in weaponList

    // Start is called before the first frame update
    void Start()
    {
        weaponListIndex = 0;
        equippedWeapon = weaponList[weaponListIndex];
        
        ammoMags = 10; //Sets the value for ammoMags as 10
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (weaponListIndex > 0)
            {
                weaponListIndex--;
            }

            else if (weaponListIndex == 0)
            {
                weaponListIndex += 3;
            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (weaponListIndex < 3)
            {
                weaponListIndex++;
            }

            else if (weaponListIndex == 3)
            {
                weaponListIndex -= 3;
            }
        }

        equippedWeapon = weaponList[weaponListIndex]; //Equipped weapon changes depending where in the weaponList array they currently are
        attackDamage = (equippedWeapon.fireDamage + (1 * playerLevel.playerLvl)); //Sets the value for attackDamage as equal to the value in the fireDamage variable for the current weapon equipped + 1 for each time the player levels up
        playerGun.GetComponent<SpriteRenderer>().sprite = equippedWeapon.weaponSprite; //Changes the sprite of the gun that the player has equipped to the sprite belonging to the weapon
        ammoSlider.maxValue = equippedWeapon.ammoPerMag; //Takes the ammoPerMag value for the weapon equipped and sets it as the max value for the ammoSlider
        ammoSlider.value = equippedWeapon.currentAmmo; //Takes the currentAmmo value for the weapon equipped and sets it as the current value for the ammoSlider

        ammoText.text = equippedWeapon.currentAmmo + " / " + ammoMags; //Displays values of currAmmo and ammoMags using ammoText component


        target = camMain.ScreenToWorldPoint(Input.mousePosition);
        diff = target - transform.position;
        diff.Normalize();

        rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.Euler(0f, 0f, rotZ + 270.0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * 5.0f);

        if (Input.GetMouseButtonDown(0) && equippedWeapon.currentAmmo > 0) //Conditional to check if LMB has been pressed
        {
            playerGun.GetComponent<AudioSource>().clip = equippedWeapon.firingAudio;
            playerGun.GetComponent<AudioSource>().Play();
            if(equippedWeapon.wType == Weapon.WeaponType.Shotgun)
            {
                equippedWeapon.currentAmmo -= 7; //Subtracts 7 from the currentAmmo value

                GameObject instantiatedPellets = Instantiate(pellets, playerGun.transform.position, playerGun.transform.rotation);

                instantiatedPellets.GetComponent<Rigidbody>();
                instantiatedPellets.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector2(0, 20));

                Destroy(instantiatedPellets, 0.25f);
            }

            else
            {
                equippedWeapon.currentAmmo--; //Decrements currAmmo value

                GameObject instantiatedBullet = Instantiate(bullet, playerGun.transform.position, playerGun.transform.rotation); //Creates instance of bullet object

                instantiatedBullet.GetComponent<Rigidbody>();
                instantiatedBullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector2(0, 50)); //Gets RigidBody component from bullet Prefab and uses velocity component to propel it forward from the player

                Destroy(instantiatedBullet, 1.25f); //Destroys the bullet
            }
        }

        if(Input.GetKeyDown(KeyCode.R) && ammoMags > 0 && equippedWeapon.currentAmmo == 0) //Conditional to check if R key has been pressed and ammoMags is greater than 0 and currAmmo is equal to 0
        {
            Reload(); //Calls Reload function
        }

        void Reload()
        {
            equippedWeapon.currentAmmo =  equippedWeapon.ammoPerMag; //Resets currAmmo's value
            ammoMags--; //Decrements ammoMags
        }
    }
}