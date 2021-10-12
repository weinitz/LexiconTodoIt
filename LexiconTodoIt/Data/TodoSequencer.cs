namespace LexiconTodoIt.Data
{
    public class TodoSequencer
    {
        private static int todoId = 0;

        public static int nextTodoId()
        {
            todoId += 1;
            return todoId;
        }
        
        public static void reset()
        {
            todoId = 0;
        }
    }
}