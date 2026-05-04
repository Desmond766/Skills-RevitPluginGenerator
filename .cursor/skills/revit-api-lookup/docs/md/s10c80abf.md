---
kind: method
id: M:Autodesk.Revit.DB.FormUtils.CanBeDissolved(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/a098da05-374c-d25d-a12f-5fd68c5e3ce4.htm
---
# Autodesk.Revit.DB.FormUtils.CanBeDissolved Method

Validates that input contains one or more form elements or geom combinations containing form elements.

## Syntax (C#)
```csharp
public static bool CanBeDissolved(
	Document ADoc,
	ICollection<ElementId> elements
)
```

## Parameters
- **ADoc** (`Autodesk.Revit.DB.Document`) - The document.
- **elements** (`System.Collections.Generic.ICollection < ElementId >`) - A collection of elements.

## Returns
True if inputs contain one or more form elements. Non-form element inputs are ignored.
 False if none of the inputs are form elements or do not contain form elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

