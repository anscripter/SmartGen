using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGen
{
    public class SmartGenerator
    {
        static Random ran = new Random();
        static string[] adjs = null;
        static string[] nouns = null;
        static string[] verbs = null;
        static string[] adverbs = null;

        /// <summary>
        /// Initialize all the words in the DLL
        /// (Naturally made so the generator is fast, You only need to do this once.)
        /// </summary>
        public static void Initialize()
        {
            adjs = Properties.Resources.Adjetives.Split("\r\n".ToCharArray());
            nouns = Properties.Resources.Nouns.ToString().Split("\r\n".ToCharArray());
            verbs = Properties.Resources.Verbs.Split("\r\n".ToCharArray());
            adverbs = Properties.Resources.Adverbs.Split("\r\n".ToCharArray());
        }

        /// <summary>
        /// After initializing the generator, its ready to start!
        /// </summary>
        /// <param name="min">The minimum char amount for the username.</param>
        /// <param name="max">The maximum char amount for the username.</param>
        /// <returns></returns>
        public static string GenerateName(int min, int max)
        {
            string username = "";
            //First we add a switch so we can randomly decide what kind of username we want.
            switch (new Random().Next(1, 3))
            {
                case 1:
                    {
                        //Adjetive + Noun
                        //if the username is too small or too long, well keep going.
                        while (username == "" || username.Length < min || username.Length > max)
                        {
                            string one = adjs[ran.Next(0, adjs.Length - 1)];
                            while (one == "" || one == " ") one = adjs[ran.Next(0, adjs.Length - 1)];
                            string two = nouns[ran.Next(0, nouns.Length - 1)];
                            while (two == "" || two == " ") two = nouns[ran.Next(0, nouns.Length - 1)];
                            username = one + two;
                        }
                        //we found it! lets get out of this mess.
                        break;
                    }

                case 2:
                    {
                        //Verbs + Noun
                        //if the username is too small or too long, well keep going.
                        while (username == "" || username.Length < min || username.Length > max)
                        {
                            string one = verbs[ran.Next(0, verbs.Length - 1)];
                            while (one == "" || one == " ") one = verbs[ran.Next(0, verbs.Length - 1)];
                            string two = nouns[ran.Next(0, nouns.Length - 1)];
                            while (two == "" || two == " ") two = nouns[ran.Next(0, nouns.Length - 1)];
                            username = two + one;
                        }
                        //we found it! lets get out of this mess.
                        break;
                    }

                case 3:
                    {
                        //Adverb + Noun
                        //if the username is too small or too long, well keep going.
                        while (username == "" || username.Length < min || username.Length > max)
                        {
                            string one = adverbs[ran.Next(0, adverbs.Length - 1)];
                            while (one == "" || one == " ") one = adverbs[ran.Next(0, adverbs.Length - 1)];
                            string two = nouns[ran.Next(0, nouns.Length - 1)];
                            while (two == "" || two == " ") two = nouns[ran.Next(0, nouns.Length - 1)];
                            username = two + one;
                        }
                        //we found it! lets get out of this mess.
                        break;
                    }
            }
            //Replace unwanted chars
            return username.Replace("-", "").Replace("'", "");
        }
    }
}
