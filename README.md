# 🩸 CBBMS - Centralized Blood Bank Management System

CBBMS is a web-based system built with ASP.NET Core that enables the coordination between donors, hospitals, and blood banks. The platform streamlines the blood donation process, hospital blood requests, and stock management within blood banks.

---

## 🔧 Tech Stack

- ASP.NET Core MVC (.NET 6/7)
- Entity Framework Core
- Identity (Authentication & Authorization)
- MS SQL Server
- Bootstrap 5 (for responsive design)

---

## 👥 User Roles

### 🏥 Hospital
- Log in via separate portal
- Create and manage blood requests
- Track request statuses
- View assigned blood bank responses

### 🩸 Donor
- Register and log in
- Submit blood donation requests
- Restrictions based on medical checks & last donation date (3 months)
- View donation history

### 🧪 Blood Bank
- Manage blood stock units (type, quantity, expiry)
- Accept/Reject hospital requests
- Update stock on accepted requests
- View all donation requests to the bank

---

## ✅ Main Features

- Secure Role-Based Authentication
- Dynamic dashboards per user type
- Blood stock management with expiry tracking
- Prevent donors from donating again within 3 months
- Automatic linkage between logged-in user and their assigned hospital/blood bank
- Responsive and modern UI for all views
- Validations for virus test results before allowing donation

---

## 🗂 Project Structure

```bash
CBBMS/
│
├── Areas/Identity          # ASP.NET Identity for authentication
├── Controllers             # MVC Controllers (Hospital, BloodBank, Donor, Account)
├── Models                  # Database models (DonationRequest, BloodBank, BloodStockUnits, etc.)
├── Services                # Business logic (DonorService, BloodBankService, etc.)
├── Views                   # Razor views
│   ├── Shared
│   ├── Hospital
│   ├── Donor
│   └── BloodBank
├── wwwroot                 # Static files (JS, CSS, images)
├── appsettings.json        # Configuration
└── README.md               # This file
```

---

## 🔑 Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/CBBMS.git
   ```

2. **Update DB connection string**
   In `appsettings.json`, update your local SQL Server connection.

3. **Run migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the project**
   ```bash
   dotnet run
   ```

5. **Login or Register**
   - Use `/Donor/Login`, `/Hospital/Login`, or `/BloodBank/Login` depending on your role.

---

## 📌 Notes

- The system currently prevents duplicate donation within 3 months.
- If no blood units are available at the blood bank, a message is shown.
- All logic is cleanly separated via service classes.

---

## 🙌 Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
