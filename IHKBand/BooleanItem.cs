using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApplication1
{
    public class BooleanItem
    {
        public int byteAdr;
        public int bitAdr;
        Boolean state;
        public Boolean force_state;

        public BooleanItem(int byteA, int bitA, Boolean s)
        {
            byteAdr = byteA;
            bitAdr = bitA;
            state = s;
        }

        public BooleanItem(int byteA, int bitA)
        {
            byteAdr = byteA;
            bitAdr = bitA;
        }

        public BooleanItem(String s)
        {
            this.setAdress(s);
        }

        public void setAdress(String s)
        {
            byteAdr = Int16.Parse(s.Substring(1, s.IndexOf('.') - 1));
            bitAdr = Int16.Parse(s.Substring(s.IndexOf('.') + 1));
            Console.WriteLine("BI=" + this.ToString());
        }

        public void setState(Boolean b)
        {
            if (force_state) state = true;
            else state = b;
        }

        public void forceState(Boolean b)
        {
            force_state = b;
            state = b;
        }

        public Boolean getState()
        {
            return state;
        }

        public Boolean isItem(BooleanItem bi)
        {
            if (this.byteAdr == bi.byteAdr && this.bitAdr == bi.bitAdr)
            {
                return true;
            }
            return false;
        }

        public String ToString()
        {
            return "Boolean Item (" + byteAdr + "." + bitAdr + ")=" + state;
        }
    }
}
