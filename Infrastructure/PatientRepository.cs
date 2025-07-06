using Application.Interfaces;
using Domain;
using Microsoft.Data.Sqlite;

namespace Infrastructure;
class PatientRepository : IPatientRepository
{
    private readonly SQLiteDatabase _database;
    public PatientRepository(SQLiteDatabase database)
    {
        _database = database ?? throw new ArgumentNullException(nameof(database));
    }

    public async Task<Patient> CreatePatientAsync(Patient patient, CancellationToken cancellationToken)
    {
        try
        {
            var command = _database.GetConnection().CreateCommand();
            command.CommandText = "INSERT INTO Patients (Id, FullName, Address) VALUES (@id, @name, @address);";
            command.Parameters.AddWithValue("@id", patient.Id);
            command.Parameters.AddWithValue("@name", patient.FullName);
            command.Parameters.AddWithValue("@address", patient.Address);
            await command.ExecuteNonQueryAsync(cancellationToken);

            return patient;
        }
        catch
        {
            Console.WriteLine("An error occurred while creating the patient.");
            throw;
        }
    }

    public async Task DeletePatientAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Patient>> GetAllPatients(CancellationToken cancellationToken)
    {
        var command = new SqliteCommand("SELECT * FROM Patients", _database.GetConnection());
        using var reader = command.ExecuteReader();
        List<Patient> patients = new();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                patients.Add(new Patient(reader.GetGuid(0), reader.GetString(1), reader.GetString(2)));
            }
        }
        return patients;
    }

    public async Task<Patient> GetPatientByIdAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
