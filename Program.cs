using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadyBug
{
    class Program
    {
        static void Main(string[] args)
        {

            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladybugs = new int[fieldSize];

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] command = Console.ReadLine().Split();

            foreach (var index in indexes)
            {
                if (index >= 0 && index < fieldSize)
                {
                    ladybugs[index] = 1;
                }
            }

            while (!command[0].Equals("end"))
            {
                long index = long.Parse(command[0]);
                long move = long.Parse(command[2]);

                if (index < 0 || index >= fieldSize)
                {
                    command = Console.ReadLine().Split();
                    continue;
                }

                if (ladybugs[index] == 0)
                {
                    command = Console.ReadLine().Split();
                    continue;
                }

                if (command[1].Equals("right"))
                {
                    if (index + move >= fieldSize || index + move < 0)
                    {
                        ladybugs[index] = 0;
                        command = Console.ReadLine().Split();
                        continue;
                    }
                    else
                    {
                        long flyDistance = index + move;
                        ladybugs[index] = 0;
                        while (index < fieldSize && index >= 0 && flyDistance < fieldSize && flyDistance >= 0)
                        {
                            if (ladybugs[flyDistance] == 0)
                            {
                                ladybugs[flyDistance] = 1;
                                break;
                            }
                            else
                            {
                                flyDistance += move;
                            }
                        }
                    }
                }
                else if (command[1].Equals("left"))
                {
                    if (index - move >= fieldSize || index - move < 0)
                    {
                        ladybugs[index] = 0;
                        command = Console.ReadLine().Split();
                        continue;
                    }
                    else
                    {
                        ladybugs[index] = 0;
                        long flyDistance = index - move;

                        while (index < fieldSize && index >= 0 && flyDistance < fieldSize && flyDistance >= 0)
                        {
                            if (ladybugs[flyDistance] == 0)
                            {
                                ladybugs[flyDistance] = 1;
                                break;
                            }
                            else
                            {
                                flyDistance -= move;
                            }
                        }
                    }
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", ladybugs));
        }
    }
}
