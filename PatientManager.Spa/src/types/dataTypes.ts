export type Patient = {
  id: string;
  fullName: string;
  address: string;
  imagePath: string;
}

export type Appointment = {
  id: string,
  startTime: string,
  duration: string,
  patientId: string,
  dentist: string,
  appointmentType: AppointmentType
}

export type AppointmentType = "Checkup" | "Cleaning" | "Filling" | "Extraction";