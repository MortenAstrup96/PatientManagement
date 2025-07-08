// src/api/patients.ts

import type { Appointment } from "../types/dataTypes";

const API_BASE = `/api/appointments`;

export async function getPatientAppointments(patientId: string): Promise<Appointment[]> {
  const res = await fetch(`${API_BASE}/${patientId}`);
  if (!res.ok) throw new Error('Appointment not found');
  return await res.json();
}

export async function createAppointment(data: Partial<Appointment>): Promise<Appointment> {
    console.log(data);
  const res = await fetch(API_BASE, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(data),
  });
  if (!res.ok) throw new Error('Failed to create appointment');
  return await res.json();
}

