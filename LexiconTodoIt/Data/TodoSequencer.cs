using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconTodoIt.Data
{
    class TodoSequencer
    {
        private static int todoId;

        public static int nextTodoId()
        {
            return ++todoId;
        }

        public static void Reset()
        {
            todoId = 0;
        }
    }
}
