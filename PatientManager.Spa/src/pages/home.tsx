import { useEffect, useState } from "react"
import PatientTable from "../components/home/patient-table"
import type { Patient } from "../types/patient";
import { getAllPatients } from "../api/patients";

function HomePage() {
  const [patients, setPatients] = useState<Patient[]>([]);
  const [loading, setLoading] = useState(true);

   useEffect(() => {
    getAllPatients()
      .then(setPatients)
      .catch((err) => console.error(err))
      .finally(() => setLoading(false));
  }, []);
  
  return (
    <>
      <PatientTable patients={patients}/>
    </>
  )
}

export default HomePage
