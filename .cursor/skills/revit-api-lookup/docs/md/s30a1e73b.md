---
kind: property
id: P:Autodesk.Revit.DB.TransmissionData.IsTransmitted
source: html/63f74ea4-079d-425a-cab6-427d7ea4f816.htm
---
# Autodesk.Revit.DB.TransmissionData.IsTransmitted Property

Determines whether this file has been transmitted or not.

## Syntax (C#)
```csharp
public bool IsTransmitted { get; set; }
```

## Remarks
"Transmitted" files have been moved from one place to another and
 are considered to be in a not-final state. Revit will read the
 TransmissionData on file open and overwrite any data stored in the
 external file reference elements themselves.

