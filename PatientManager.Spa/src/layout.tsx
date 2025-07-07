import { Outlet } from 'react-router';
import Navbar from './components/shared/navbar';
import { Container } from '@mui/material';

export function Layout() {
  return (
    <div>
      <Navbar/>
      <Container sx={{ mt: 10 }}>
        <Outlet />
      </Container>
    </div>
  );
}
