using System;
using System.IO;

namespace GUI3
{
    class ReadFile
    {
        int[] population;
        string[] city;
        string[] city_parent;
        string[] city_child;
        double[] tr;
        string first_city;

        public int[] getPopulation()
        {
            return this.population;
        }

        public string[] getCity()
        {
            return this.city;
        }

        public string[] getCityParent()
        {
            return this.city_parent;
        }

        public string[] getCityChild()
        {
            return this.city_child;
        }

        public double[] getTr()
        {
            return this.tr;
        }

        public string getFirstCity()
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
                city_parent = new string[0];
                city_child = new string[0];
                tr = new double[0];
                int size = 0;
                int index = 0;
                string temp_str_child = "";
                string temp_str_parent = "";

                while (!stop)
                {
                    ln = file.Read();
                    if (ln == 10 || ln == -1)
                    {
                        if (!mark)
                        {
                            size = int.Parse(temp_double);
                            this.city_parent = new string[size];
                            this.city_child = new string[size];
                            this.tr = new double[size];
                        }

                        else
                        {
                            double insert = double.Parse(temp_double);
                            this.tr[index] = insert;
                            this.city_parent[index] = temp_str_parent;
                            this.city_child[index] = temp_str_child;
                            index++;
                        }

                        if (ln == -1)
                        {
                            file.Close();
                            stop = true;
                        }

                        temp_double = "";
                        temp_str_parent = "";
                        temp_str_child = "";
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
                                if ((char)ln != '\r')
                                {
                                    temp_str_parent += (char)ln;
                                }
                            }
                            else if (counter == 2)
                            {
                                if ((char)ln != '\r')
                                {
                                    temp_str_child += (char)ln;
                                }
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
                string temp_str = "";
                bool stop = false;
                this.city = new string[0];
                this.population = new int[0];
                int index = 0;
                int size = 0;
                string temp_str_city = "";

                while (!stop)
                {
                    ln = file.Read();
                    if (ln == 10 || ln == -1)
                    {
                        if (!mark)
                        {
                            size = int.Parse(temp_int);
                            this.city = new string[size];
                            this.population = new int[size];
                        }

                        else
                        {
                            int insert = int.Parse(temp_int);
                            this.population[index] = insert;
                            this.city[index] = temp_str_city;
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
                        temp_str = "";
                        temp_str_city = "";
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
                                if ((char)ln != '\r')
                                {
                                    temp_str += (char)ln;
                                }
                                this.first_city = temp_str;
                            }
                            else if (counter == 2)
                            {
                                if ((char)ln != '\r')
                                {
                                    temp_str_city += (char)ln;
                                }
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