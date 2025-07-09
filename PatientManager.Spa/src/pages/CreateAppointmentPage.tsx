import { TextField, Button, FormControl, Box, MenuItem, Select } from "@mui/material";
import { useNavigate, useParams } from "react-router";
import { createAppointment } from "../api/appointments";
import type { AppointmentType } from "../types/dataTypes";
import { minutesToTimespan } from "../util/utilities";
import ContentBox from "../components/shared/ContentBox";

const appointmentTypes = ["Checkup", "Cleaning", "Filling", "Extraction"] as const;

function CreateAppointmentPage() {
  const { patientId } = useParams();
  const navigate = useNavigate();

  const getCurrentDateTimeLocal = () => {
    const now = new Date();
    return now.toISOString().slice(0, 16);
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const formData = new FormData(e.currentTarget);

    const appointmentData = {
      patientId: patientId!,
      startTime: new Date(formData.get("startTime") as string).toISOString(),
      duration: minutesToTimespan(Number(formData.get("duration"))),
      dentist: formData.get("dentist") as string,
      appointmentType: formData.get("appointmentType") as AppointmentType,
    };

    try {
      await createAppointment(appointmentData);
      navigate(`/patient/${patientId}`)
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <ContentBox title='New Appointment'>
      <Box sx={{ p: 4 }}>
        <FormControl fullWidth sx={{ gap: 3 }} component="form" onSubmit={handleSubmit}>
          <TextField required type="datetime-local" name="startTime" defaultValue={getCurrentDateTimeLocal()} label="Date & Time" />
          <TextField required name="dentist" label="Dentist" defaultValue="" />
          <Select required labelId="appointment-type-label" name="appointmentType" defaultValue="Checkup" variant="outlined">
            {appointmentTypes.map((type) => (
              <MenuItem key={type} value={type}>{type}</MenuItem>
            ))}
          </Select>
          <TextField required type="number" name="duration" label="Duration (minutes)" defaultValue={30} />
          <Box sx={{ display: "flex", justifyContent: "flex-end", mt: 4 }}>
            <Button type="submit" variant="contained" color="secondary">
              Create Appointment
            </Button>
          </Box>
        </FormControl>
      </Box>
    </ContentBox>
  );
}

export default CreateAppointmentPage;
