using Application.Interfaces;
using Domain;
using Microsoft.Data.Sqlite;

namespace Infrastructure.Repositories;
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
            command.CommandText = "INSERT INTO Patients (Id, FullName, Address, Photo) VALUES (@id, @name, @address, @photo);";
            command.Parameters.AddWithValue("@id", patient.Id);
            command.Parameters.AddWithValue("@name", patient.FullName);
            command.Parameters.AddWithValue("@address", patient.Address);
            command.Parameters.AddWithValue("@photo", patient.Photo);
            await command.ExecuteNonQueryAsync(cancellationToken);

            return patient;
        }
        catch
        {
            Console.WriteLine("An error occurred while creating the patient.");
            throw;
        }
    }

    public async Task<bool> DeletePatientAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var command = _database.GetConnection().CreateCommand();
            command.CommandText = "DELETE FROM Patients WHERE Id = @id;";
            command.Parameters.AddWithValue("@id", id);

            var rowsAffected = await command.ExecuteNonQueryAsync(cancellationToken);
            return rowsAffected > 0;
        }
        catch
        {
            Console.WriteLine("An error occurred while deleting the patient.");
            return false;
        }
    }

    public async Task<IEnumerable<Patient>> GetAllPatients(CancellationToken cancellationToken)
    {
        var command = new SqliteCommand("SELECT * FROM Patients", _database.GetConnection());
        using var reader = await command.ExecuteReaderAsync();
        List<Patient> patients = new();
        if (reader.HasRows)
        {
            while (await reader.ReadAsync(cancellationToken))
            {
                var id = reader.GetGuid(0);
                var fullName = reader.GetString(1);
                var address = reader.GetString(2);
                var photo = reader.GetFieldValue<byte[]>(3);

                patients.Add(new Patient(id, fullName, address, photo));
            }
        }
        return patients;
    }

    public async Task<Patient> GetPatientByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var connection = _database.GetConnection();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Patients WHERE Id = @id";
        command.Parameters.AddWithValue("@id", id);

        using var reader = await command.ExecuteReaderAsync(cancellationToken);

        if (await reader.ReadAsync(cancellationToken))
        {
            return new Patient(
                reader.GetGuid(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetFieldValue<byte[]>(3)
            );
        }

        // Create custom exception
        return null; 
    }
}
