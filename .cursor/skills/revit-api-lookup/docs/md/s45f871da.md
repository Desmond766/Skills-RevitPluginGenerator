---
kind: method
id: M:Autodesk.Revit.DB.Element.IsValidType(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.ElementId)
zh: 构件、图元、元素
source: html/dec7e1c1-c16b-f159-7e56-6e654a5110e2.htm
---
# Autodesk.Revit.DB.Element.IsValidType Method

**中文**: 构件、图元、元素

Checks if given type is valid for the set of elements.

## Syntax (C#)
```csharp
public static bool IsValidType(
	Document document,
	ICollection<ElementId> elementIds,
	ElementId typeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - A collection of element IDs.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the type to check.

## Returns
True if all elements can have a type assigned and this type is valid for all elements, false otherwise.

## Remarks
A type is valid for the set of elements if it is valid for each and every element in the set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when at least one of the elements does not exist in the document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

