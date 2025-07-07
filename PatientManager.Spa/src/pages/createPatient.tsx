import { Paper, FormControl, TextField, Box, Button, InputLabel, Input, Typography, Card } from "@mui/material";
import { useState } from "react";
import { createPatient } from "../api/patients";
import { useNavigate } from "react-router";

function CreatePatientPage() {
  const navigate = useNavigate();

  const [fullName, setFullName] = useState<string>('');
  const [address, setAddress] = useState<string>('');
  const [imagePath, setImagePath] = useState<string>('');
  const [isSaving, setIsSaving] = useState<boolean>(false);


  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setIsSaving(true);
    console.log({
      fullName,
      address,
      imagePath,
    });

    const patient = await createPatient({ fullName, address, imagePath });
    navigate(`/patient/${patient.id}`);
  };

  return (
      <Box sx={{ px: 18, py: 6 }}>
    <Card
      component="form"
      onSubmit={handleSubmit}
      sx={{
        py: 4,
        px: 8,
        minHeight: '60vh',
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'space-between',
      }}
    >
    
      <FormControl fullWidth sx={{ gap: 3 }}>
        <Typography variant="h6">Create New Patient</Typography>
        <TextField
          required
          id="fullname"
          label="Full Name"
          variant="outlined"
          value={fullName}
          onChange={(e) => setFullName(e.target.value)}
        />

        <TextField
          required
          id="address"
          label="Address"
          variant="outlined"
          value={address}
          onChange={(e) => setAddress(e.target.value)}
        />

        <Box>
          <InputLabel htmlFor="photo">Photo</InputLabel>
          <Input
            required
            id="photo"
            type="file"
            onChange={(e) => setImagePath('photo path')}
          />
        </Box>
      </FormControl>

      <Box sx={{ display: 'flex', justifyContent: 'flex-end', mt: 4 }}>
        <Button type="submit" variant="contained" loading={isSaving} size="large">
          Save
        </Button>
      </Box>
    </Card>
    </Box>
  );
}

export default CreatePatientPage;
