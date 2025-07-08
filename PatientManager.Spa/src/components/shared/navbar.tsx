import AppBar from '@mui/material/AppBar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import { Toolbar } from '@mui/material';
import { useNavigate } from 'react-router';

export default function Navbar() {
  const navigate = useNavigate();

  return (
    <AppBar >
      <Toolbar>
        <Button variant="text" color="inherit" onClick={() => navigate("/")}>
          <Typography variant="h6" sx={{ flexGrow: 1 }}>
            Patient Management System
          </Typography>
        </Button>
      </Toolbar>
    </AppBar>
  );
}