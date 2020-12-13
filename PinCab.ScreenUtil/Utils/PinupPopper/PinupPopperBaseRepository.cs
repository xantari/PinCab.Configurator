using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Utils.PinupPopper
{
    public class PinupPopperBaseRepository
    {
        public PinupPopperBaseRepository(string dbFile)
        {
            DbFile = dbFile;
        }

        public string DbFile { get; set; }

        public bool ValidateConnection()
        {
            if (string.IsNullOrEmpty(DbFile))
                return false;
            return true;
        }

        public SQLiteConnection PinupPopperConnection()
        {
            if (string.IsNullOrEmpty(DbFile))
                throw new Exception("Pinup Popper database setting is not defined.");
            //Store GUID as text
            return new SQLiteConnection("Data Source=" + DbFile + ";Foreign Keys=True;BinaryGUID=false;");
        }
    }
}
