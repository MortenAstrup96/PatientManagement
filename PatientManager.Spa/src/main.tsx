import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { BrowserRouter, Route, Routes } from 'react-router'
import { Layout } from './layout.tsx'
import { CssBaseline, ThemeProvider } from '@mui/material'
import { theme } from './util/themeprovider.ts'
import HomePage from './pages/HomePage.tsx'
import PatientDetailsPage from './pages/PatientDetailsPage.tsx'
import CreatePatientPage from './pages/CreatePatientPage.tsx'
import { QueryClient, QueryClientProvider } from '@tanstack/react-query'
import CreateAppointmentPage from './pages/CreateAppointmentPage.tsx'
const queryClient = new QueryClient()

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <QueryClientProvider client={queryClient}>
      <BrowserRouter>
        <ThemeProvider theme={theme}>
          <CssBaseline />
          <Routes>
            <Route path="/" element={<Layout />}>
              <Route index element={<HomePage />} />
              <Route path="patient/:patientId" element={<PatientDetailsPage />} />
              <Route path="patient/new" element={<CreatePatientPage />} />
              <Route path="patient/:patientId/appointments/new" element={<CreateAppointmentPage />} />
            </Route>
          </Routes>    
        </ThemeProvider>
      </BrowserRouter>
    </QueryClientProvider>
  </StrictMode>,
)
