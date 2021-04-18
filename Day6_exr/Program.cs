using System;

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

        public static int [] rotate(int [] array,int count)
        {
            while (count > 0)
            {
                //take 
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
                count--;
            }
            return array;
        }
        static void Main(string[] args)
        {
            Searchable str = new Searchable("Hey you! 4 Hey");
           

            Console.WriteLine("Number of words: {0}, the word \'Hey\' appeard {1} times, number of charachters: {2}, the char \'H\' appeard {3} times, last index of \'H\' is {4}",str.numOfWords(),str.numOfXWord("Hey")
                ,str.numOfChars(),str.numOfXChar('H'),str.lastIndexofChar('H'));
            swap("gjg rrt rtt hhh");

            int[] values = { 1, 2, 3, 4 };
            int [] res= rotate(values,2);


            foreach (var num in res)
            {
                Console.Write("{0} ", num);
            }
        }
    }
}
