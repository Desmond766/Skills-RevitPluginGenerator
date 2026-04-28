---
kind: method
id: M:Autodesk.Revit.DB.SelectionFilterElement.Contains(Autodesk.Revit.DB.ElementId)
source: html/cae581e6-0aa0-10bd-827a-14392cacaf79.htm
---
# Autodesk.Revit.DB.SelectionFilterElement.Contains Method

Returns true if the given ElementId is a member of this filter's set.

## Syntax (C#)
```csharp
public bool Contains(
	ElementId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.ElementId`) - The ElementId to look for.

## Returns
True if the given ElementId is a member of the filter, otherwise false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Invalid ElementId
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

