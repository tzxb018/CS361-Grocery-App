using _361Example.Models;
using System.Collections.Generic;

namespace _361Example.Engines
{
    /**
     * The IGListEngine interface contains the method declarations for methods that
     * must be defined by any class whose purpose is using an IGListAccessor to access
     * the database's GLists and including business logic to access appropriately.
     **/
    public interface IGListEngine
    {
        //Returns all GLists
        IEnumerable<GList> GetAllLists();

        //Returns all GLists with the specified userId
        IEnumerable<GList> GetUserLists(int userId);

        //Returns the GList with the specified id
        GList GetList(int id);

        //Sorts GLists by some GList attribute
        IEnumerable<GList> SortLists();

        //Inserts gList, and returns the inserted GList
        GList InsertList(GList gList);

        //Updates the GList with the given id to be gList, and returns the updated GList
        GList UpdateList(int id, GList gList);

        //Deletes the GList with the given id, and returns the deleted GList
        GList DeleteList(int id);
    }
}
