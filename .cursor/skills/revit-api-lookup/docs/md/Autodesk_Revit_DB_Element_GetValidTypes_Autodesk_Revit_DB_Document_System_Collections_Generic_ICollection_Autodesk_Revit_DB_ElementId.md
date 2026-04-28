---
kind: method
id: M:Autodesk.Revit.DB.Element.GetValidTypes(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 构件、图元、元素
source: html/43dc2992-0b0d-ca73-d63c-2ac829bf1a89.htm
---
# Autodesk.Revit.DB.Element.GetValidTypes Method

**中文**: 构件、图元、元素

Obtains a set of types that are valid for all given elements.

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetValidTypes(
	Document document,
	ICollection<ElementId> elementIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - A collection of element IDs.

## Returns
A set of element IDs of types that are valid for these elements or an empty set if any element cannot have a type assigned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when at least one of the elements does not exist in the document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

