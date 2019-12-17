using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApplication1
{
    public interface PlcListener
    {
        void stateChanged(String state);

        void outputChanged(BooleanItem bi);

        void inputChanged(BooleanItem bi);

        void lostConnection(String s);
    }
}
