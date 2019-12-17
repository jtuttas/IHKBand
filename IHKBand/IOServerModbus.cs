
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Modbus.Device;

namespace WindowsFormsApplication1
{
    class IOServerModbus : IOServer
    {

        private bool[] coil_input;
        private bool[] coil_output;
        
        ModbusIpMaster master;
        TcpClient client;
        String ipadr="127.0.0.1";
        int ipport=502;
        ushort offset;
        ushort inputLength;

        /*
         * offset bildet den coil Offset und inputLenth die Anzahl der Ausgänge
         * z.B. offset=10 und inputLength=32
         *      Es existieren 32 Eingänge und Ausgänge, der Eingang 0.0 befindet sich
         *      auf Coil Adr 10, der Ausgang 0.0 befindet sich auf Coil Adr. 42 (Offset 10
         *      und 32 Eingänge)
         */
        public IOServerModbus(String ipadr,int ipport,ushort offset,ushort inputLength)
        {
            this.ipadr = ipadr;
            this.ipport = ipport;
            this.offset = offset;
            this.inputLength = inputLength;
            coil_input = new bool[inputLength];
            coil_output = new bool[inputLength];
        }

        public override bool connect()
        {
            try
            {
                client = new TcpClient(ipadr, ipport);
                master = ModbusIpMaster.CreateIp(client);
                connected = true;
                Console.WriteLine("Connected to " + ipadr + ":" + ipport);
                
                ThreadStart del;
                del = new ThreadStart(run);
                runner = new Thread(del);
                //runner.Start();
                
                if (listener != null) listener.stateChanged("Connected");
                return true;
            }
            catch (System.Net.Sockets.SocketException e)
            {
                connected = false;
                return false;
            }
        }

        public override void disconnect()
        {
            client.Close();
            connected = false;
        }

        public  override void flush()
        {
            long start = DateTime.Now.Ticks;
            Console.Write("Flush..");

            ReadCoil();
            WriteCoil();
            long duration = DateTime.Now.Ticks - start;
            Console.WriteLine(".. finished "+(duration/10000)+" ms");
        }

        public override bool readBoolean(int byteadr, int bitadr)
        {
            //Console.WriteLine("Lese QX" + byteadr + "." + bitadr + " = " + coil_input[byteadr*8+bitadr]);
            return coil_input[byteadr*8+bitadr];
        }


        public override void setBoolean(int byteadr, int bitadr, bool state)
        {
            this.coil_output[byteadr*8+bitadr] = state;
        }

        // 1. Run the Write - Part on a Threadpool Thread ...
        private bool WriteCoil()
        {
            master.WriteMultipleCoils(offset, coil_output);

            return true;
        }
        private bool ReadCoil()
        {
            //Console.Write("Read..");
            ushort startAdr = (ushort)(offset + inputLength);
            this.coil_input= master.ReadCoils(startAdr,inputLength);
            //Console.WriteLine(".. finished");
            return true;
        }
    }
}
