import {
  Avatar,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Typography,
  Box,
  Button
} from '@mui/material';
import type { Patient } from '../../types/dataTypes';
import { useNavigate } from 'react-router';
import ArrowForwardIosIcon from '@mui/icons-material/ArrowForwardIos';
import { PatientTableEmpty } from './patient-table-empty';

interface PatientsTableProps {
  patients: Patient[]
}

export default function PatientsTable({patients}: PatientsTableProps) {  
  const navigate = useNavigate();
  return (
    <Box sx={{ px: 12, py: 6 }}>
      <Box sx={{display: "flex", alignItems: "center", justifyContent: "space-between", mb: 1}}>
        <Typography variant="h6">Patient Overview</Typography>
        <Button variant="outlined" color="secondary" onClick={() => navigate('/patient/new')}>
          + New Patient
        </Button>
      </Box>

      { patients.length === 0 ? <PatientTableEmpty /> :
      <TableContainer component={Paper}>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Patient</TableCell>
            <TableCell>Address</TableCell>
            <TableCell />
          </TableRow>
        </TableHead>
        <TableBody>
        {
        patients.map((patient) => (
          <TableRow
            key={patient.id}
            hover
            onClick={() => navigate(`/patient/${patient.id}`)}
            sx={{ cursor: 'pointer' }}
          >
            <TableCell>
              <Box sx={{ display: 'flex', alignItems: 'center' }}>
                <Avatar src={`data:image/jpeg;base64,${patient.photo}`} sx={{ mr: 2 }} />
                <Typography>{patient.fullName}</Typography>
              </Box>
            </TableCell>
            <TableCell>{patient.address}</TableCell>
            <TableCell align="right">
              <ArrowForwardIosIcon />
            </TableCell>
          </TableRow>
        ))}
        </TableBody>
      </Table>
    </TableContainer>
      }
    </Box>
  )
}
