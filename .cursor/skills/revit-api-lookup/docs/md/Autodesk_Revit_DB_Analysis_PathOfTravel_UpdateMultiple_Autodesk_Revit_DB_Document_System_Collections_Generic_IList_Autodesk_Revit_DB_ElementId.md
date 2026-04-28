---
kind: method
id: M:Autodesk.Revit.DB.Analysis.PathOfTravel.UpdateMultiple(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId})
source: html/2fba2f22-8d88-8b2c-c75e-8908223ec20c.htm
---
# Autodesk.Revit.DB.Analysis.PathOfTravel.UpdateMultiple Method

Updates the specified paths of travel by recalculating each path using their original start and end points.

## Syntax (C#)
```csharp
public static int UpdateMultiple(
	Document adoc,
	IList<ElementId> elementsToUpdate
)
```

## Parameters
- **adoc** (`Autodesk.Revit.DB.Document`) - Document of elements to be updated.
- **elementsToUpdate** (`System.Collections.Generic.IList < ElementId >`) - The list of ElementId of the paths to update.

## Returns
number of successfully updated elements

## Remarks
For unsuccessfully updated elements, Revit will post warnings.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This functionality is not available in Revit LT.

