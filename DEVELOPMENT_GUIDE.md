# Development Setup Guide

## For Developers: Building NBoard from Source

### Prerequisites

1. **Visual Studio 2022** (Community Edition - Free)
   - Download: https://visualstudio.microsoft.com/vs/community/
   - Include: .NET Desktop Development

2. **.NET 6.0 SDK or higher**
   - Download: https://dotnet.microsoft.com/download/dotnet
   - Choose: "SDK" (not Runtime)

3. **Git** (for cloning repo)
   - Download: https://git-scm.com/

4. **WiX Toolset 3.14** (for creating installer)
   - Download: https://github.com/wixtoolset/wix3/releases
   - Optional for development, required for installer

### Installation Steps

#### Step 1: Clone Repository

```bash
git clone https://github.com/naajmul/NBoard.git
cd NBoard
```

#### Step 2: Open in Visual Studio

```bash
# Option A: Command line
start NBoard.sln

# Option B: Double-click NBoard.sln file
```

#### Step 3: Restore Dependencies

Visual Studio automatically restores NuGet packages. Or manually:

```bash
dotnet restore
```

Packages:
- `Newtonsoft.Json` (v13.0.3) - JSON serialization
- `itext7` (v8.0.0) - PDF export

#### Step 4: Build Project

**Debug Build** (for development):
```bash
dotnet build
```

**Release Build** (for distribution):
```bash
dotnet build -c Release
```

Or in Visual Studio:
- Build → Build Solution (Ctrl+Shift+B)
- Or: Build → Build NBoard

#### Step 5: Run Application

**In Visual Studio:**
- Press **F5** to start debugging
- Or: Debug → Start Debugging

**From Command Line:**
```bash
# Debug
dotnet run

# Release
dotnet run -c Release
```

### Project Structure

```
NBoard/
├── Models/                    # Data models
│   ├── Document.cs           # Document and Page models
│   └── DrawingAction.cs      # Drawing actions and tool types
│
├── Services/                  # Business logic
│   ├── DocumentManager.cs    # Save/load documents
│   ├── ExportService.cs      # Export to PDF, SVG, JSON, PNG
│   └── AutoSaveService.cs    # Auto-save timer
│
├── Views/                     # UI (XAML)
│   ├── StartScreen.xaml      # Welcome/home screen
│   ├── StartScreen.xaml.cs   # Welcome screen logic
│   ├── CanvasWindow.xaml     # Main drawing canvas
│   └── CanvasWindow.xaml.cs  # Canvas logic
│
├── Properties/
│   └── AssemblyInfo.cs       # Version info
│
├── Resources/
│   ├── NBoard.ico            # Application icon
│   └── NBoard.svg            # Vector logo
│
├── App.xaml                  # Application resources/styles
├── App.xaml.cs               # Application entry point
├── App.config                # Configuration settings
├── NBoard.csproj             # Project file
├── README.md                 # Features & overview
├── QUICKSTART.md             # Quick start guide
├── SETUP_GUIDE.md            # Installation guide
├── INSTALLER_GUIDE.md        # Installer creation
├── TROUBLESHOOTING.md        # Troubleshooting
└── build.bat                 # Windows build script
```

### Key Files to Modify

#### Models (Data)
- **Document.cs** - Add document properties
- **DrawingAction.cs** - Add new tool types

#### Services (Logic)
- **DocumentManager.cs** - File I/O operations
- **ExportService.cs** - Export formats
- **AutoSaveService.cs** - Auto-save timer

#### Views (UI)
- **StartScreen.xaml** - Welcome screen layout
- **CanvasWindow.xaml** - Canvas toolbar and menu
- **Code-behind files** - Event handlers

### Building Specific Configurations

#### Debug Build (Development)
```bash
dotnet build -c Debug
```
- Slower execution
- Full debugging symbols
- Easier to debug
- Output: `bin/Debug/net6.0-windows/`

