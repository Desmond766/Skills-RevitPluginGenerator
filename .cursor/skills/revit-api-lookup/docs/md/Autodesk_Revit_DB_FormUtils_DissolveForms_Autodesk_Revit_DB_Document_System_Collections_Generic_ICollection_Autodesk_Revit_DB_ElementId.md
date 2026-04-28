---
kind: method
id: M:Autodesk.Revit.DB.FormUtils.DissolveForms(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/2dc2425a-b4d4-f514-8497-4fe4c1f4bbfa.htm
---
# Autodesk.Revit.DB.FormUtils.DissolveForms Method

Dissolves a collection of form elements into their defining elements.

## Syntax (C#)
```csharp
public static ICollection<ElementId> DissolveForms(
	Document ADoc,
	ICollection<ElementId> elements
)
```

## Parameters
- **ADoc** (`Autodesk.Revit.DB.Document`) - The document
- **elements** (`System.Collections.Generic.ICollection < ElementId >`) - A collection of element IDs of Forms and GeomCombinations that contain Forms that will be dissolved.

## Returns
A collection of curve element ids from the profiles and paths of the dissolved forms.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The elements do not include Forms that can be dissolved.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

