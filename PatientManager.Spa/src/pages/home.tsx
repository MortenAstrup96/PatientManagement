import { useEffect, useState } from "react"
import PatientTable from "../components/home/patient-table"
import type { Patient } from "../types/patient";

function HomePage() {
  const [patients, setPatients] = useState<Patient[]>([]);
  useEffect(() => {
    setPatients([]);
  }, [])
  return (
    <>
      <PatientTable patients={patients}/>
    </>
  )
}

export default HomePage
