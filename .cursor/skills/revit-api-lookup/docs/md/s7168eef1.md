---
kind: property
id: P:Autodesk.Revit.DB.Electrical.AreaBasedLoadBoundaryLineData.TopLevelId
source: html/90187c6f-2765-840d-1bc1-909cebc9143d.htm
---
# Autodesk.Revit.DB.Electrical.AreaBasedLoadBoundaryLineData.TopLevelId Property

The top level id of the area based load boundary line.

## Syntax (C#)
```csharp
public ElementId TopLevelId { get; set; }
```

## Remarks
The top level's elevation cannot be lower than the bottom level.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The ElementId levelId cannot be used as the top level.
 The ElementId levelId is not a Level or it's elevation is lower than the bottom level's elevation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

