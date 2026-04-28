---
kind: method
id: M:Autodesk.Revit.DB.SelectionFilterElement.RemoveSingle(Autodesk.Revit.DB.ElementId)
source: html/6fdfc521-9c3c-5a9a-a549-85df55967a51.htm
---
# Autodesk.Revit.DB.SelectionFilterElement.RemoveSingle Method

Removes a single ElementId from the filter's set.

## Syntax (C#)
```csharp
public void RemoveSingle(
	ElementId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.ElementId`) - The ElementId to remove.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Invalid ElementId
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

