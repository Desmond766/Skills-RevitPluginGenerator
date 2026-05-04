---
kind: property
id: P:Autodesk.Revit.DB.Analysis.HVACLoadBuildingType.OpeningTime
source: html/42598222-0828-343b-2caa-957ce41e7984.htm
---
# Autodesk.Revit.DB.Analysis.HVACLoadBuildingType.OpeningTime Property

The opening time of the building type.

## Syntax (C#)
```csharp
public string OpeningTime { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: It is not a valid time, can be something like "16:30" or "4:30 PM".
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

