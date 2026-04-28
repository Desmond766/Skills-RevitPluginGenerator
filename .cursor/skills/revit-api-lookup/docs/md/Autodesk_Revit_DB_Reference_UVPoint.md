---
kind: property
id: P:Autodesk.Revit.DB.Reference.UVPoint
source: html/25347c4e-62d5-a536-628f-f503fb55e246.htm
---
# Autodesk.Revit.DB.Reference.UVPoint Property

The UV parameters of the reference, if the reference contains a face.

## Syntax (C#)
```csharp
public UV UVPoint { get; }
```

## Remarks
This value is valid only for references of type REFERENCE_TYPE_SURFACE. 
It is Nothing nullptr a null reference ( Nothing in Visual Basic) for all other types.

