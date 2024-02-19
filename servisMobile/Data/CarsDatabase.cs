using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Threading.Tasks;
using servisMobile.models;

namespace servisMobile.Data
{
    public class CarsDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public CarsDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Cars>().Wait();
            _database.CreateTableAsync<Mecanic>().Wait();
            _database.CreateTableAsync<ListMecanics>().Wait();
        }

        public Task<List<Cars>> GetCarsListAsync()
        {
            return _database.Table<Cars>().ToListAsync();
        }
        public Task<Cars> GetCarsAsync(int id)
        {
            return _database.Table<Cars>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }

        public Task<int> SaveCarsAsync(Cars car)
        {
            if (car.ID != 0)
            {
                return _database.UpdateAsync(car);
            }
            else
            {
                return _database.InsertAsync(car);
            }
        }

        public Task<int> DeleteCarsAsync(Cars car)
        {
            return _database.DeleteAsync(car);
        }

        public Task<int> SaveMecanictAsync(Mecanic mecanic)
        {
            if (mecanic.ID != 0)
            {
                return _database.UpdateAsync(mecanic);
            }
            else
            {
                return _database.InsertAsync(mecanic);
            }

        }

        public Task<int> DeleteProductAsync(Mecanic mecanic)
        {
            return _database.DeleteAsync(mecanic);
        }


        public Task<List<Mecanic>> GetMecanicAsync()
        {
            return _database.Table<Mecanic>().ToListAsync();
        }

        public Task<int> SaveListMecanicsAsync(ListMecanics listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Mecanic>> GetListMecanicsAsync(int shoplistid)
        {
            return _database.QueryAsync<Mecanic>(
           "select M.ID, M.Description from Mecanic M"
             + " inner join ListMecanics LM"
             + " on M.ID = LM.ProductID where LM.CarsID = ?",
             shoplistid);
        }


    }
}
