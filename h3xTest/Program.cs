using System.IO;
using System.Collections.Generic;
using System.Numerics;

namespace h3xText // Note: actual namespace depends on the project name.
{
    internal class Program
    {



        static void Main(string[] args)
        {
       

            Program program = new Program();



            Console.WriteLine("Fibonacci Sequence: " + program.FibonacciSequence(8));


            Console.WriteLine("Write a number for the sequence: ");
            
            int val = int.Parse(Console.ReadLine());

            Console.WriteLine("The value is: " + program.GetSequenceValue(val));



        }

        #region FibonacciSequence
        public string FibonacciSequence(int iterations)
        {
            string msg = "\n";
            int next = 0, previ = 0;

            for (int i = 0; i < iterations; i++)
            {
                msg += next.ToString() + "\n";

                if (next == 0)
                {
                    next = 1;
                }
                else
                {
                    int tmp = next;
                    next = next + previ;
                    previ = tmp;
                }

            }

            return msg;
        }

        #endregion


        #region test1 C# Generic Function
        //fn(0)=0 fn(1)=1 fn(i) = fn(i-1) + fn(i-2) + (fn(i-1) + fn(i-2)) / 2
        // i is the index of the value we should return 
        int GetSequenceValue(int iterations)
        {
         
            int next = 0, previ = 0, num = 0;

            for (int i = 0; i < iterations; i++)
            {
               

                if (next == 0)
                {
                    next = 1;
                }
                else
                {
                    int tmp = next;
                    next = next + previ;
                    previ = tmp;
                }

            }


            num = (next + previ + (next + previ)) / 2;
            return num;
        }
        #endregion

        #region test2 Create a Checksum

        uint CreateChecksum(byte[] bytes)
        {

            uint sum = 0;
            int length = bytes.Length;
            for(int i =0;i< length;i++)
            {
                sum += bytes[i];

            }
   
            return sum;
        }
        #endregion


        #region test3 Normalise Audio
        void NormaliseAudio(short[] audio)
        {
            bool third = false;

            for(int i =0;i< audio.Length && !third;i++)
            {
                float act = audio[i];
                if(act < 0.0f)
                {
                    act = act * -1;
                }
                if(act <= (32767/3))
                {
                    third = true;
                }
            }

            if(third)
            {
                for (int i = 0; i < audio.Length; i++)
                {
                    audio[i] *= 3;
            }
            }

        }

        #endregion

        #region test4 Pitfalls

        // Drawcalls: Managing the 3D objects in a performant way
        // New Input System: A completely different way to manage the inputs of the user that is at first a little bit more confusing than the old one

        #endregion


        #region test 5 Coroutine output

        /*
        public class MyClass : MonoBehaviour
        {
            void
          Start()
            {
                Debug.Log("1");
                StartCoroutine(ACoroutine());
                StartCoroutine(ACoroutine());
                Debug.Log("2");
            }
            IEnumerator ACoroutine()
            {
                Debug.Log("3");
                yield return new WaitForSeconds(1);
                Debug.Log("4");
                yield return new
                WaitForSeconds(1); Debug.Log("5");
                yield break;
                Debug.Log("6")
            }
        }
        */


        //Answer: There's an error in the Debug.log("6") that's missing the dotcomma
        //without that error the output would be "1 - 3 - 3 - 2 - 4-  4 -5 - 5

        #endregion



        #region Test 6 match3


