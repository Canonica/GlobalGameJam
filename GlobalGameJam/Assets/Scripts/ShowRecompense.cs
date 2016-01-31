using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowRecompense : MonoBehaviour {

    public Image imageSource;
    public Text textImage;
    public Text textNom;
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
                textNom.text = "Geranium";
                break;
            case 2:
                ChangeImage("BougieRoseN"); 
                textImage.text = "You love that color !";
                textNom.text = "Pink Candle";
                break;
            case 3:
                ChangeImage("DuckyN");
                textImage.text = "He's your best friend";
                textNom.text = "The Ducky";
                break;
            case 4:
                ChangeImage("FlowerPot");
                textImage.text = "Those flower are dope.";
                textNom.text = "Flower Pot";
                break;
            case 5:
                ChangeImage("Cat");
                textImage.text = "He know how to rock that house";
                textNom.text = "Cat";
                break;
            case 6:
                ChangeImage("Plunger");
                textImage.text = "That's a must have.";
                textNom.text = "Plunger";
                break;
            case 7:
                ChangeImage("BougieBleuN");
                textImage.text = "It's smells like sexy";
                textNom.text = "Blue Candle";
                break;
            case 8:
                ChangeImage("TulipeN");
                textImage.text = "Nice";
                textNom.text = "Tulipe";
                break;
            case 9:
                ChangeImage("Lampion");
                textImage.text = "So spherical, it's crazy";
                textNom.text = "Lantern";
                break;
            case 10:
                ChangeImage("Portrait");
                textImage.text = "This is you !";
                textNom.text = "Portrait";
                break;

            case 11:
                ChangeImage("Sofa");
                textImage.text = "It's so comfortable";
                textNom.text = "Sofa";
                break;

            case 12:
                ChangeImage("Rideaux");
                textImage.text = "Those are nice !";
                textNom.text = "Curtains";
                break;

        }
    }

    public void ChangeImage(string newImageTitle)
    {
        imageSource.sprite = Resources.Load<Sprite>("Recompenses/"+newImageTitle);
    }
}
