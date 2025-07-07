import { Paper, TextField, Button, FormControl, Typography, Box, MenuItem, Select, InputLabel } from "@mui/material";
import { useNavigate, useParams } from "react-router";
import { createAppointment } from "../api/appointments";
import { useState } from "react";
import type { AppointmentType } from "../types/dataTypes";
import { minutesToTimespan } from "../util/utilities";

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
      patientId: patientId!, // non-null assertion for simplicity
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
    <Paper
      component="form"
      onSubmit={handleSubmit}
      sx={{
        py: 6,
        px: 24,
        minHeight: "60vh",
        display: "flex",
        flexDirection: "column",
        justifyContent: "space-between",
      }}
    >
      <FormControl fullWidth sx={{ gap: 3 }}>
        <Typography variant="h6">New Appointment</Typography>

        <TextField
          required
          type="datetime-local"
          name="startTime"
          defaultValue={getCurrentDateTimeLocal()}
          label="Date & Time"
        />

        <TextField
          required
          name="dentist"
          label="Dentist"
          defaultValue=""
        />

        <InputLabel id="appointment-type-label">Appointment Type</InputLabel>
        <Select
          labelId="appointment-type-label"
          required
          name="appointmentType"
          defaultValue="Checkup"
          variant="outlined"
        >
          {appointmentTypes.map((type) => (
            <MenuItem key={type} value={type}>{type}</MenuItem>
          ))}
        </Select>

        <TextField
          required
          type="number"
          name="duration"
          label="Duration (minutes)"
          defaultValue={30}
        />
      </FormControl>

      <Box sx={{ display: "flex", justifyContent: "flex-end", mt: 4 }}>
        <Button type="submit" variant="contained" color="secondary">
          Save Appointment
        </Button>
      </Box>
    </Paper>
  );
}

export default CreateAppointmentPage;
