import { Box, Button, Container, Typography } from "@mui/material";
import { useNavigate } from "react-router";
import InfoOutlineIcon from '@mui/icons-material/InfoOutline';

export const PatientTableEmpty = () => {
    const navigate = useNavigate();

    return(
        <Container sx={{ py: 8 }}>
      <Box
        sx={{
          textAlign: 'center',
          color: 'text.secondary',
        }}
      >
        <InfoOutlineIcon sx={{ fontSize: 80, mb: 2 }} />

        <Typography variant="h6" gutterBottom>
          No patients found
        </Typography>

        <Typography variant="body1" sx={{ mb: 4 }}>
          You haven't added any patients yet. Click below to get started.
        </Typography>

        <Button
          variant="contained"
          color="primary"
          onClick={() => navigate('/patient/new')}
        >
          + New Patient
        </Button>
      </Box>
    </Container>
    );
}