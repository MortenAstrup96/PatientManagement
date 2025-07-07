// src/api/patients.ts

import type { Patient } from "../../types/patient";

const API_BASE = `/api/patients`;

export async function getAllPatients(): Promise<Patient[]> {
    console.log(API_BASE);
  const res = await fetch(API_BASE);
  if (!res.ok) throw new Error('Failed to fetch patients');
  return await res.json();
}

export async function getPatientById(id: string): Promise<Patient> {
  const res = await fetch(`${API_BASE}/${id}`);
  if (!res.ok) throw new Error('Patient not found');
  return await res.json();
}

export async function createPatient(data: Partial<Patient>): Promise<Patient> {
  const res = await fetch(API_BASE, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(data),
  });
  if (!res.ok) throw new Error('Failed to create patient');
  return await res.json();
}

export async function deletePatient(id: string): Promise<void> {
  const res = await fetch(`${API_BASE}/${id}`, {
    method: 'DELETE',
  });
  if (!res.ok) throw new Error('Failed to delete patient');
}
