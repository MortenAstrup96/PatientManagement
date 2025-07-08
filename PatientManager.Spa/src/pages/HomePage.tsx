import { usePatients } from '../hooks/usePatients';
import PatientTable from '../components/home/PatientTable';
import ContentBox from '../components/shared/ContentBox';
import { useNavigate } from 'react-router';

function HomePage() {
  const { patients, error } = usePatients();
  const navigate = useNavigate();

  if (error) return <p>{error}</p>;
  return (
    <ContentBox title='Patient Overview' showActionButton actionButtonLabel='+ Patient' onActionButtonClick={() => navigate('/patient/new')}>
      <PatientTable patients={patients} />
    </ContentBox>
  )
}

export default HomePage;
