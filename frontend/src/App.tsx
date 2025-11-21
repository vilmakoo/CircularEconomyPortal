import { useEffect, useState } from 'react';
import { 
  Container, Typography, Box, Card, CardContent, 
  TextField, Button, Grid, Tab, Tabs, Snackbar, Alert 
} from '@mui/material';

import axios from 'axios';

const API_URL = 'http://localhost:5232'; 

export interface WasteBin {
  id: number;
  address: string;
  emptyingSchedule: string;
  lastEmptiedAt: string;
  userId: number;
}

export interface User {
  id: number;
  name: string;
  email: string;
  phone: string;
}

// Helper to get waste bins
export const getWasteBins = async () => {
  const response = await axios.get<WasteBin[]>(`${API_URL}/wastebins`);
  return response.data;
};

// Helper to get user details
export const getUser = async () => {
  const response = await axios.get<User>(`${API_URL}/users`);
  return response.data;
};

// Helper to update user
export const updateUser = async (user: User) => {
  await axios.put(`${API_URL}/users`, user);
};

// Helper to send feedback
export const sendFeedback = async (message: string) => {
  await axios.post(`${API_URL}/feedback`, { message });
};

function App() {
  const [tabIndex, setTabIndex] = useState(0);
  
  // Data States
  const [bins, setBins] = useState<WasteBin[]>([]);
  const [user, setUser] = useState<User | null>(null);
  
  // Form States
  const [feedbackMsg, setFeedbackMsg] = useState('');
  const [toast, setToast] = useState<{open: boolean, msg: string}>({open: false, msg: ''});

  // Load data on startup
  useEffect(() => {
    getWasteBins().then(setBins).catch(console.error);
    getUser().then(setUser).catch(console.error);
  }, []);

  // Handle User Update
  const handleUserUpdate = async () => {
    if (user) {
      await updateUser(user);
      setToast({ open: true, msg: 'Profile updated successfully!' });
    }
  };

  // Handle Feedback Submit
  const handleFeedbackSubmit = async () => {
    if (feedbackMsg) {
      await sendFeedback(feedbackMsg);
      setFeedbackMsg('');
      setToast({ open: true, msg: 'Feedback sent!' });
    }
  };

  return (
    <Container maxWidth="md" sx={{ mt: 4 }}>
      <Typography variant="h3" gutterBottom align="center">
        Circular Portal
      </Typography>

      <Box sx={{ borderBottom: 1, borderColor: 'divider', mb: 3 }}>
        <Tabs value={tabIndex} onChange={(_, val) => setTabIndex(val)} centered>
          <Tab label="My Waste Bins" />
          <Tab label="My Profile" />
          <Tab label="Give Feedback" />
        </Tabs>
      </Box>

      {/* TAB 0: WASTE BINS */}
      {tabIndex === 0 && (
        <Grid container spacing={2}>
          {bins.map((bin) => (
            <Grid size={{ xs: 12, md: 6 }} key={bin.id}>
              <Card variant="outlined">
                <CardContent>
                  <Typography variant="h6">📍 {bin.address}</Typography>
                  <Typography color="textSecondary">
                    Schedule: {bin.emptyingSchedule}
                  </Typography>
                  <Typography variant="body2" sx={{ mt: 1 }}>
                    Last Emptied: {new Date(bin.lastEmptiedAt).toLocaleDateString()}
                  </Typography>
                </CardContent>
              </Card>
            </Grid>
          ))}
        </Grid>
      )}

      {/* TAB 1: PROFILE EDIT */}
      {tabIndex === 1 && user && (
        <Box component="form" sx={{ display: 'flex', flexDirection: 'column', gap: 2, maxWidth: 400, mx: 'auto' }}>
          <TextField 
            label="Name" 
            value={user.name} 
            onChange={(e) => setUser({...user, name: e.target.value})} 
          />
          <TextField 
            label="Email" 
            value={user.email} 
            onChange={(e) => setUser({...user, email: e.target.value})} 
          />
          <TextField 
            label="Phone" 
            value={user.phone} 
            onChange={(e) => setUser({...user, phone: e.target.value})} 
          />
          <Button variant="contained" onClick={handleUserUpdate}>
            Save Changes
          </Button>
        </Box>
      )}

      {/* TAB 2: FEEDBACK */}
      {tabIndex === 2 && (
        <Box sx={{ maxWidth: 500, mx: 'auto' }}>
          <Typography gutterBottom>Report an issue or give feedback:</Typography>
          <TextField
            fullWidth
            multiline
            rows={4}
            label="Your Message"
            value={feedbackMsg}
            onChange={(e) => setFeedbackMsg(e.target.value)}
          />
          <Button variant="contained" sx={{ mt: 2 }} onClick={handleFeedbackSubmit}>
            Submit Feedback
          </Button>
        </Box>
      )}

      {/* SUCCESS TOAST */}
      <Snackbar open={toast.open} autoHideDuration={3000} onClose={() => setToast({...toast, open: false})}>
        <Alert severity="success">{toast.msg}</Alert>
      </Snackbar>
    </Container>
  );
}

export default App;