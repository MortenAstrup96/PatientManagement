import AppBar from '@mui/material/AppBar';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import { Toolbar } from '@mui/material';

export default function Navbar() {
  return (
      <AppBar >
        <Toolbar>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Patient Management System
          </Typography>
          <Button color="inherit">Settings</Button>
        </Toolbar>
      </AppBar>
  );
}