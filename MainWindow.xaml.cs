using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NoteManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (Note n in Note.notes)
            {
                lb.Items.Add(n);

            }
            
        }
        string input;

        private void AddNote(object sender, RoutedEventArgs e)
        {
            input = tb.Text;
            if (!String.IsNullOrEmpty(input))
            {
                int id = Note.notes.Count > 0 ? Note.notes.Max(n => n.Id) + 1 : 1;
                Note note = new Note(id, input);
                MessageBox.Show($"New Note: {note} added successfully.");
                tb.Clear();
                
                lb.Items.Add(note);
            }

            else
            {
                MessageBox.Show("Please enter some text for note");
            }
        }

        private void DeleteNote(object sender, RoutedEventArgs e)
        {
            var selectedNotes = lb.SelectedItems.Cast<Note>().ToList();  

            if (selectedNotes != null && selectedNotes.Count > 0)
            {
                foreach (var note in selectedNotes)
                {
                    Note.notes.Remove(note);  // Remove from the notes list
                }

                // Refresh the ListBox after deletion
                lb.Items.Clear();
                foreach (Note n in Note.notes)
                {
                    lb.Items.Add(n);
                }
            }
            else
            {
                MessageBox.Show("Please select one or more notes to delete.");
            }
        }
    }
}
