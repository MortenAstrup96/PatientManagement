import { useEffect, useState } from "react"
import PatientTable from "../components/home/patient-table"
import type { Patient } from "../types/dataTypes";
import { getAllPatients } from "../api/patients";

function HomePage() {
  const [patients, setPatients] = useState<Patient[]>([]);

   useEffect(() => {
    getAllPatients()
      .then(setPatients)
      .catch((err) => console.error(err))
  }, []);
  
  return (
    <PatientTable patients={patients}/>
  )
}

export default HomePage
