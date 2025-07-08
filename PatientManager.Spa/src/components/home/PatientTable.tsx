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
  Button,
  Container
} from '@mui/material';
import { useNavigate } from 'react-router';
import ArrowForwardIosIcon from '@mui/icons-material/ArrowForwardIos';
import InfoOutlineIcon from '@mui/icons-material/InfoOutline';
import type { Patient } from '../../types/dataTypes';

interface PatientsTableProps {
  patients: Patient[];
}

export default function PatientsTable({ patients }: PatientsTableProps) {
  const navigate = useNavigate();
  const handleNewPatientClick = () => navigate('/patient/new');

  const createEmptyTable = () => (
    <Container sx={{ py: 8 }}>
      <Box sx={{textAlign: 'center', color: 'text.secondary'}}>
        <InfoOutlineIcon sx={{ fontSize: 80, mb: 2 }} />
        <Typography variant="h6" gutterBottom>No patients found</Typography>
        <Typography variant="body1" sx={{ mb: 4 }}>You haven't added any patients yet. Click below to get started.</Typography>
        <Button
          variant="contained"
          color="primary"
          onClick={() => navigate('/patient/new')}>
          + New Patient
        </Button>
      </Box>
    </Container>
  );

  const createPatientTable = () => (
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

          {patients.map((patient) => (
            <TableRow
              key={patient.id}
              hover
              onClick={() => navigate(`/patient/${patient.id}`)}
              sx={{ cursor: 'pointer' }}>
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
  );

  return (
    <Box sx={{ px: 12, py: 6 }}>
      <Box sx={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between', mb: 1 }}>
        <Typography variant="h6">Patient Overview</Typography>
        <Button variant="outlined" color="secondary" onClick={handleNewPatientClick}>
          + New Patient
        </Button>
      </Box>
      {patients.length === 0 ? createEmptyTable() : createPatientTable()}
    </Box>
  );
}
