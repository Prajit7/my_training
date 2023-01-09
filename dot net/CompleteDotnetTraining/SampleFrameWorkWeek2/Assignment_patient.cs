//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SampleFrameWorkWeek2
//{
//    class Details
//    {
        
//        public string Diseasename { get; set; }
//        public string DiseaseSeverity { get; set; }
       
//    }
//    class AccountMgr
//    {
//        private Details[] _patients = null;
//        private int _size = 0;
//        public AccountMgr(int size)
//        {
//            _size = size;
//            _patients = new Details[_size];

//        }
//        public void AddNewDisease(Details det)
//        {
//            for (int i = 0; i < _size; i++)
//            {
//                if (_patients[i] == null)
//                {
//                    _patients[i] = new Details { Diseasename = det.Diseasename };
//                    return;
//                }
//            }
//        }
//    }
//        class Assignment_patient
// { 
//        static void Main(string[] args)
//            {
              

//            }
//        }
//    }



