using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowRecompense : MonoBehaviour {

    public Image imageSource;
    public Text textImage;
    void Start()
    {

    }

    public void Show(int nbOfUpgrade)
    {
        switch (nbOfUpgrade)
        {
            case 1 :
                ChangeImage("GeraniumN");
                textImage.text = "Don't forget to water it !";
                break;
            case 2:
                ChangeImage("BougieRoseN"); 
                textImage.text = "You love that color !";
                break;
            case 3:
                ChangeImage("DuckyN");
                textImage.text = "He's your best friend";
                break;
            case 4: // A revoir
                ChangeImage("DuckyN");
                textImage.text = "It's so fluffy !";
                break;
            case 5:
                ChangeImage("FlowerPot");
                textImage.text = "Those flower are dope.";
                break;
            case 6:
                ChangeImage("Cat");
                textImage.text = "He know how to rock that house";
                break;
            case 7:
                ChangeImage("Plunger");
                textImage.text = "That's a must have.";
                break;
            case 8:
                ChangeImage("BougieBleuN");
                textImage.text = "It's smells like sexy";
                break;
            case 9:
                ChangeImage("TulipeN");
                textImage.text = "Nice";
                break;
            case 10:
                ChangeImage("Lampion");
                textImage.text = "So spherical, it's crazy";
                break;
        }
    }

    public void ChangeImage(string newImageTitle)
    {
        imageSource.sprite = Resources.Load<Sprite>("Recompenses/"+newImageTitle);
    }
}
