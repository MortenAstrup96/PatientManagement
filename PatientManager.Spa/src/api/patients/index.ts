// src/api/patients.ts

import type { Patient } from "../../types/patient";

const API_BASE = `/api/patients`;
const patientsCache: Record<string, Patient> = {};

export async function getAllPatients(): Promise<Patient[]> {
  const res = await fetch(API_BASE);
  if (!res.ok) throw new Error('Failed to fetch patients');
  return await res.json();
}

export async function getPatientById(id: string): Promise<Patient> {
  if(patientsCache[id]) return patientsCache[id];
  
  const res = await fetch(`${API_BASE}/${id}`);
  if (!res.ok) throw new Error('Patient not found');
  const patient = await res.json() as Patient;
  patientsCache[patient.id] = patient;
  return patient;
}

export async function createPatient(data: Partial<Patient>): Promise<Patient> {
    console.log(data);
  const res = await fetch(API_BASE, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(data),
  });
  if (!res.ok) throw new Error('Failed to create patient');
  const patient = await res.json() as Patient;
  patientsCache[patient.id] = patient;
  return patient;
}

export async function deletePatient(id: string): Promise<void> {
  delete patientsCache[id];
  const res = await fetch(`${API_BASE}/${id}`, {
    method: 'DELETE',
  });
  if (!res.ok) throw new Error('Failed to delete patient');
}
