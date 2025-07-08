import {
  FormControl,
  TextField,
  Box,
  Button,
  Avatar,
} from "@mui/material";
import { useState } from "react";
import { createPatient } from "../api/patients";
import { useNavigate } from "react-router";
import ContentBox from "../components/shared/ContentBox";

function CreatePatientPage() {
  const navigate = useNavigate();

  const [fullName, setFullName] = useState<string>("");
  const [address, setAddress] = useState<string>("");
  const [photo, setPhoto] = useState<string>("");
  const [isSaving, setIsSaving] = useState<boolean>(false);

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];
    if (!file) return;

    const reader = new FileReader();
    reader.onloadend = () => {
      setPhoto(reader.result?.toString().split(',')[1] as string);
    };
    reader.readAsDataURL(file);
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setIsSaving(true);

    const patient = await createPatient({ fullName, address, photo });
    navigate(`/patient/${patient.id}`);
  };

  return (
    <ContentBox title='Create Patient'>
      <FormControl 
        fullWidth 
        component="form"
        onSubmit={handleSubmit}
        sx={{ gap: 3, p: 4}}>
        <TextField
          required
          id="fullname"
          label="Full Name"
          variant="outlined"
          value={fullName}
          onChange={(e) => setFullName(e.target.value)}/>
        <TextField
          required
          id="address"
          label="Address"
          variant="outlined"
          value={address}
          onChange={(e) => setAddress(e.target.value)}/>
        <Box sx={{ display: "flex", alignItems: "center", gap: 2, mt: 1 }}>
          <input
            accept="image/*"
            id="upload-photo"
            type="file"
            style={{ display: "none" }}
            onChange={handleFileChange}/>
          <label htmlFor="upload-photo">
            <Button variant="outlined" component="span" size="large" sx={{px: 4, py: 2}}>
              Add Picture
            </Button>
          </label>

        <Avatar src={`data:image/jpeg;base64,${photo}`} sx={{ width: 56, height: 56 }}/>
        </Box>
        <Box sx={{ display: "flex", justifyContent: "flex-end", mt: 4 }}>
          <Button
            type="submit"
            variant="contained"
            disabled={isSaving}
            color="secondary"
            size="large">
            Add Patient
          </Button>
        </Box>
      </FormControl>
    </ContentBox>

  );
}

export default CreatePatientPage;
