---
kind: method
id: M:Autodesk.Revit.DB.Element.CanHaveTypeAssigned(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 构件、图元、元素
source: html/3cfda085-5bba-a1d2-1a40-0f2872a6ef22.htm
---
# Autodesk.Revit.DB.Element.CanHaveTypeAssigned Method

**中文**: 构件、图元、元素

Checks if all elements in the set can have a type assigned.

## Syntax (C#)
```csharp
public static bool CanHaveTypeAssigned(
	Document document,
	ICollection<ElementId> elementIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - A collection of element IDs.

## Returns
True if all elements in the set can have a type assigned, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when at least one of the elements does not exist in the document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

