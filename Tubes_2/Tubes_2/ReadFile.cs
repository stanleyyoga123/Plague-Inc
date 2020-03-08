using System;
using System.IO;

namespace Tubes_2
{
    class ReadFile
    {
        int[] population;
        char[] city;
        char[] city_parent;
        char[] city_child;
        double[] tr;
        char first_city;

        public int[] getPopulation()
        {
            return this.population;
        }

        public char[] getCity()
        {
            return this.city;
        }

        public char[] getCityParent()
        {
            return this.city_parent;
        }

        public char[] getCityChild()
        {
            return this.city_child;
        }

        public double[] getTr()
        {
            return this.tr;
        }

        public char getFirstCity()
        {
            return this.first_city;
        }

        public void input_1(string filename)
        {
            using (StreamReader file = new StreamReader(filename))
            {
                int counter = 0;
                int ln;
                string temp_double = "";
                bool mark = false;
                bool stop = false;
                city_parent = new char[0];
                city_child = new char[0];
                tr = new double[0];
                int size = 0;
                int index = 0;

                while (!stop)
                {
                    ln = file.Read();
                    if (ln == 10 || ln == -1)
                    {
                        if (!mark)
                        {
                            size = int.Parse(temp_double);
                            this.city_parent = new char[size];
                            this.city_child = new char[size];
                            this.tr = new double[size];
                        }

                        else
                        {
                            double insert = double.Parse(temp_double);
                            this.tr[index] = insert;
                            index++;
                        }

                        if (ln == -1)
                        {
                            file.Close();
                            stop = true;
                        }

                        temp_double = "";
                        counter = 1;
                        mark = true;
                    }
                    else
                    {
                        if (ln == 32)
                        {
                            counter++;
                        }
                        else
                        {
                            if (counter == 0)
                            {
                                temp_double += (char)ln;
                            }
                            else if (counter == 1)
                            {
                                this.city_parent[index] = (char)ln;
                            }
                            else if (counter == 2)
                            {
                                this.city_child[index] = (char)ln;
                            }
                            else
                            {
                                temp_double += (char)ln;
                            }
                        }
                    }
                }
            }
        }

        public void input_2(string filename)
        {
            using (StreamReader file = new StreamReader(filename))
            {
                int counter = 0;
                int ln;
                bool mark = false;
                string temp_int = "";
                bool stop = false;
                this.city = new char[0];
                this.population = new int[0];
                int index = 0;
                int size = 0;

                while (!stop)
                {
                    ln = file.Read();
                    if (ln == 10 || ln == -1)
                    {
                        if (!mark)
                        {
                            size = int.Parse(temp_int);
                            this.city = new char[size];
                            this.population = new int[size];
                        }

                        else
                        {
                            int insert = int.Parse(temp_int);
                            this.population[index] = insert;
                            index++;
                        }

                        if (ln == -1)
                        {
                            file.Close();
                            stop = true;
                        }

                        temp_int = "";
                        mark = true;
                        counter = 2;
                    }
                    else
                    {
                        if (ln == 32)
                        {
                            counter++;
                        }
                        else
                        {
                            if (counter == 0)
                            {
                                temp_int += (char)ln;
                            }
                            else if (counter == 1)
                            {
                                this.first_city = (char)ln;
                            }
                            else if (counter == 2)
                            {
                                this.city[index] = (char)ln;
                            }
                            else if (counter == 3)
                            {
                                temp_int += (char)ln;
                            }
                        }
                    }
                }
            }
        }
    }
}