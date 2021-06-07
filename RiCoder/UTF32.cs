using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiCoder
{
    public static class UTF32
    {

        public static string Utf32_abc = "abcdefghijklmnopqrstuvwxyz";
        public static string Utf32_ABC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string Utf32_012 = "0123456789";   
        public static string Utf32_SYMV = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

        public static int CharTointUtf32S_isnumber(char c)
        {
            int cc = 0;
            for (int i = 0; i < Utf32_012.Length; i++)
            {
                if (Utf32_012[i] == c)
                {
                    cc = i;
                    break;
                }
            }
            return cc;
        }


        public static int CharTointUtf32SYMV(char c)
        {
            int cc = 0;
            for (int i = 0; i < Utf32_SYMV.Length; i++)
            {
                if (Utf32_SYMV[i] == c)
                {
                    cc = i;
                    break;
                }
            }
            return cc;
        }

        public static bool IsSYMV(this char ch)
        {
            bool bb = false;
            foreach (char item in Utf32_SYMV)
            {
                if (ch == item)
                {
                    bb = true;
                    break;
                }

            }
            return bb;
        }
        public static bool IsNumber(this char ch)
        {
            bool bb = false;
            foreach (char item in Utf32_012)
            {
                if (ch == item)
                {
                    bb = true;
                    break;
                }

            }
            return bb;
        }

        public static bool IsUp(this char ch)
        {
            bool bb = false;
            foreach (char item in Utf32_ABC)
            {
                if (ch == item)
                {
                    bb = true;
                    break;
                }
                    
            }
            return bb;
        }
        public static bool IsDown(this char ch)
        {
            bool bb = false;
            foreach (char item in Utf32_abc)
            {
                if (ch == item)
                {
                    bb = true;
                    break;
                }
                    
            }
            return bb;
        }

        public static int CharTointUtf32Down(char c)
        {
            int cc = 0;
            for (int i = 0; i < Utf32_abc.Length; i++)
            {
                if(Utf32_abc[i] == c)
                {
                    cc = i;
                    break;
                }
            }
            return cc;
        }
        public static int CharTointUtf32Up(char c)
        {
            int cc = 0;
            for (int i = 0; i < Utf32_ABC.Length; i++)
            {
                if(Utf32_ABC[i] == c)
                {
                    cc = i;
                    break;
                }
            }
            return cc;
        }
    }




}
