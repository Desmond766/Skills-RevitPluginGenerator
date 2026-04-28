---
kind: method
id: M:Autodesk.Revit.DB.FormUtils.DissolveForms(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId}@)
source: html/4ea56c0f-d56f-ecf3-62fc-9bdc8d7a0d2e.htm
---
# Autodesk.Revit.DB.FormUtils.DissolveForms Method

Dissolves a collection of form elements into their defining elements.

## Syntax (C#)
```csharp
public static ICollection<ElementId> DissolveForms(
	Document ADoc,
	ICollection<ElementId> elements,
	out ICollection<ElementId> ProfileOriginPointSet
)
```

## Parameters
- **ADoc** (`Autodesk.Revit.DB.Document`) - The document
- **elements** (`System.Collections.Generic.ICollection < ElementId >`) - A collection of element IDs of Forms and GeomCombinations that contain Forms that will be dissolved.
- **ProfileOriginPointSet** (`System.Collections.Generic.ICollection < ElementId > %`) - A collection of the point element ids that represent the 'origin' of the profiles

## Returns
A collection of curve element ids from the profiles and paths of the dissolved forms.

## Remarks
Profile origin points define the workplane of form profiles and paths and their curves.
 The profile origin point represents a coordinate system with an origin (reference point) which
 can be manipulated to move the curves of a profile together as a unit after dissolve.
 Profile origin points may themselves be constrained to other parts of the model or parts of the form,
 based on how the form was created/constructed. This is done through the reference point hosting
 mechanism.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The elements do not include Forms that can be dissolved.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

