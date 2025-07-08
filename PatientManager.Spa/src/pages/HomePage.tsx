import { usePatients } from '../hooks/usePatients';
import PatientTable from '../components/home/PatientTable';

function HomePage() {
  const { patients, error } = usePatients();
  if (error) return <p>{error}</p>;

  return <PatientTable patients={patients} />;
}

export default HomePage;
