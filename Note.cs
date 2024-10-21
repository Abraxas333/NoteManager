namespace NoteManager
{
    ///<summary>
    /// Class that initializes a List of Notes
    /// Adds a note with an integer Id and a Note as String
    /// Method to String that returns Id and Note
    ///</summary>
    public class Note
    {

        public static List<Note> notes = new List<Note>();

        public int Id { get; set; }
        public string Content { get; set; }

        public Note(int id, string content)
        {
            Id = id;
            Content = content;
            notes.Add(this);

        }
        public override string ToString()
        {
            return $"Note {Id}: {Content}";
        }
    }
}

