---
kind: method
id: M:Autodesk.Revit.DB.Structure.LoadCase.IsLoadNatureId(Autodesk.Revit.DB.ElementId)
source: html/1cd24418-aece-f775-bc89-80027fed26d6.htm
---
# Autodesk.Revit.DB.Structure.LoadCase.IsLoadNatureId Method

Checks whether provided element ID refer to LoadNature element.

## Syntax (C#)
```csharp
public bool IsLoadNatureId(
	ElementId natureId
)
```

## Parameters
- **natureId** (`Autodesk.Revit.DB.ElementId`) - The ID to check.

## Returns
True if the ID refers to LoadNature element, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