#### Release Build (Production)
```bash
dotnet build -c Release
```
- Optimized code
- Smaller file size
- Faster execution
- Output: `bin/Release/net6.0-windows/`

### Publishing Build

```bash
# Self-contained (includes .NET runtime)
dotnet publish -c Release -p:PublishSingleFile=true --self-contained

# Framework-dependent (requires .NET installed)
dotnet publish -c Release
```

### Creating Installer

#### Prerequisites
- .NET 6.0 SDK installed
- WiX Toolset 3.14 installed
- Visual Studio Build Tools

#### Steps

1. Build Release version:
   ```bash
   dotnet build -c Release
   ```

2. Create WiX project (see INSTALLER_GUIDE.md)

3. Build installer:
   ```bash
   # In NBoard.Installer directory
   candle.exe Product.wxs
   light.exe Product.wixobj -out NBoard-Setup.msi
   ```

### Running Tests

```bash
# Run all tests
dotnet test

# Run specific test
dotnet test --filter TestClass=CanvasTests

# With verbose output
dotnet test -v diagnostic
```

### Code Style & Standards

#### Naming Conventions
- **Classes:** PascalCase (e.g., `DocumentManager`)
- **Methods:** PascalCase (e.g., `SaveDocument`)
- **Properties:** PascalCase (e.g., `CurrentColor`)
- **Variables:** camelCase (e.g., `_currentTool`)
- **Constants:** UPPER_SNAKE_CASE (e.g., `MAX_UNDO_STACK`)

#### File Organization
```csharp
// 1. Using statements
using System;
using System.Collections.Generic;
using System.Windows;

// 2. Namespace
namespace NBoard.Services
{
    // 3. Class definition
    public class MyClass
    {
        // 4. Fields
        private string _field;
        
        // 5. Properties
        public string Property { get; set; }
        
        // 6. Constructor
        public MyClass() { }
        
        // 7. Methods (public first, then private)
        public void PublicMethod() { }
        private void PrivateMethod() { }
    }
}
```

### Debugging Tips

#### Set Breakpoints
1. Click on line number in code editor
2. Red dot appears
3. Run with F5
4. Execution pauses at breakpoint

#### Inspect Variables
- Hover over variable to see value
- Use Watch window (Debug → Windows → Watch)
- Use Immediate window (Debug → Windows → Immediate)

#### Debug Output
```csharp
// Print to debug console
Debug.WriteLine($"Message: {variable}");

// In Output window: Debug → Windows → Output
```

### Common Issues

#### NuGet Packages Won't Restore
```bash
# Clear NuGet cache
dotnet nuget locals all --clear

# Restore again
dotnet restore
```

#### Build Failed: Missing Dependencies
```bash
# Update Visual Studio
# Ensure .NET 6.0 SDK installed
dotnet --version
```

#### XAML Designer Won't Load
- Clean solution: Build → Clean Solution
- Rebuild: Build → Rebuild Solution
- Restart Visual Studio

### Performance Optimization

#### Reduce Startup Time
- Minimize auto-save interval
- Lazy-load services
- Pre-compile XAML

#### Reduce Memory Usage
- Limit undo/redo stack size
- Clear old drawing strokes
- Use object pooling for frequently created objects

#### Improve Canvas Performance
- Use hardware acceleration
- Batch drawing operations
- Limit stroke count per page

### Git Workflow

```bash
# Create feature branch
git checkout -b feature/your-feature

# Make changes
git add .
git commit -m "Add feature description"

# Push to GitHub
git push origin feature/your-feature

# Create Pull Request on GitHub
# After review and approval, merge to main
```

### Release Checklist

- [ ] Increment version in `.csproj`
- [ ] Update `README.md` with new features
- [ ] Build Release version
- [ ] Test application thoroughly
- [ ] Create/update installer
- [ ] Test installer on clean Windows system
- [ ] Create GitHub release
- [ ] Upload .msi to release
- [ ] Update documentation

---

**Happy Coding! 🎉**