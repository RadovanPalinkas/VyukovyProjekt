//using System;
//using System.Threading;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
////DEF: Třída by měla být otevřená rozšíření ale uzavřená modifikaci
////Při vývoji by se tento princip neměl používat
//namespace TestovaciAlgoritmy.NavrhoveVzory.SOLID_Principles
//{

//    //Create an abstraction for the services

    
//    public class Client 
//    {

//        public void Save(IEnumerable<IUpsertable> persitables)
//        {

//            foreach (var item in persitables)
//            {
//                item.Upsert();
//                LogMessage("Somebody updated something");
//            }


//        }
//        private void LogMessage(string msg)
//        {
//            //Log an audit record
//        }
//    }

//    public interface IUpsertable
//    {
//        void Create();
//        void Select();
//        int Upsert();

//    }
//    public class DbService : IUpsertable
//    {
//        public void Create()
//        {
//            Console.WriteLine("Create");
//        }

//        public void Update()
//        {
//            Console.WriteLine("Update");
//        }

//        public void Select()
//        {
//            Console.WriteLine("Select");
//        }

//        public void Delete()
//        {
//            Console.WriteLine("Delete");
//        }


//        public int Upsert()
//        {

//            if (this.Select().Count() > 0)
//            {
//                return this.Update();
//            }
//            this.Create();
//            return 1;
//        }
//    }

//    public class AzureTableService : IUpsertable
//    {
//        public void Create()
//        {
//            throw new NotImplementedException();
//        }

//        public int Upsert()
//        {
//            int count = 1;
//            if (this.Select().Count() > 0)
//            {
//                count = this.Delete();
//            }
//            this.Create();
//            return count;
//        }

//        public List<string> Select()
//        {
//            throw new NotImplementedException();
//        }

//        public int Delete()
//        {
//            throw new NotImplementedException();
//        }

//    }




//}
