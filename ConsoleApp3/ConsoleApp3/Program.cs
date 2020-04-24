using System.Data.Common;
using System;
using System.IO;
using System.Collections.Generic;

namespace Hospital_Management_System
{
    class Program
    {

        int noOfLinesDoctor()
        {
            if (File.Exists("doctors.txt"))
            {
                var lineCount = File.ReadAllLines("doctors.txt").Length;
                return lineCount;
            }
            else
            {
                return 0;
            }
        }

        int noOfLinesPatient()
        {
            if (File.Exists("patients.txt"))
            {
                var lineCount = File.ReadAllLines("patients.txt").Length;
                return lineCount;
            }
            else
            {
                return 0;
            }
        }

        void addDoctor()
        {
            Console.WriteLine("Add Doctor Panel");

            int doctorID = noOfLinesDoctor() + 1;
            Console.Write("Enter Doctor Name: ");
            String doctorName = Console.ReadLine().ToUpper();
            Console.Write("Enter Doctor Department: ");
            String doctorDept = Console.ReadLine().ToUpper();

            StreamWriter sw = new StreamWriter("doctors.txt", append: true);
            sw.WriteLine(doctorID + ")  Name: " + doctorName + "  Department: " + doctorDept);
            Console.WriteLine("Doctor Added Successfully!");
            sw.Close();
        }

        void addPatient()
        {
            Console.WriteLine("Add Patient Panel");

            int patientID = noOfLinesPatient() + 1;
            Console.Write("Enter Patient Name: ");
            String patientName = Console.ReadLine().ToUpper();

            Console.Write("Enter Doctor Name: ");
            String doctorName = Console.ReadLine().ToUpper();

            int found = searchDoctor(doctorName);

            do
            {
                if (found == 0)
                {
                    Console.Write("Enter Doctor Name Again: ");
                    doctorName = Console.ReadLine().ToUpper();
                    found = searchDoctor(doctorName);
                }
            }
            while (found == 0);

            Console.Write("Enter Patient's Contact No: ");
            long contactNo = long.Parse(Console.ReadLine());

            Console.Write("Enter Patient's Ward No: ");
            int wardNo = Convert.ToInt32(Console.ReadLine());

            StreamWriter sw = new StreamWriter("patients.txt", append: true);
            sw.WriteLine(patientID + ")  Name: " + patientName + "  Dr. Name: " + doctorName + "  Contact#: " + contactNo + "  Ward No: " + wardNo);
            Console.WriteLine("Patient Added Successfully!");
            sw.Close();
        }

        void allDoctors()
        {
            if (File.Exists("doctors.txt"))
            {
                StreamReader sw = File.OpenText("doctors.txt");
                String data = "";
                Console.WriteLine();

                Console.WriteLine("Doctors List: \n");
                while ((data = sw.ReadLine()) != null)
                {
                    Console.WriteLine(data);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("File Doesn't Exist!");
            }
        }

        void allPatients()
        {
            if (File.Exists("patients.txt"))
            {
                StreamReader sw = File.OpenText("patients.txt");
                String data = "";
                Console.WriteLine();

                Console.WriteLine("Patients List: \n");
                while ((data = sw.ReadLine()) != null)
                {
                    Console.WriteLine(data);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("File Doesn't Exist!");
            }
        }

        int searchDoctor(String search)
        {

            List<String> current = new List<String>();
            int count = 0;

            if (File.Exists("doctors.txt"))
            {

                foreach (var line in File.ReadAllLines("doctors.txt"))
                {
                    if (line.Contains(search))
                    {
                        current.Add(line);
                        count++;
                    }
                }

                if (count > 0)
                {
                    Console.WriteLine();
                    current.ForEach(Console.WriteLine);
                    Console.WriteLine();
                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("No Doctor Found of this Name!");
                    Console.WriteLine();
                }

                return count;
            }

            else
            {
                Console.WriteLine("File Doesn't Exist!");
                return 0;
            }
        }

        int searchPatient(String search)
        {

            List<String> current = new List<String>();
            int count = 0;

            if (File.Exists("patients.txt"))
            {

                foreach (var line in File.ReadAllLines("patients.txt"))
                {
                    if (line.Contains(search))
                    {
                        current.Add(line);
                        count++;
                    }
                }

                if (count > 0)
                {
                    Console.WriteLine();
                    current.ForEach(Console.WriteLine);
                    Console.WriteLine();
                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("No Patient Found of this Name!");
                    Console.WriteLine();
                }

                return count;
            }

            else
            {
                Console.WriteLine("File Doesn't Exist!");
                return 0;
            }
        }

        static void Main(string[] args)
        {
            Program pr = new Program();

            String username = "";
            int password = 0;
            Console.WriteLine("~~~ Welcome to Aga Khan Hospital ~~~\n");

            Console.Write("Enter Admin Username: ");
            username = Console.ReadLine().ToUpper();
            Console.Write("Enter Password: ");
            password = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if (username.Equals("ADMIN") && password == 123)
            {

                int selection = 1;

                while (selection != 0)
                {
                    Console.Write("\nPress: \n" +
                                    "1) Add Doctor \n" +
                                    "2) Add Patient \n" +
                                    "3) View Doctors \n" +
                                    "4) View Patients \n" +
                                    "5) Search Doctor \n" +
                                    "6) Search Patient \n" +
                                    "0) Exit \n" +
                                    "Your Answer: ");

                    selection = Convert.ToInt32(Console.ReadLine());

                    switch (selection)
                    {
                        case 1:
                            Console.Clear();
                            pr.addDoctor();
                            break;

                        case 2:
                            Console.Clear();
                            pr.addPatient();
                            break;

                        case 3:
                            Console.Clear();
                            pr.allDoctors();
                            break;

                        case 4:
                            Console.Clear();
                            pr.allPatients();
                            break;

                        case 5:
                            Console.Clear();
                            String drSearch;
                            Console.WriteLine("Doctor Search Panel: ");
                            Console.Write("Enter Doctor Name: ");
                            drSearch = Console.ReadLine().ToUpper();
                            pr.searchDoctor(drSearch);
                            break;

                        case 6:
                            Console.Clear();
                            String ptSearch;
                            Console.WriteLine("Patient Search Panel: ");
                            Console.Write("Enter Patient Name: ");
                            ptSearch = Console.ReadLine().ToUpper();
                            pr.searchPatient(ptSearch);
                            break;

                        case 0:
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Wrong input!");
                            break;
                    }
                }

            }

            else
            {
                Console.WriteLine("Wrong Password!");
            }
        }

    }
}