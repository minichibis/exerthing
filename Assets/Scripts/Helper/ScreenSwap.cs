using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwap : MonoBehaviour
{
    //begining slide
    public int whichSlide = 1;

    public GameObject Slide1;
    public GameObject Slide2;
    public GameObject Slide3;
    public GameObject Slide4;
    public GameObject Slide5;
    public GameObject Slide6;

    public void incrementSlide()
    {
        if ((whichSlide + 1) > 6)
        {
            whichSlide = 1;
        }
        else
        {
            whichSlide += 1;
        } 
    }

    public void decrementSlide()
    {
        if ((whichSlide - 1) < 1)
        {
            whichSlide = 6;
        }
        else
        {
            whichSlide -= 1;
        }
    }

    public void updateSlides()
    {
        if(whichSlide == 1)
        {
            Shutter();
            Slide1.SetActive(true);
        }
        else if (whichSlide == 2)
        {
            Shutter();
            Slide2.SetActive(true);
        }
        else if (whichSlide == 3)
        {
            Shutter();
            Slide3.SetActive(true);
        }
        else if (whichSlide == 4)
        {
            Shutter();
            Slide4.SetActive(true);
        }
        else if (whichSlide == 5)
        {
            Shutter();
            Slide5.SetActive(true);
        }
        else if (whichSlide == 6)
        {
            Shutter();
            Slide6.SetActive(true);
        }
    }

    private void Shutter()
    {
        Slide1.SetActive(false);
        Slide2.SetActive(false);
        Slide3.SetActive(false);
        Slide4.SetActive(false);
        Slide5.SetActive(false);
        Slide6.SetActive(false);
    }

    public void resetToStart()
    {
        whichSlide = 1;
        updateSlides();
    }
}
