using System;
using System.Security.Cryptography;
using System.Text;
namespace Day6_exr
{
    class Program
    {
        class Searchable
        {
            string value;
            public Searchable (string val)
            {
                this.value = val;
            }

            public int numOfWords()
            {
                string[] words = this.value.Split(' ');
                return words.Length;
            }
            public int numOfXWord(string word)
            {
                int i = 0;
                int count = 0;
                string[] words = this.value.Split(' ');
                while (i < words.Length)
                {
                    if (words[i] == word)
                    {
                        count++;
                    }
                    i++;
                }
                return count;
            }

            public int numOfXChar(char c)
            {
                int i = 0;
                int count = 0;
                
                while (i < this.value.Length)
                {
                    if (this.value[i] == c)
                    {
                        count++;
                    }
                    i++;
                }
                return count;
            }

            public int numOfChars()
            {
                return this.value.Length;
            }

            public int lastIndexofChar(char c)
            {
                int index = -1;
                int i = 0;
                while (i < this.value.Length)
                {
                    if (this.value[i] == c)
                    {
                        index=i;
                    }
                    i++;
                }
                return index;
            }
        }

        public static void swap (string senctence)
        {
            string [] words = senctence.Split(" ");
            for (int i =0; i < words.Length; i+=2)
            {
                if (i + 1 < words.Length)
                {
                    string temp = words[i];
                    words[i] = words[i + 1];
                    words[i + 1] = temp;
                }
            }

            foreach (var word in words)
            {
                Console.Write("{0} ", word);
            }
        }

        public static int [] rotate(int [] array,int count, bool direction)
        {
            while (count > 0)
            {
                //take 
                if (direction)
                {
                    int temp = array[0];
                    for (int i = 0; i < array.Length; i++)
                    {

                        //if you reach the end of the array put the last element on first index 
                        if (i + 1 == array.Length)
                        {
                            array[0] = temp;
                        }
                        // else just shift it to the right 
                        else
                        {
                            int temp2 = array[i + 1];
                            array[i + 1] = temp;
                            temp = temp2;

                        }


                    }
                }
                else
                {
                    int temp = array[array.Length-1];
                    for (int i = array.Length-1; i >=0; i--)
                    {

                        //if you reach the end of the array put the last element on first index 
                        if (i - 1 < 0)
                        {
                            array[array.Length - 1] = temp;
                        }
                        // else just shift it to the right 
                        else
                        {
                            int temp2 = array[i - 1];
                            array[i - 1] = temp;
                            temp = temp2;

                        }


                    }
                }
                
                
                count--;
            }
            return array;
        }

        class HTMLBuilder
        {
            private string html;

            public HTMLBuilder()
            {
                this.html = "";
            }

            public HTMLBuilder beginTag(string value)
            {
                this.html += "<" + value + ">";
                return this;
            }
            public HTMLBuilder content(string value)
            {
                this.html += " "+value+" ";
                return this;
            }
            public HTMLBuilder endTag(string value)
            {
                this.html += "</"+value+">";
                return this;
            }

            public string get()
            {
                return this.html;
            }
        }
        //a-m -> o
        //n-z -> t
        //else -> .
        public static void whichPart(string words)
        {
            string str = "";
            for (int i = 0; i < words.Length; i++)
            {
                if ((words[i]>='a'&&words[i]<='m')|| (words[i] >= 'A' && words[i] <= 'M'))
                {
                    str+= 'o';
                }
                else if((words[i] >= 'n' && words[i] <= 'z') || (words[i] >= 'N' && words[i] <= 'Z'))
                {
                    str += 't';
                }
                else
                {
                    str += '.';
                }
            }
            Console.WriteLine(str);
        }
        static void Main(string[] args)
        {
            Searchable str = new Searchable("Hey you! 4 Hey");
           

            Console.WriteLine("Number of words: {0}, the word \'Hey\' appeard {1} times, number of charachters: {2}, the char \'H\' appeard {3} times, last index of \'H\' is {4}",str.numOfWords(),str.numOfXWord("Hey")
                ,str.numOfChars(),str.numOfXChar('H'),str.lastIndexofChar('H'));

            //////////////
            ///
            Console.WriteLine("\n\n");
            swap("first(I'llBe2nd) second(I'llBe1st) third forth");
            ///////////////
            int[] values = { 1, 2, 3, 4, 5};
            int [] res= rotate(values,2,false);

            Console.WriteLine("\n\n");
            foreach (var num in res)
            {
                Console.Write("{0} ", num);
            }

            ///////////////
            ///

            string exposed = "Do not use your bag";
            using (SHA1 hash = SHA1.Create())
            {
                byte[] exposedBytes = Encoding.UTF8.GetBytes(exposed);
                byte[] hashBytes = hash.ComputeHash(exposedBytes);
                string hashed = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                Console.WriteLine("\n\nThe SHA1 hash of {0} is: {1}", exposed, hashed);
            }
            //////////////


            // method chaining & fluent interface
            HTMLBuilder html1 = new HTMLBuilder();
            string htmlCode = html1.beginTag("p")
                .content("Welcome to HTML")
                .endTag("p").get();
            Console.WriteLine("\n\n"+htmlCode);

            ////////////
            ///
            Console.WriteLine("\n\nWhich part is: \nABCDENQRST@#$%%222");
            whichPart("ABnCamDENnQRdST@#$%%222");
        }
    }
}
