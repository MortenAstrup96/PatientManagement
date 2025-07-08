import { Outlet } from 'react-router';
import Navbar from './components/shared/Navbar';
import { Container } from '@mui/material';

export function Layout() {
  return (
    <div>
      <Navbar/>
      <Container sx={{ mt: 12 }}>
        <Outlet />
      </Container>
    </div>
  );
}
