using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAttack : MonoBehaviour
{
    public Slider ammoSlider;
    public Text ammoText;

    public static int currAmmo;
    public static int maxAmmo;
    public static int ammoMags;
    public static int attackDamage;

    public GameObject bullet;

    public Camera camMain;
    private Vector3 target;

    private Vector3 diff;
    private float rotZ;

    public Weapon equippedWeapon;
    public GameObject playerGun;

    // Start is called before the first frame update
    void Start()
    {
        maxAmmo = equippedWeapon.ammoPerMag;
        attackDamage = equippedWeapon.fireDamage;
        currAmmo = maxAmmo;
        ammoMags = 10;
    }

    // Update is called once per frame
    void Update()
    {
        playerGun.GetComponent<SpriteRenderer>().sprite = equippedWeapon.weaponSprite;
        ammoSlider.maxValue = maxAmmo;
        ammoSlider.value = currAmmo;

        ammoText.text = currAmmo + " / " + ammoMags;


        target = camMain.ScreenToWorldPoint(Input.mousePosition);
        diff = target - transform.position;
        diff.Normalize();

        rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.Euler(0f, 0f, rotZ + 270.0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * 5.0f);

        if (Input.GetMouseButtonDown(0))
        {
            currAmmo--;

            GameObject instantiatedBullet = Instantiate(bullet, playerGun.transform.position, playerGun.transform.rotation);

            instantiatedBullet.GetComponent<Rigidbody>();
            instantiatedBullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector2(0, 10));

            Destroy(instantiatedBullet, 1.25f);
        }

        if (currAmmo == 0 && ammoMags > 0)
        {
            Reload();
        }

        else if(Input.GetKeyDown(KeyCode.R) && ammoMags > 0 && currAmmo < maxAmmo)
        {
            Reload();
        }

        void Reload()
        {
            currAmmo = maxAmmo;
            ammoMags--;
        }
    }
}
