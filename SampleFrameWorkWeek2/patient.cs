using SampleConApp;
using System;
using System.IO;

namespace Assignment
{
    class Patient
    {
        public string DiseaseName { get; set; }
        public string DiseaseSeverity { get; set; }
        

    }

    class Symptom : Patient
    {
        public string Symptoms { get; set; } = null;
    }


    class PatientMgr
    {
        private Patient[] _patient = null;
        private int _size = 0;
        public PatientMgr(int size)
        {
            _size = size;
            _patient = new Patient[_size];

        }



        public void AddNewPatient(Patient det)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_patient[i] == null)
                {
                    _patient[i] = new Patient { DiseaseName = det.DiseaseName, DiseaseSeverity = det.DiseaseSeverity };
                    Console.WriteLine("Added the Disease");
                    return;
                }
            }
        }

        public void AddSymptoms(Symptom det)
        {
            
                for (int i = 0; i < _size; i++)
            {
                if (_patient[i].DiseaseName == det.DiseaseName)
                {

                    _patient[i] = new Symptom { DiseaseName = det.DiseaseName, Symptoms = det.Symptoms };
                    return;
                }
                //throw new Exception("First Add the Disease!!!");
                
            }

        }
       
        public Symptom[] findDisease(string symp,string pName)
        {
            int count = 0;
            foreach (Symptom sym in _patient)
            {
                if (sym != null && sym.Symptoms.Contains(symp))
                {
                    count++;
                }
            }
            Symptom[] symptom = new Symptom[count];
            count = 0;
            foreach (Symptom sym in _patient)
            {
                if (sym != null && sym.Symptoms.Contains(symp))
                {
                    //Console.WriteLine(sym.DiseaseName);
                    Console.WriteLine($"The Patient Name {pName} may have {sym.DiseaseName}");


                }
            }
            return symptom;


        }
    }


   
    class UIManager
    {
        public static PatientMgr mgr = null;
        

        internal static void DisplayMenu()
        {
            Console.WriteLine("Medical Research Application in C# as Console Application");
            int size = Utilities.GetNumber("Enter the Total disease you want to Add");
            mgr = new PatientMgr(size);
            bool processing = true;
            string menu = "Press 1 to Add Disease \nPress 2 to Add Symptoms To the Disease\nPress 3 to view the approx Disease for the Patient\nPress Other Key to Exit";
            do
            {
                int choice = Utilities.GetNumber(menu);
                processing = processMenu(choice);
            } while (processing);
        }
        private static bool processMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    addingDisease();
                    break;
                case 2:
                    addSymptoms();                   
                    break;
                case 3:
                    checkPatient();
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static void checkPatient()
        {
                string pName = Utilities.Prompt("Enter the name of the patient");
                string sym = Utilities.Prompt("Enter the Symptom Name");
                Patient[] det = mgr.findDisease(sym, pName);
          

            }

        private static void addSymptoms()
        {
            

            string diseaseName = Utilities.Prompt("Enter the Name of the Disease");
            string symptomName = Utilities.Prompt("Enter the Symptoms of the Disease");
            string[] symptomNameSplit = symptomName.Split(',');
            foreach (var item in symptomNameSplit)
            {
                Symptom acc = new Symptom { DiseaseName = diseaseName, Symptoms = item };

                mgr.AddSymptoms(acc);
                Console.WriteLine("Symptom Added");
            }

            //    Symptom acc = new Symptom { DiseaseName = diseaseName, Symptoms = symptomName };

            //mgr.AddSymptoms(acc);
            //Console.WriteLine("Symptom Added");


        }

        private static void addingDisease()
        {
          
            string diseaseName = Utilities.Prompt("Enter the Name of the Disease");
            string diseaseSc = Utilities.Prompt("Enter the Scenrity of the Disease");

            Patient acc = new Patient { DiseaseName= diseaseName,DiseaseSeverity=diseaseSc };
            mgr.AddNewPatient(acc);
            
        }
    }



    class patient
    {
        static void Main(string[] args)
        {
            UIManager.DisplayMenu();


        }
    }

}

