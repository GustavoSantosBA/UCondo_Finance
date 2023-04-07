using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCondo_Finance_Data.Interface
{
    public interface IBaseRepository
    {
        // Create
        T InsertItem<T>(T Entity) where T : class;

        // Read
        IEnumerable<T> ListItem<T>() where T : class;
        T ListItemById<T>(int id) where T : class;

        // Update
        void UpdateItem<T>(T Entity) where T : class;

        // Delete
        void DeleteItemById(int id);



    }
}
