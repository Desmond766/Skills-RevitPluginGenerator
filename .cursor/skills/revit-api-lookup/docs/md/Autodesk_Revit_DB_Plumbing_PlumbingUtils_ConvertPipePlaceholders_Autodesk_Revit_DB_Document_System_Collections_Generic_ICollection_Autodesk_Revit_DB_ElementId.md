---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PlumbingUtils.ConvertPipePlaceholders(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/de0f8319-1219-c564-c06c-bc256c0ed9b2.htm
---
# Autodesk.Revit.DB.Plumbing.PlumbingUtils.ConvertPipePlaceholders Method

Converts a collection of pipe placeholder elements into pipe elements.

## Syntax (C#)
```csharp
public static ICollection<ElementId> ConvertPipePlaceholders(
	Document document,
	ICollection<ElementId> placeholderIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **placeholderIds** (`System.Collections.Generic.ICollection < ElementId >`) - A collection of element IDs of pipe placeholders.

## Returns
A collection of element IDs of pipe and fitting.

## Remarks
Once conversion succeeds, the pipe placeholder elements are deleted.
 The new pipe and fitting elements are created and connections are established.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element id set is empty.
 -or-
 The given element ids (placeholderIds) are not pipe placeholders.
 -or-
 The elements belong to different types of system.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

