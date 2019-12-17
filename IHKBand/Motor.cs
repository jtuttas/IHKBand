using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Motor
    {
        Image[] img = new Image[6];
        Image kaputt;
        int counter;
        int speed,baseSpeed;

        Boolean ok;

        int state;

    public void left(){
        if (state == 1) this.setok(false);
        else state = -1;
    }

    public void right() {
        if (state == -1) this.setok(false);
        else state = 1;
    }

    public void halt(){
        state = 0;
    }

    public void setSpeed(int s)
    {
        speed = s;
        baseSpeed = s;
    }

    public void setok(Boolean s){
        ok = s;
    }

    public Boolean isok(){
        return ok;
    }


    public Motor() {
        try
        {
            img[0] = Image.FromFile(Application.StartupPath + "\\Resources\\image1.gif");
            img[1] = Image.FromFile(Application.StartupPath + "\\Resources\\image2.gif");
            img[2] = Image.FromFile(Application.StartupPath + "\\Resources\\image3.gif");
            img[3] = Image.FromFile(Application.StartupPath + "\\Resources\\image4.gif");
            img[4] = Image.FromFile(Application.StartupPath + "\\Resources\\image5.gif");
            img[5] = Image.FromFile(Application.StartupPath + "\\Resources\\image6.gif");
            kaputt = Image.FromFile(Application.StartupPath + "\\Resources\\image0.gif");
        }
        catch (Exception e)
        {
        }
        counter = 0;
        ok = true;
        state = 0;
    }

        public Boolean isMoving()
        {
            return state != 0;
        }

    public void reset(){
        ok = true;
        state = 0;
        counter = 0;
    }

    public void move() {
        if (ok) {
            if (baseSpeed != 0)
            {
                speed--;
                if (speed < 0)
                {
                    speed = baseSpeed;
                    counter = counter + state;
                    if (counter > 5) counter = 0;
                    if (counter < 0) counter = 5;
                    Form1.form1.motorpictureBox.Image = img[counter];
                }
            }
        }
        else Form1.form1.motorpictureBox.Image = kaputt;
    }

    }
}
