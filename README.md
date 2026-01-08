# Enterprise Document Management & Collaboration Platform

[![. NET](https://img.shields.io/badge/.NET-4.5-blue.svg)](https://dotnet.microsoft.com/)
[![AngularJS](https://img.shields.io/badge/AngularJS-1.x-red.svg)](https://angularjs.org/)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)


> **A full-stack enterprise document management and real-time collaboration system with role-based access control, business process management, and integrated document editing capabilities.**

Built with JavaScript, C#.NET Web API, Entity Framework, AngularJS, and ONLYOFFICE document editors, this platform demonstrates comprehensive full-stack development expertise across multiple architectural patterns and enterprise technologies.

---

## Table of Contents

- [Overview](#overview)
- [Key Features](#key-features)
- [Technology Stack](#technology-stack)
- [Architecture](#architecture)
- [System Capabilities](#system-capabilities)
- [Getting Started](#getting-started)
- [API Documentation](#api-documentation)
- [Security Features](#security-features)
- [Database Schema](#database-schema)
- [Roadmap & Modernization](#roadmap--modernization)
- [Contributing](#contributing)
- [License](#license)

---

## Overview

This enterprise-grade document management platform enables organizations to:
- Collaboratively create, edit, and manage documents in real-time
- Implement business continuity and compliance workflows (ISO 22301)
- Manage organizational hierarchies with granular permissions
- Track business processes with geospatial data
- Generate reports and analytics on document activities
- Maintain audit trails and user activity logs

**Use Cases**:  Business Continuity Planning, Compliance Management, Enterprise Content Management, Collaborative Documentation, Risk Assessment & Analysis

---

## Key Features

### Security & Access Control
- **Role-Based Access Control (RBAC)** with 4 permission levels
- **Multi-tenant architecture** with organizational unit isolation
- **User & Group Management** with hierarchical permissions
- **Activity logging & audit trails** for compliance
- **Session management** with secure authentication

### Document Management
- **Real-time collaborative editing** via ONLYOFFICE integration
- **Document templates** with versioning and metadata
- **Workspace templates** for standardized document sets
- **Multi-format support**:  DOCX, PDF, RTF, TXT, HTML, ODT, EPUB
- **Document conversion & export** capabilities
- **Search & replace** across document collections

### Business Process Management
- **Organizational hierarchy** management (multi-level)
- **Business process modeling** with attributes and KPIs
- **Business Impact Analysis (BIA)** tools
- **SWOT Analysis** and strategic planning features
- **Workflow management** with state tracking
- **Incident tracking** with priority and geolocation

### Analytics & Reporting
- **User activity dashboards** with login history
- **Report generation** (CSV, PDF exports)
- **Document statistics** (pages, sections, usage metrics)
- **Business process analytics** with custom attributes
- **Real-time dashboard** with task tracking

### Geospatial Features
- **Google Maps integration** for location-based data
- **Business process geolocation** tracking
- **Incident mapping** and visualization
- **Multi-location organizational units**

---

## Technology Stack

### Backend
| Technology | Version | Purpose |
|------------|---------|---------|
| **. NET Framework** | 4.5 | Web API backend |
| **ASP.NET Web API 2** | - | RESTful services |
| **Entity Framework** | 6.x | ORM & data access |
| **SQL Server** | 2012+ | Relational database |
| **ONLYOFFICE Editors** | - | Document editing engine |
| **Aspose. Words** | - | Document processing |
| **Log4Net** | - | Structured logging |

### Frontend
| Technology | Purpose |
|------------|---------|
| **AngularJS 1.x** | SPA framework |
| **HTML5 / CSS3** | Modern web standards |
| **Bootstrap 3** | Responsive UI framework |
| **jQuery** | DOM manipulation |
| **D3.js** | Data visualization |
| **Google Maps API** | Geospatial features |
| **angular-ui-router** | Routing & navigation |
| **angular-file-upload** | File management |

### DevOps & Tools
- **IIS 7.5+** - Web server
- **SQL Server Express** - Development database
- **Node.js** (ONLYOFFICE) - Document service
- **Puppet** - Configuration management (minimal)

---

## Architecture

### High-Level System Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                      CLIENT LAYER                           │
│  ┌──────────────┐  ┌──────────────┐  ┌─────────────────┐  │
│  │   Admin SPA  │  │   User SPA   │  │  Public Portal  │  │
│  │ (AngularJS)  │  │ (AngularJS)  │  │   (AngularJS)   │  │
│  └──────────────┘  └──────────────┘  └─────────────────┘  │
└─────────────────────────────────────────────────────────────┘
                            │
                    ┌───────▼────────┐
                    │   API Gateway  │
                    │  (HTTP/HTTPS)  │
                    └───────┬────────┘
                            │
┌───────────────────────────┴───────────────────────────────┐
│                    API LAYER                              │
│  ┌─────────────────────────────────────────────────────┐ │
│  │          ASP.NET Web API 2 Controllers              │ │
│  │  [CoopAuthorize] Attribute-Based Routing            │ │
│  └─────────────────────────────────────────────────────┘ │
└───────────────────────────┬───────────────────────────────┘
                            │
┌───────────────────────────┴───────────────────────────────┐
│                  SERVICE LAYER                            │
│  ┌──────────────┐  ┌──────────────┐  ┌────────────────┐ │
│  │ISystemService│  │ITemplateServ │  │IBusinessProc..   │ │
│  │              │  │              │  │                │ │
│  │ Users/Groups │  │ Documents    │  │ Processes      │ │
│  └──────────────┘  └──────────────┘  └────────────────┘ │
└───────────────────────────┬───────────────────────────────┘
                            │
┌───────────────────────────┴───────────────────────────────┐
│                REPOSITORY LAYER                           │
│  ┌──────────────────────────────────────────────────────┐│
│  │        Entity Framework 6 + Unit of Work Pattern     ││
│  └──────────────────────────────────────────────────────┘│
└───────────────────────────┬───────────────────────────────┘
                            │
┌───────────────────────────┴───────────────────────────────┐
│                   DATA LAYER                              │
│  ┌──────────────────────────────────────────────────────┐│
│  │              SQL Server Database                     ││
│  │  [Users] [Groups] [OrgUnits] [Documents]            ││
│  │  [BusinessProcesses] [Workflows] [Incidents]        ││
│  └──────────────────────────────────────────────────────┘│
└───────────────────────────────────────────────────────────┘

┌──────────────────────────────────────────────────────────┐
│               EXTERNAL SERVICES                           │
│  ┌───────────────┐  ┌──────────────┐  ┌──────────────┐ │
│  │  ONLYOFFICE   │  │  Aspose      │  │ Google Maps  │ │
│  │  Doc Server   │  │  Words API   │  │     API      │ │
│  └───────────────┘  └──────────────┘  └──────────────┘ │
└──────────────────────────────────────────────────────────┘
```

### Directory Structure

```
Document-Management-Collaboration/
│
├── doc-client/                          # Frontend Application
│   ├── admin/                          # Admin portal
│   ├── user/                           # User portal
│   ├── scripts/
│   │   ├── app.js                      # Main app module
│   │   ├── admin-app.js                # Admin module
│   │   ├── user-app.js                 # User module
│   │   ├── controllers/                # Angular controllers
│   │   ├── services/                   # Angular services
│   │   ├── resources/                  # API resource factories
│   │   └── libraries/                  # Third-party JS libs
│   ├── styles/                         # CSS/Stylesheets
│   └── views/                          # HTML templates
│
├── doc-server/                          # Backend Services
│   ├── MyCoop.WebApi/                  # Main Web API Project
│   │   ├── Controllers/                # API Controllers
│   │   ├── Services/                   # Business logic layer
│   │   ├── Models/                     # DTOs & view models
│   │   ├── Filters/                    # Auth & logging filters
│   │   ├── Helpers/                    # Utility classes
│   │   └── AppStart/                   # Configuration
│   │
│   ├── MyCoop/                         # Core Library
│   │   ├── Data/                       # EF entities
│   │   ├── Repositories/               # Data access
│   │   └── Configuration/              # Settings
│   │
│   ├── MyCoop.DocEditor/               # Document editing services
│   │   ├── DocService/                 # ONLYOFFICE integration
│   │   └── FileConverter2/             # Format conversion
│   │
│   └── ONLYOFFICE Online Editors/      # Third-party editor
│       ├── CoAuthoringService/         # Real-time collab
│       ├── SpellCheckerService/        # Spell checking
│       └── ServerComponents/           # Supporting services
│
└── README.md                            # This file
```

---

## System Capabilities

### User Management
```http
GET    /api/user              # List all users
GET    /api/user/{id}         # Get user details
GET    /api/user/current      # Get current user
POST   /api/user              # Create user
POST   /api/user/{id}         # Update user
DELETE /api/user/{id}         # Delete user
GET    /api/user/history      # Login activity
```

### Group Management
```http
GET    /api/group                          # List groups
GET    /api/group/{id}                     # Get group
POST   /api/group                          # Create group
POST   /api/group/{id}                     # Update group
DELETE /api/group/{id}                     # Delete group
POST   /api/group/{groupId}/user/{userId}  # Add user to group
```

### Document Templates
```http
GET    /api/document-template              # List templates
GET    /api/document-template/{id}         # Get template
POST   /api/document-template              # Upload template (multipart)
POST   /api/document-template/{id}         # Update template
DELETE /api/document-template/{id}         # Delete template
```

### Business Processes
```http
GET    /api/business-process               # List processes
GET    /api/business-process/{id}          # Get process
POST   /api/business-process               # Create process
POST   /api/business-process/{id}          # Update process
DELETE /api/business-process/{id}          # Delete process
GET    /api/business-process/csv           # Export to CSV
```

### Organizational Units
```http
GET    /api/orgunit                                # List org units
GET    /api/orgunit/{id}                           # Get org unit
POST   /api/orgunit                                # Create org unit
POST   /api/orgunit/{id}                           # Update org unit
DELETE /api/orgunit/{id}                           # Delete org unit
POST   /api/orgunit/{id}/user/{uid}/permission/{p} # Grant permission
```

---

## Getting Started

### Prerequisites

- Windows Server 2012+ or Windows 10+
- IIS 7.5 or higher
- . NET Framework 4.5+
- SQL Server 2012+ (Express or higher)
- Node.js 10+ (for ONLYOFFICE services)
- Visual Studio 2013+ or VS Code

### Installation Steps

#### 1. Clone the Repository
```bash
git clone https://github.com/MillerTom/Document-Management-Collaboration.git
cd Document-Management-Collaboration
```

#### 2. Database Setup
```sql
-- Create database
CREATE DATABASE mycoop;
GO

-- Update connection string in Web.config
-- doc-server/MyCoop.WebApi/MyCoop.WebApi/Web.config
<connectionStrings>
  <add name="CoopEntities" 
       connectionString="data source=YOUR_SERVER;initial catalog=mycoop;integrated security=True;..."
       providerName="System. Data.EntityClient" />
</connectionStrings>
```

#### 3. Backend Configuration
```bash
cd doc-server/MyCoop.WebApi

# Restore NuGet packages
nuget restore

# Build solution
msbuild MyCoop.WebApi.sln /p:Configuration=Release

# Configure IIS
# - Create new site pointing to:  doc-server/MyCoop.WebApi/MyCoop.WebApi
# - App Pool: . NET v4.0, Integrated Pipeline
# - Bindings: http://localhost:5000
```

#### 4. Frontend Configuration
```bash
cd doc-client

# No build required for AngularJS
# Configure API endpoint in scripts/resources/*. js if needed
# Point IIS or web server to doc-client directory
```

#### 5. ONLYOFFICE Setup
```bash
cd doc-server/ONLYOFFICE Online Editors

# Follow ReadMe. txt instructions
# Update settings. config with your license key
# Configure document service URL in Web.config
```

### 6. Launch Application

```bash
# Start IIS sites
# Navigate to: http://localhost:5000

# Default credentials (create via SQL):
# Admin: admin@example.com / yourpassword
```

---

## Security Features

### Implemented
- Custom authorization filter (`[CoopAuthorize]`)
- Role-based access control (4 permission levels)
- Activity logging and audit trails
- Session-based authentication
- SQL injection protection (EF parameterization)
- XSS protection (Angular built-in)

### Recommended Enhancements (Modernization Phase)
- Migrate to JWT/OAuth 2.0 tokens
- Implement HTTPS enforcement
- Add rate limiting on login endpoint
- Multi-factor authentication (MFA)
- Password complexity policies
- CORS configuration
- Security headers (CSP, X-Frame-Options)

---

## Database Schema

### Core Entities

**Users & Access**
- `User` - User accounts
- `Group` - User groups
- `UserGroup` - Many-to-many relationship
- `PermissionLevel` - Access levels (Reader, Contributor, Approver, Admin)
- `OrgUnitPermission` - Org-level permissions

**Organization**
- `OrgUnit` - Organizational units (hierarchy)
- `WorkspaceTemplate` - Document workspace templates
- `Component` - ISO 22301 components

**Documents**
- `DocumentTemplate` - Reusable document templates
- `DocumentTask` - Document-related tasks
- `Workflow` - Approval workflows
- `WorkflowState` - Workflow states

**Business Processes**
- `BusinessProcess` - Business continuity processes
- `BusinessProcessAttribute` - Custom attributes
- `AttributeType` - Attribute definitions
- `Incident` - Incident tracking

**Audit & Logging**
- `SysEvent` - System events log
- `UserActivity` - User activity tracking

---

## Roadmap & Modernization

This project is undergoing modernization to demonstrate full-stack expertise with cutting-edge technologies:

### Phase 1: Backend Modernization (In Progress)
- [ ] Migrate from . NET Framework 4.5 to **.NET 6/8**
- [ ] Upgrade Entity Framework 6 to **EF Core 8**
- [ ] Implement **JWT authentication** with refresh tokens
- [ ] Add **Swagger/OpenAPI** documentation
- [ ] Containerize with **Docker**
- [ ] Add **unit tests** (xUnit) - Target: 80% coverage
- [ ] Implement **CQRS pattern** with MediatR

### Phase 2: Frontend Modernization
- [ ] Migrate AngularJS to **React 18** or **Angular 17**
- [ ] Implement **TypeScript**
- [ ] Add **Redux/Zustand** for state management
- [ ] Modern build pipeline:  **Vite/Webpack**
- [ ] **Tailwind CSS** or Material-UI
- [ ] **React Query** for API state management

### Phase 3: Cloud & DevOps
- [ ] Deploy to **Azure App Service** / AWS
- [ ] **Azure SQL Database** / RDS
- [ ] **CI/CD pipeline** (GitHub Actions/Azure DevOps)
- [ ] **Azure Blob Storage** for documents
- [ ] **Application Insights** / CloudWatch monitoring
- [ ] **Kubernetes** orchestration (optional)

### Phase 4: Advanced Features
- [ ] **Real-time notifications** (SignalR/WebSockets)
- [ ] **Elasticsearch** for full-text search
- [ ] **Redis** caching layer
- [ ] **Microservices** architecture
- [ ] **GraphQL** API
- [ ] **Mobile app** (React Native/Flutter)

---

## API Documentation

API documentation is available via Swagger UI (after Phase 1 modernization):
```
http://localhost:5000/swagger
``

---

## Contributing

This is a personal portfolio project, but feedback and suggestions are welcome!

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit changes (`git commit -m 'Add amazing feature'`)
4. Push to branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

---

## License

This project is licensed under the MIT License - see [LICENSE](LICENSE) file for details.

**Third-Party Licenses:**
- ONLYOFFICE:  AGPL v3 (separate license required for commercial use)
- Aspose. Words: Commercial license (evaluation version included)

---

## About the Developer

**Tom Miller**
Full-Stack Software Engineer | . NET & Modern Web Specialist


