using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace LexiconTodoIt.Data
{
    class PersonSequencer
    {
        private static int personId;

        public static int nextPersonId()
        {
            return ++personId;
        }

        public static void Reset()
        {
            personId = 0;
        }
    }
}
