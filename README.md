# Patient Management System

A simple web application where you can create patients and manage their appointments as well as get a general overview.
## Stack

- **Frontend**: React.js, TypeScript, Vite, MUI (UI Framework)
- **Backend**: .NET 9 (Minimal APIs)
- **Database**: SQLite (in-memory)
- **Architecture**: Clean Architecture (Domain, Application, Infrastructure, API)

---

## How to Run
1. Clone the repository to desired location
2. Start the backend

```bash
cd PatientManager.Api
dotnet run
```

3. Start the frontend

```bash
cd PatientManager.Spa
npm install
npm run dev
```

4. Navigate to http://localhost:5173/ in your web browser
---

## Pages
There are 4 pages in total. Each page follow a consistent design as a card with a title and sometimes an action button above the card.
### Home
The homepage shows all the patients that have already been added. If empty, the homepage will have an empty state.
![home](https://github.com/user-attachments/assets/3715bc5f-15d2-442d-a44d-d698f33706e7)

### Patient Details
The Patient Details page displays basics such as a profile picture, name and address. Additionally it will show current appointments and allow the user to add additional appointments.
![patient-details](https://github.com/user-attachments/assets/fdf47110-3938-467b-826d-325c8f5edc64)

### Create Patient
Create patient page allows creating a new patient with a name, address and an image uploaded from the computer.
![create-patient](https://github.com/user-attachments/assets/4768e781-e2a3-49bb-939d-bb9f8b0a7d6a)

### Create Appointment
New appointments can be made. Some default values are already prefilled.
![create-appointment](https://github.com/user-attachments/assets/6690e4bc-4e8a-422d-b9dd-779267c901ae)

---

## Future Improvements
These are some features and best practices I would like to implement if I had more time.

### Backend
- More strict use of Domain level entities. Currently they are used everywhere, and I even adapted "Patient" to include a byte[] for the image.
- I regretted using raw SQL as I did so to reduce the scope. Now I think using Entity Framework might have been quicker and cleaner.
- I wanted to add better validation and responses for the APIs.
- The photo ended up becoming a bit messy, and I would like to have created a cleaner solution for that. 

### Frontend
- I was going to put a lot of focus on state management, but ended up with keeping track of state with useState/useEffect as well as one custom hook for patients.
    - I was planning to use Context API but never found the need since I not did any prop drilling.
