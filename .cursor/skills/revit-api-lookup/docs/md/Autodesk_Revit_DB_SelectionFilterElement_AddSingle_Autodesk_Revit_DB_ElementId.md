---
kind: method
id: M:Autodesk.Revit.DB.SelectionFilterElement.AddSingle(Autodesk.Revit.DB.ElementId)
source: html/c8853934-1e21-98a7-0aa3-44bd2dd6bfd6.htm
---
# Autodesk.Revit.DB.SelectionFilterElement.AddSingle Method

Adds a single ElementId to the filter's set.

## Syntax (C#)
```csharp
public void AddSingle(
	ElementId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.ElementId`) - The ElementId to add.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Invalid ElementId
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

