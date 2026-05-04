---
kind: property
id: P:Autodesk.Revit.DB.Structure.LoadCase.NatureId
source: html/afb018a6-fe54-38af-1fbd-f6ff15c7ad8f.htm
---
# Autodesk.Revit.DB.Structure.LoadCase.NatureId Property

The nature ID of the load case.

## Syntax (C#)
```csharp
public ElementId NatureId { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: the natureId does not refer to LoadNature element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

