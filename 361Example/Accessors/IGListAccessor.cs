using _361Example.Models;
using System.Collections.Generic;

namespace _361Example.Accessors
{
    /**
     * The IGListAccessor interface contains the method declarations for methods that must be defined
     * in any class whose purpose is to access GLists. Likewise, any class that implements IGListAccessor
     * should be fully capable of accessing GLists.
     **/
    public interface IGListAccessor
    {
        //Retrieves all GLists
        IEnumerable<GList> GetAllGLists();

        //Retrieves all GLists belonging to a certain account
        IEnumerable<GList> GetGLists(int userId);

        //Finds and returns the GList with the given id, or null if no such GList exists
        GList Find(int id);

        //Inserts gList into the database and returns the inserted GList
        GList Insert(GList gList);

        //Updates the GList in the database with the same id as gList to be the new version
        void Update(GList gList);

        //Deletes the GList with the given id from the database and returns the deleted GList
        GList Delete(int id);

        //Returns true if a GList with the given id exists in the database, or false if not
        bool Exists(int id);

        //Saves any changes made to the database
        int SaveChanges();
    }
}
