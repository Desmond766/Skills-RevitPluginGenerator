---
kind: method
id: M:Autodesk.Revit.DB.SelectionFilterElement.RemoveSet(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/c08b7b0f-8a65-e0d0-107e-ee9a9cc54806.htm
---
# Autodesk.Revit.DB.SelectionFilterElement.RemoveSet Method

Removes a set of ElementIds from the filter's set.

## Syntax (C#)
```csharp
public int RemoveSet(
	ICollection<ElementId> ids
)
```

## Parameters
- **ids** (`System.Collections.Generic.ICollection < ElementId >`) - The set of ElementIds to remove.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

