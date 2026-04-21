using Microsoft.Data.Sqlite;
using TeamProject.Models;

namespace TeamProject.Data;

public class FilmRepository
{
    private const string ConnectionString = "Data Source=films.db";

    public FilmRepository()
    {
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS Films (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Titel TEXT NOT NULL,
                Genre TEXT NOT NULL,
                Åldersgräns INTEGER NOT NULL,
                Recension TEXT
            )";
        command.ExecuteNonQuery();
    }

    public List<FilmModels> GetAllFilms()
    {
        var films = new List<FilmModels>();
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Titel, Genre, Åldersgräns, Recension FROM Films ORDER BY Id DESC";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            films.Add(new FilmModels
            {
                Id = reader.GetInt32(0),
                Titel = reader.GetString(1),
                Genre = reader.GetString(2),
                Åldersgräns = reader.GetInt32(3),
                Recension = reader.IsDBNull(4) ? null : reader.GetString(4)
            });
        }

        return films;
    }

    public void AddFilm(FilmModels film)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            INSERT INTO Films (Titel, Genre, Åldersgräns, Recension)
            VALUES ($titel, $genre, $aldersgrans, $recension)";

        command.Parameters.AddWithValue("$titel", film.Titel);
        command.Parameters.AddWithValue("$genre", film.Genre);
        command.Parameters.AddWithValue("$aldersgrans", film.Åldersgräns);
        command.Parameters.AddWithValue("$recension", film.Recension ?? (object)DBNull.Value);

        command.ExecuteNonQuery();
    }

    public void DeleteFilm(int id)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Films WHERE Id = $id";
        command.Parameters.AddWithValue("$id", id);

        command.ExecuteNonQuery();
    }
}