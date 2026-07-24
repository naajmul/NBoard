# NBoard Installation & Deployment Guide

## Creating the Installer (.MSI)

### Prerequisites
1. **WiX Toolset 3.14** - [Download](https://github.com/wixtoolset/wix3/releases)
2. **Visual Studio 2022** with WiX extension
3. **NBoard built in Release mode**

### Step 1: Install WiX Toolset

```bash
# Download WiX 3.14
https://github.com/wixtoolset/wix3/releases/download/wix314rtm/wix314.exe

# Run installer and follow wizard
```

### Step 2: Create WiX Project

1. In Visual Studio, create new **WiX Setup Project**
2. Name it: `NBoard.Installer`

### Step 3: Configure Product.wxs

Create `NBoard.Installer/Product.wxs`:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<Wix xmlns="http://schemas.microsoft.com/wix/2006/wi">
    <Product Id="*" Name="NBoard" Language="1033" Version="1.0.0.0" 
             Manufacturer="Naajmul Hassan" UpgradeCode="12345678-1234-1234-1234-123456789012">
        
        <Package InstallerVersion="200" Compressed="yes" 
                 InstallScope="perMachine" Description="NBoard - Professional Whiteboard"/>
        
        <MajorUpgrade DowngradeErrorMessage="A newer version of NBoard is already installed." />
        
        <MediaTemplate EmbedCab="yes" />
        
        <Feature Id="ProductFeature" Title="NBoard" Level="1">
            <ComponentRef Id="MainExecutable" />
            <ComponentRef Id="DesktopShortcut" />
            <ComponentRef Id="StartMenuShortcut" />
        </Feature>
        
        <InstallExecuteSequence>
            <RemoveExistingProducts Before="InstallInitialize" />
        </InstallExecuteSequence>
        
        <UI>
            <UIRef Id="WixUI_InstallDir" />
        </UI>
    </Product>
    
    <Fragment>
        <Directory Id="TARGETDIR" Name="SourceDir">
            <Directory Id="ProgramFilesFolder">
                <Directory Id="INSTALLFOLDER" Name="NBoard" />
            </Directory>
            <Directory Id="DesktopFolder" />
            <Directory Id="ProgramMenuFolder">
                <Directory Id="ApplicationProgramsFolder" Name="NBoard" />
            </Directory>
        </Directory>
    </Fragment>
    
    <Fragment>
        <ComponentGroup Id="ProductComponents" Directory="INSTALLFOLDER">
            <!-- Main executable -->
            <Component Id="MainExecutable">
                <File Id="NBoard.exe" Source=".\\bin\\Release\\net6.0-windows\\NBoard.exe" />
            </Component>
            
            <!-- Desktop Shortcut -->
            <Component Id="DesktopShortcut" Directory="DesktopFolder">
                <Shortcut Id="DesktopShortcut" Name="NBoard" 
                         Target="[INSTALLFOLDER]NBoard.exe" 
                         WorkingDirectory="INSTALLFOLDER" />
                <RegistryValue Root="HKCU" Key="Software\\NBoard" Name="installed" 
                              Value="1" Type="integer" KeyPath="yes" />
            </Component>
            
            <!-- Start Menu Shortcut -->
            <Component Id="StartMenuShortcut" Directory="ApplicationProgramsFolder">
                <Shortcut Id="StartMenuShortcut" Name="NBoard" 
                         Target="[INSTALLFOLDER]NBoard.exe" 
                         WorkingDirectory="INSTALLFOLDER" />
                <RemoveFolder Id="ApplicationProgramsFolder" On="uninstall" />
                <RegistryValue Root="HKCU" Key="Software\\NBoard" Name="startmenu" 
                              Value="1" Type="integer" KeyPath="yes" />
            </Component>
        </ComponentGroup>
    </Fragment>
</Wix>
```

### Step 4: Build the Installer

```bash
# In Visual Studio
# Right-click NBoard.Installer → Build

# Or via command line
candle.exe Product.wxs
light.exe Product.wixobj -out NBoard-Setup.msi
```

### Step 5: Output Location

The installer will be created at:
```
NBoard.Installer\bin\Release\NBoard-Setup.msi
```

---

## Installation Methods

### Method 1: GUI Installer (Recommended)

```bash
# Double-click NBoard-Setup.msi
# Follow the wizard
# Desktop shortcut created automatically
```

### Method 2: Silent Installation

```bash
# Command line
msiexec /i NBoard-Setup.msi /quiet

# With custom install directory
msiexec /i NBoard-Setup.msi /quiet INSTALLFOLDER="C:\Program Files\NBoard\"
```

### Method 3: Unattended Installation

```bash
# Create log file
msiexec /i NBoard-Setup.msi /quiet /l*v install.log
```

---

## Desktop Shortcut Details

### Automatic Creation
- Location: `C:\Users\[Username]\Desktop\NBoard.lnk`
- Target: `C:\Program Files\NBoard\NBoard.exe`
- Start Menu: `C:\Users\[Username]\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\NBoard\NBoard.lnk`

### Icon
- Uses `NBoard.ico` embedded in executable
- 256x256 pixels (high-quality)
- Professional blue design matching application theme

---

## After Installation

### User Folder Structure
```
C:\Users\[Username]\Documents\NBoard\
├── [document-id-1].wbd
├── [document-id-2].wbd
└── ...

C:\Users\[Username]\AppData\Local\NBoard\
├── settings.json
└── cache/
```

### Registry Entries
```
HKEY_CURRENT_USER\Software\NBoard
├── InstallPath: C:\Program Files\NBoard\
├── Version: 1.0.0
└── StartTime: [timestamp]
```

---

## Uninstallation

### Via Control Panel
1. Open **Control Panel**
2. Go to **Programs** → **Programs and Features**
3. Find **NBoard**
4. Click **Uninstall**
5. Follow wizard
6. Desktop shortcut removed automatically

### Via Command Line
```bash
msiexec /x NBoard-Setup.msi /quiet
```

### User Documents
- User documents in `C:\Users\[Username]\Documents\NBoard\` are **NOT** deleted on uninstall
- Delete manually if needed

---

## Troubleshooting

### Problem: "NBoard.exe not found" during build
**Solution:** Ensure you built the project in Release mode first
```bash
dotnet build -c Release
```

### Problem: WiX Toolset not found
**Solution:** Install WiX 3.14 from [GitHub Releases](https://github.com/wixtoolset/wix3/releases)

### Problem: Installer won't run
**Solution:** Check Windows Installer is enabled
```bash
msiexec /regserver
```

### Problem: Shortcut not created
**Solution:** Run installer with administrator privileges

---

## Distribution

### GitHub Releases
1. Build the .msi file
2. Go to GitHub → NBoard → Releases
3. Create new release: `v1.0.0`
4. Upload `NBoard-Setup.msi`
5. Add description and release notes

### Download Link
```
https://github.com/naajmul/NBoard/releases/download/v1.0.0/NBoard-Setup.msi
```

---

## System Requirements

- **OS:** Windows 10 or later (x64)
- **Runtime:** .NET 6.0 Desktop Runtime
- **Storage:** ~200 MB
- **RAM:** 512 MB minimum

---

**Next Steps:**
1. ✅ Build Release version
2. ✅ Create WiX installer project
3. ✅ Build .msi file
4. ✅ Test installation
5. ✅ Upload to GitHub Releases
6. ✅ Share with users!