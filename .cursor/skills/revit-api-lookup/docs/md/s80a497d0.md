---
kind: property
id: P:Autodesk.Revit.DB.Electrical.AreaBasedLoadBoundaryLineData.BottomLevelId
source: html/e9807384-17dd-09c0-c03b-d9ff2bfbe8c0.htm
---
# Autodesk.Revit.DB.Electrical.AreaBasedLoadBoundaryLineData.BottomLevelId Property

The bottom level id of the area based load boundary line.

## Syntax (C#)
```csharp
public ElementId BottomLevelId { get; set; }
```

## Remarks
The bottom level's elevation cannot be higher than the top level.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The ElementId levelId cannot be used as the bottom level.
 The ElementId levelId is not a Level or it's elevation is higher than the top level's elevation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

