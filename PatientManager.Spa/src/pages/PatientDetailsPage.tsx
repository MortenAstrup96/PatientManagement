import { useNavigate, useParams } from "react-router";
import { useEffect, useState } from "react";
import { getPatientById } from "../api/patients";
import type { Appointment, Patient } from "../types/dataTypes";

import {
  Avatar,
  Box,
  Card,
  CardContent,
  Skeleton,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";
import { getPatientAppointments } from "../api/appointments";
import ContentBox from "../components/shared/ContentBox";

function PatientDetailsPage() {
  const { patientId } = useParams();
  const navigate = useNavigate();

  const [patient, setPatient] = useState<Patient | null>(null);
  const [appointments, setAppointments] = useState<Appointment[]>([]);

  useEffect(() => {
    if (!patientId) return;
    const fetchData = async () => {
      await getPatientById(patientId)
        .then(setPatient)
        .catch((err) => console.error(err));

      await getPatientAppointments(patientId)
        .then(setAppointments)
        .catch((err) => console.error(err));
    };

    fetchData();
  }, [patientId]);

  if (!patient) {
    return <Skeleton variant="rectangular" height={300} />;
  }

  return (
    <>
      <Box sx={{ px: 12, pt: 2 }}>
        <Card sx={{ mb: 4 }}>
          <CardContent>
            <Box sx={{ display: "flex", alignItems: "center", gap: 3 }}>
              <Avatar
                src={patient.photo}
                sx={{ width: 80, height: 80 }}>
                {patient.fullName[0]}
              </Avatar>
              <Box>
                <Typography variant="h5">{patient.fullName}</Typography>
                <Typography color="gray">{patient.address}</Typography>
              </Box>
            </Box>
          </CardContent>
        </Card>
      </Box>

      <ContentBox title='Appointments' showActionButton actionButtonLabel='+ Appointment'
        onActionButtonClick={() => navigate(`/patient/${patientId}/appointments/new`)}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Type</TableCell>
              <TableCell>Dentist</TableCell>
              <TableCell>Duration</TableCell>
              <TableCell>Date</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {appointments.length > 0 ?
              appointments.map(appointment => {
                return (
                  <TableRow>
                    <TableCell>{appointment.appointmentType}</TableCell>
                    <TableCell>{appointment.dentist}</TableCell>
                    <TableCell>{appointment.duration}</TableCell>
                    <TableCell>{appointment.startTime}</TableCell>
                  </TableRow>
                )
              })
              :
              <TableRow>
                <TableCell colSpan={4}>
                  <Typography align="center" color="text.secondary">
                    No appointments yet.
                  </Typography>
                </TableCell>
              </TableRow>}
          </TableBody>
        </Table>
      </ContentBox>
    </>
  );
}

export default PatientDetailsPage;
