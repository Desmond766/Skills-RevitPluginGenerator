---
kind: property
id: P:Autodesk.Revit.DB.Analysis.EnergyDataSettings.GroundPlane
source: html/3a6a5942-1fd7-cd1c-306b-c582da4f2abf.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.GroundPlane Property

Id of level which represents ground level.

## Syntax (C#)
```csharp
public ElementId GroundPlane { get; set; }
```

## Remarks
The ground plane defines what is above and below ground for Conceptual Energy Analysis.
 The ground plane can optionally used for the rendering cast shadows.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The input element is not a level or invalidElementId.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

