---
kind: property
id: P:Autodesk.Revit.DB.Level.Elevation
zh: 标高、高程
source: html/b5d48a18-4aa9-7457-7a6a-6d4966eaf77f.htm
---
# Autodesk.Revit.DB.Level.Elevation Property

**中文**: 标高、高程

Retrieves or changes the elevation above or below the ground level.

## Syntax (C#)
```csharp
public double Elevation { get; set; }
```

## Remarks
This property retrieves or changes the elevation above or below the ground level of the
 project. If the Elevation Base parameter is set to Project, the elevation is relative to project origin.
 If the Elevation Base parameter is set to Shared, the elevation is relative to shared origin which can
 be changed by relocate operation. The value is given in decimal feet.

