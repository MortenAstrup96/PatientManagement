using Application.Interfaces;
using Domain;

namespace Infrastructure.Repositories;
class AppointmentRepository : IAppointmentRepository
{
    private readonly SQLiteDatabase _database;
    public AppointmentRepository(SQLiteDatabase database)
    {
        _database = database ?? throw new ArgumentNullException(nameof(database));
    }
    public async Task<Appointment> CreateAppointment(Appointment appointment, CancellationToken cancellationToken)
    {
        try
        {
            var command = _database.GetConnection().CreateCommand();
            command.CommandText = @"
            INSERT INTO Appointments (Id, PatientId, DateTime, Duration, Dentist, Treatment)
            VALUES (@id, @patientId, @dateTime, @duration, @dentist, @treatment);
        ";

            command.Parameters.AddWithValue("@id", appointment.Id);
            command.Parameters.AddWithValue("@patientId", appointment.PatientId);
            command.Parameters.AddWithValue("@dateTime", appointment.StartTime.ToString("o")); // ISO 8601
            command.Parameters.AddWithValue("@duration", (int)appointment.Duration.TotalMinutes);
            command.Parameters.AddWithValue("@dentist", appointment.Dentist);
            command.Parameters.AddWithValue("@treatment", (int)appointment.AppointmentType);

            await command.ExecuteNonQueryAsync(cancellationToken);
            return appointment;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating appointment: {ex.Message}");
            throw;
        }
    }

    public async Task<IEnumerable<Appointment>> GetPatientAppointments(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var command = _database.GetConnection().CreateCommand();
            command.CommandText = @"
            SELECT Id, PatientId, DateTime, Duration, Dentist, Treatment
            FROM Appointments
            WHERE PatientId = @patientId;
        ";
            command.Parameters.AddWithValue("@patientId", id);

            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            var appointments = new List<Appointment>();

            while (await reader.ReadAsync(cancellationToken))
            {
                var appointment = new Appointment
                {
                    Id = reader.GetGuid(0),
                    PatientId = reader.GetGuid(1),
                    StartTime = DateTime.Parse(reader.GetString(2)),
                    Duration = TimeSpan.FromMinutes(reader.GetInt32(3)),
                    Dentist = reader.GetString(4),
                    AppointmentType = (AppointmentType)reader.GetInt32(5)
                };

                appointments.Add(appointment);
            }

            return appointments;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving appointments for patient {id}: {ex.Message}");
            throw;
        }
    }
}
