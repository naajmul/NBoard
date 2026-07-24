# NBoard - Quick Setup Guide

## Installation Instructions

### Option 1: Download and Install (Easiest)
1. Download `NBoard-Setup.msi` from Releases
2. Double-click the installer
3. Follow the installation wizard
4. Click "Finish" - NBoard will be installed with desktop shortcut
5. Double-click the NBoard icon on your desktop to launch

### Option 2: Build from Source

#### Prerequisites
- Windows 10 or later
- Visual Studio 2022 Community (Free) - [Download](https://visualstudio.microsoft.com/vs/community/)
- .NET 6.0 or higher

#### Steps

1. **Clone the Repository**
   ```bash
   git clone https://github.com/naajmul/NBoard.git
   cd NBoard
   ```

2. **Open in Visual Studio**
   - Double-click `NBoard.sln`
   - Wait for Visual Studio to load

3. **Install Dependencies**
   ```bash
   dotnet restore
   ```

4. **Build the Project**
   ```bash
   dotnet build -c Release
   ```

5. **Run the Application**
   ```bash
   dotnet run
   ```

### Option 3: Run Compiled Executable

1. Navigate to `bin/Release/net6.0-windows/`
2. Double-click `NBoard.exe`
3. (Optional) Create shortcut on desktop:
   - Right-click `NBoard.exe` → Send to → Desktop (create shortcut)
   - Rename to "NBoard"
   - Right-click → Properties → Change Icon (optional)

---

## Desktop Shortcut

### Automatic (via Installer)
- The MSI installer automatically creates a desktop shortcut
- Named: **NBoard**
- Located in: `Desktop`

### Manual Creation
1. Find `NBoard.exe` in the installation folder
2. Right-click → "Send to" → "Desktop (create shortcut)"
3. Right-click shortcut → "Rename" → Type "NBoard"
4. Optional: Right-click → Properties → Advanced → Run as Administrator (if needed)

---

## Files & Folder Structure

### Installation Folder (Windows)
```
C:\Program Files\NBoard\
├── NBoard.exe
├── NBoard.dll (and dependencies)
└── Resources/
    └── Icons/
```

### Document Folder
```
C:\Users\[YourUsername]\Documents\NBoard\
├── [document-id].wbd
├── [document-id].wbd
└── ... (your saved documents)
```

---

## First Launch

1. **Double-click NBoard on Desktop** or from Start Menu
2. **Welcome Screen appears** with options:
   - ✅ Create New Document
   - ✅ Open Recent Documents
   - ✅ Open File
   - ✅ Settings

3. **Click "Create New Document"** to start drawing

---

## Keyboard Shortcuts

| Action | Shortcut |
|--------|----------|
| New Document | Ctrl+N |
| Open Document | Ctrl+O |
| Save Document | Ctrl+S |
| Undo | Ctrl+Z |
| Redo | Ctrl+Y |
| Export | Ctrl+E |
| Clear All | Delete |

---

## Auto-Save Feature

✅ NBoard automatically saves your work every **30 seconds**
- No manual save needed
- All documents saved in: `C:\Users\[YourUsername]\Documents\NBoard\`
- Format: `.wbd` (proprietary JSON-based format)

---

## Uninstall

### Windows:
1. Go to **Control Panel** → **Programs** → **Programs and Features**
2. Find **NBoard**
3. Click **Uninstall**
4. Follow the uninstall wizard

---

## Troubleshooting

### Problem: "NBoard.exe not found"
- Solution: Download the installer from Releases, or rebuild from source

### Problem: Application won't start
- Solution: Install .NET 6.0 Runtime: [Download](https://dotnet.microsoft.com/download/dotnet/6.0)

### Problem: Shortcut not working
- Solution: Delete shortcut and recreate manually following steps above

---

## Getting Help

- 📖 Check [README.md](../README.md) for features
- 🐛 Report bugs: [Create an Issue](https://github.com/naajmul/NBoard/issues)
- 💬 Ask questions: [Discussions](https://github.com/naajmul/NBoard/discussions)

---

**Enjoy NBoard! Happy Drawing! 🎨**