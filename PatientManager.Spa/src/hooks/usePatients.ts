import { useEffect, useState, useCallback } from 'react';
import { getAllPatients } from '../api/patients';
import type { Patient } from '../types/dataTypes';

export function usePatients() {
  const [patients, setPatients] = useState<Patient[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  const fetchPatients = useCallback(async () => {
    setLoading(true);
    setError(null);
    try {
      const data = await getAllPatients();
      setPatients(data);
    } catch (err) {
      console.error(err);
      setError('Failed to load patients.');
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    fetchPatients();
  }, [fetchPatients]);

  return {
    patients,
    loading,
    error,
    refresh: fetchPatients,
  };
}
