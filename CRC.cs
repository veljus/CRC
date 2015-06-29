using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRC
{
    class Program
    {
        public class crc 
        {
            public int int_crc_byte_a, int_crc_byte_b;
            int [] int_array = new int[100];
            public void crc_bytes(int[] int_input) 
            {
                int_array = int_input;
                int int_crc = 0xFFFF;
                int int_lsb;
                for (int int_i = 0; int_i < int_array.Length; int_i++)
                {
                    int_crc = int_crc ^ int_array[int_i];
                    for (int int_j = 0; int_j < 8; int_j ++ )
                    {
                        int_lsb = int_crc & 0x0001;  // Mask of LSB
                        int_crc = int_crc >> 1;
                        int_crc = int_crc & 0x7FFF;
                        if (int_lsb == 1) int_crc = int_crc ^ 0xA001;
                    }
                }

                int_crc_byte_a = int_crc & 0x00FF;
                int_crc_byte_b = (int_crc >> 8) & 0x00FF;
            }
            
        }
        static void Main(string[] args)
        {
            int[] int_input = new int[6];
            int_input[0] = 0x0001;
            int_input[1] = 0x0003;
            int_input[2] = 0x001D;
            int_input[3] = 0x0063;
            int_input[4] = 0x0000;
            int_input[5] = 0x0002;




            crc crc_calculate = new crc();
            crc_calculate.crc_bytes(int_input);
            Console.WriteLine("a:" + crc_calculate.int_crc_byte_a + " b:" + crc_calculate.int_crc_byte_b );
            Console.ReadKey();


        }
    }
}
