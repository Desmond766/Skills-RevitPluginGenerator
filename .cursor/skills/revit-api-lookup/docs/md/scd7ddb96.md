---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterUtilities.GetInapplicableParameters(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId})
source: html/5b7a1f72-6095-4137-9838-a7b6564624f4.htm
---
# Autodesk.Revit.DB.ParameterFilterUtilities.GetInapplicableParameters Method

Returns the parameters that are not among the set of filterable
 parameters common to the given categories.

## Syntax (C#)
```csharp
public static IList<ElementId> GetInapplicableParameters(
	Document aDoc,
	ICollection<ElementId> categories,
	IList<ElementId> parameters
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document containing the categories and parameters to query.
- **categories** (`System.Collections.Generic.ICollection < ElementId >`) - The categories that define the set of possibly filterable parameters.
- **parameters** (`System.Collections.Generic.IList < ElementId >`) - The parameters desired for use in a parameter filter.

## Returns
A list of parameters from the given array that are not valid
 for use in a parameter filter with the given categories.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