        /*
        public class Match3Grid
        {
            enum
          GemType
            {
                Empty, // Not a gem - this grid square is empty
                Diamond,
                Emerald,
                Ruby,
            }
            // Assume this has been initialised already and has valid contents
            GemType[,] m_grid = new GemType[8, 10];
            // Returns null if there aren’t 3 or more gems in a row at this position 



            public List<Vector2Int> GetConnectedGems(int xpos, int ypos)
            {   
        

                List<Vector2Int> solutions = new List<Vector2Int>();
                List<Vector2Int> widthSol = new List<Vector2Int>();
                List<Vector2Int> heightSol = new List<Vector2Int>();

                int h= m_grid.GetLength(0);
                int w =  m_grid.GetLength(1); 
                
      

                bool matchXleft = true;
                bool matchXright = true;
            
                bool matchYup = true;
                bool matchYdown = true;
                
                Gemtype type = m_grid[xpos,ypos];
                
                int xCounter = 0;
                int yCounter = 0;
                 
                for(int i =xpos-1;i>=0 && matchxleft;i--)
                {
                    if(m_grid[i,ypos]==type)
                    {
                        xCounter++;
                        widthSol.Add(new Vector2(i,ypos));
                    }
                    else
                    {
                        matchxLeft=false;
                    }
                    
                }

                 for(int i =xpos+1;i< w && matchxRight;i++)
                {
                    if(m_grid[i,ypos]==type)
                    {
                        xCounter++;                 
                        widthSol.Add(new Vector2(i,ypos));
                    }
                    else
                    {
                        matchxRight=false;
                    }
                    
                }


                                  
                for(int i =ypos-1;i>=0 && matchYup;i--)
                {
                    if(m_grid[xpos,i]==type)
                    {
                        yCounter++;     
                        heightSol.Add(new Vector2(xpos,i));
                    }
                    else
                    {
                        matchYup=false;
                    }
                    
                }

                 for(int i =xpos+1;i< h && matchYdown;i++)
                {
                    if(m_grid[xpos,i]]==type)
                    {
                       yCounter++;      
                    heightSol.Add(new Vector2(xpos,i));
                    }
                    else
                    {
                        matchYdown=false;
                    }
                    
                }
            

                if(yCounter >=3)
                {
                   solutions.AddRange(heightSol);
                    
                }
                if(xCounter >=3)   
                {
                    solutions.AddRange(widthSol);
                }
               
             return solutions;

                
            }
        }
        */


        #endregion



        #region Test 7 left/right

        int IsLeftRight(Vector2 vL0, Vector2 vL1, Vector2 vP)
        {
            int value = 0;

            if((vL0.X - vL1.X) * (vP.Y - vL0.Y) -(vL1.Y-vL0.Y) * (vP.X - vL1.X) > 0)
            {
                value = 1;
            }
            else
            {
                value = -1;
            }

            return value;


        }

        #endregion

        #region Test 8 Compare Dictionaries

        bool AreDictionariesEqual(Dictionary<string, string> a, Dictionary<string,string> b)
        {
            if(a.Count != b.Count)
            {
                return false;
            }
            else
            {
                return a.Keys.All(k => b.ContainsKey(k));
            }

        }


        #endregion



        #region test 9 code fixup


        // Assume the following two job classes are implemented and work 
        /*
                    public class JobInput
                            {
                                public int
                              data;
                            }
                            public class
                          JobThread
                            {
                                // Adds a job that will call action 'complete' on a background
                                // thread within a thread pool.
                                public static void AddJob(JobInput input, System.Action<JobInput>
                                complete)
                                {
                                    // Don't implement this, just assume it works
                                }
                                public static void
                              WaitAll()
                                {
                                    // Don't implement this, just assume it works }
                            }


                            // Find the issues in the following code: 
                            public class MyClass
                            {
                                public void
                              SomeJobs()
                                {
                                    var errors = new
                                  List<string>();
                                    System.Threading.Mutex mutex;
                                    var input = new JobInput();
                                    string resultStr = "";
                                    for (int i = 0; i < 10; i++)
                                    {
                                        input.data =i;
                                        JobThread.AddJob(input, d =>
                                        {
                                            string errorStr;
                                            // The following call only accesses the input data passed to it
                                           var result = SomethingInteresting(d, out errorStr);
                                            if (result == null)
                                            {
                                                errors.Add(errorStr)
                                                ;
                                            }
                                            mutex.WaitOne(); 
                                        resultStr+= result.ToString();
                                        });
                                        mutex.ReleaseMutex();
                                        JobThread.WaitAll();
                                    }

                                    Debug.Log(resultStr);
                                }
                            } 

                */



        //The method "SomethingInteresting doesnt exist
        // mutex is never initialized 



        #region fix

        //Fix 

        /*

        public class MyClass
        {
            public void  SomeJobs()
            {
                var errors = new List<string>();
               
                System.Threading.Mutex mutex = new System.Threading.Mutex(); ;
                var input = new JobInput();
                string resultStr = "";
                for (int i = 0; i < 10; i++)
                {
                    input.data = i;
                    JobThread.AddJob(input, d =>
                    {
                        string errorStr;
                        // The following call only accesses the input data passed to it
                        var result = SomethingInteresting(d, out errorStr);
                        if (result == null)
                        {
                            errors.Add(errorStr);
                        }
                        mutex.WaitOne();
                        resultStr += result.ToString();
                    });
                    mutex.ReleaseMutex();
                    JobThread.WaitAll();
                }

                Debug.Log(resultStr);
            }


            
        } 
         
          
         */
        #endregion
        #endregion
    }


}
