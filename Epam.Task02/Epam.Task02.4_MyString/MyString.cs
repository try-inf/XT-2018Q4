using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task02._4_MyString
{
    class MyString
    {
        private char[] arrChars;

        public char[] ArrChars
        {
            get { return arrChars; }
            private set { arrChars = value; }
        }


        public MyString()
        {
            ArrChars = null;
        }


        public int GetLength()
        {
            return ArrChars.Length;
        }

        public void Append(string str)
        {
            char[] strToChar = str.ToCharArray();
            int indexOfLastArrChars;
            
            if (ArrChars != null)
            {
                indexOfLastArrChars = ArrChars.GetUpperBound(0);
                if (ArrChars.Length < ArrChars.Length + strToChar.Length)
                    {
                        Array.Resize(ref arrChars, ArrChars.Length + strToChar.Length);
                    }
                Array.Copy(strToChar, 0, ArrChars, indexOfLastArrChars + 1, strToChar.Length);
            }
            else
            {
                ArrChars = new char[0];
                indexOfLastArrChars = ArrChars.GetUpperBound(0);
                Array.Resize(ref arrChars, ArrChars.Length + strToChar.Length);
                Array.Copy(strToChar, 0, ArrChars, indexOfLastArrChars + 1, strToChar.Length);
            }
        }

        public static string ConCat(string str1, string str2)
        {
            return str1 + str2;
        }

        public bool Equal(string str)
        {
            char[] strToChar = str.ToCharArray();
            if (ArrChars.Length != strToChar.Length)
            {
                return false;
            }
            else
            {
                int count=0;
                for (int i = 0; i < ArrChars.Length; i++)
                {
                    if (ArrChars[i] == strToChar[i])
                    {
                        count++;
                    }
                }
                return (count == arrChars.Length);
            }
        }

        
        public int IndexOf(char ch)
        {
            return Array.IndexOf(ArrChars, ch);
        }
        
    }
}
