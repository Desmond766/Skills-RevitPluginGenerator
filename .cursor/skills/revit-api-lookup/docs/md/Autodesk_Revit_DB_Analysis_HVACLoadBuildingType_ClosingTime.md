---
kind: property
id: P:Autodesk.Revit.DB.Analysis.HVACLoadBuildingType.ClosingTime
source: html/129e98fa-e1ad-64c1-67e1-1e8e0d1e999f.htm
---
# Autodesk.Revit.DB.Analysis.HVACLoadBuildingType.ClosingTime Property

The closing time of the building type.

## Syntax (C#)
```csharp
public string ClosingTime { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: It is not a valid time, can be something like "16:30" or "4:30 PM".
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

