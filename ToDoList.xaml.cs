using GorselOdev1.Model;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace GorselOdev1;

public partial class ToDoList : ContentPage
{
	public ToDoList()
	{
		InitializeComponent();

        if (File.Exists(Filepath))
        {
            var jsonData = File.ReadAllText(Filepath);
            notes = JsonSerializer.Deserialize<ObservableCollection<Notes>>(jsonData);
        }

        toDoList.ItemsSource = notes;
    }

    string Filepath = Path.Combine(FileSystem.Current.AppDataDirectory, "toDoList.json");

    ObservableCollection<Notes> notes = new ObservableCollection<Notes> {
        new Notes(){ NoteContent  = "Test Yapılacak 1"},
        new Notes(){ NoteContent  = "Test Yapılacak 2"},
        new Notes(){ NoteContent  = "Test Yapılacak 3"}
    };

    void AddNote(Notes note)
    {
        notes.Add(note);
    }

    private async void Edit_Clicked(object sender, EventArgs e)
    {
        var m = sender as Button;
        var note = notes.First(o => o.Id == m.CommandParameter.ToString());

        string result = await DisplayPromptAsync("Notu Düzenle", "Notunuzu giriniz: ", "Tamam", "İptal");

        if (result != null)
        {
            note.NoteContent = result;
        }
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        var m = sender as Button;
        var note = notes.First(o => o.Id == m.CommandParameter.ToString());

        bool b = await DisplayAlert("Silmeyi Onayla", $"{note.NoteContent} notu silinsin mi?", "Evet", "Hayır");

        if (b)
        {
            notes.Remove(note);

        }

    }

    private void Save_Clicked(object sender, EventArgs e)
    {
        var jsondata = JsonSerializer.Serialize(notes);
        File.WriteAllText(Filepath, jsondata);
    }

    private async void NoteAdd_Clicked(object sender, EventArgs e)
    {
        Notes note;

        string noteContent = await DisplayPromptAsync("Not Ekle", "Notunuzu giriniz: ", "Tamam", "İptal");

        if (noteContent != null)
        {
            note = new Notes()
            {
                NoteContent = noteContent
            };

            AddNote(note);
        }
    }
}