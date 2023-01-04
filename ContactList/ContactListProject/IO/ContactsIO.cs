using System;
using System.Collections.Generic;
using System.Text;

namespace ContactListProject.IO
{
    public abstract class ContactsIO
    {
        protected string path;

        public ContactsIO(string path)
        {
            if (path.Length == 0)
            {
                throw new ArgumentException("Invalid file name");
            }
            this.path = path ?? throw new ArgumentNullException(nameof(path));
        }
    }
}
