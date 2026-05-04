---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConvertDuctPlaceholders(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/8305d265-b824-98d7-2084-8a8eb0c49208.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConvertDuctPlaceholders Method

Converts a collection of duct placeholder elements into duct elements.

## Syntax (C#)
```csharp
public static ICollection<ElementId> ConvertDuctPlaceholders(
	Document document,
	ICollection<ElementId> placeholderIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **placeholderIds** (`System.Collections.Generic.ICollection < ElementId >`) - A collection of element IDs of duct placeholders.

## Returns
A collection of element IDs of ducts and fittings.

## Remarks
Once conversion succeeds, the duct placeholder elements are deleted.
 The new duct and fitting elements are created and connections are established.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element id set is empty.
 -or-
 The given element IDs (placeholderIds) are not duct placeholders.
 -or-
 The elements belong to different types of system.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

