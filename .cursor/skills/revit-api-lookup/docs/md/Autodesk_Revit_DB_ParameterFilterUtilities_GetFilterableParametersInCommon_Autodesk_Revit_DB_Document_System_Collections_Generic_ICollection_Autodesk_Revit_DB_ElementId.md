---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterUtilities.GetFilterableParametersInCommon(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/7ea624c7-2c0d-c9bb-3b2c-1ac798cf6606.htm
---
# Autodesk.Revit.DB.ParameterFilterUtilities.GetFilterableParametersInCommon Method

Returns the filterable parameters common to the given categories.

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetFilterableParametersInCommon(
	Document aDoc,
	ICollection<ElementId> categories
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document containing the categories and parameters to query.
- **categories** (`System.Collections.Generic.ICollection < ElementId >`) - The categories for which to determine the common parameters.

## Returns
The set of filterable parameters common to the given categories.

## Remarks
A filterable category in Revit has a set of filterable parameters.
 The filterable parameters common to a set of categories is the
 intersection of all these filterable parameter sets. This set defines the set of parameters that may be used to define
 a rule on a ParameterFilterElement with a certain set of categories.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

