import { useParams } from "react-router";

function PatientDetailsPage() {
  const { patientId } = useParams();
  return (
    <h1>
        Patient Details Page: {patientId}
    </h1>
  )
}

export default PatientDetailsPage
