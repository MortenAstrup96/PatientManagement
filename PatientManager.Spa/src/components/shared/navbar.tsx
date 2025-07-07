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
          <Button variant="text" onClick={() => navigate("/")}>            
            <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
              Patient Management System
            </Typography>
          </Button>
          <Button color="inherit">Settings</Button>
        </Toolbar>
      </AppBar>
  );
}