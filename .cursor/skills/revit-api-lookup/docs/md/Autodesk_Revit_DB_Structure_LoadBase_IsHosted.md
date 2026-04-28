---
kind: property
id: P:Autodesk.Revit.DB.Structure.LoadBase.IsHosted
source: html/76965c6d-473a-9ad9-8a72-baa7a47b055a.htm
---
# Autodesk.Revit.DB.Structure.LoadBase.IsHosted Property

Indicates if the Load is hosted or non-hosted.

## Syntax (C#)
```csharp
public bool IsHosted { get; }
```

## Remarks
True is returned when load is hosted. False is returned load is non-hosted.
 To determine if load is hosted HostElementId property or
 [!:Autodesk::Revit::DB::Structure::LoadBase::HostElement] property may also be used.

