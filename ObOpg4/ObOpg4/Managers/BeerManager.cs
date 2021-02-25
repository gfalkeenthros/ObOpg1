using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObOpg1;

namespace ObOpg4.Managers
{
    public class BeerManager
    {
        private static List<Beer> Data { get; set; }
        public BeerManager()
        {
            Data = new List<Beer>();
        }
        public BeerManager(List<Beer> data)
        {
            Data = data;
        }

        public IEnumerable<Beer> GetAll()
        {
            return Data;
        }

        public Beer GetById(int id)
        {
            return Data.Find((b) => b.Id == id);
        }

        public Beer Post(Beer value)
        {
            Data.Add(value);
            return value;
        }

        public void Update(int id, Beer value)
        {
            int index = Data.FindIndex((e) => e.Id == value.Id);
            if (index != -1)
            {
                Data[index] = value;
            }
        }

        public void Delete(int id)
        {
            Data.Remove(GetById(id));
        }
    }
}
