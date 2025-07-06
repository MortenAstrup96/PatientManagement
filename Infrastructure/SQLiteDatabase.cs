using Microsoft.Data.Sqlite;

namespace Infrastructure;
public class SQLiteDatabase
{
    private readonly SqliteConnection _connection;

    public SQLiteDatabase()
    {
        _connection = new SqliteConnection("Data Source=:memory:");
        _connection.Open();
        InitializeSchema();
    }

    public SqliteConnection GetConnection() => _connection;

    private void InitializeSchema()
    {
        var command = _connection.CreateCommand();

        // Database initial setup
        command.CommandText = @"
            CREATE TABLE Patients (
                Id TEXT PRIMARY KEY,
                FullName TEXT NOT NULL,
                Address TEXT NOT NULL
            );

            CREATE TABLE Dentists (
                Id TEXT PRIMARY KEY,
                FullName TEXT NOT NULL
            );

            CREATE TABLE Appointments (
                Id TEXT PRIMARY KEY,
                PatientId TEXT NOT NULL,
                DateTime TEXT NOT NULL,
                DentistId TEXT NOT NULL,
                Treatment TEXT NOT NULL,
                FOREIGN KEY (PatientId) REFERENCES Patients(Id)
                FOREIGN KEY (DentistId) REFERENCES Demtosts(Id)
            );
        ";
        command.ExecuteNonQuery();
    }
}
