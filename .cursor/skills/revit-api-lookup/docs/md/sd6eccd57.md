---
kind: method
id: M:Autodesk.Revit.DB.Analysis.PathOfTravel.UpdateMultiple(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId},System.Collections.Generic.IList{Autodesk.Revit.DB.Analysis.PathOfTravelCalculationStatus}@)
source: html/680761c8-b660-6f65-f259-8141eb4c2c57.htm
---
# Autodesk.Revit.DB.Analysis.PathOfTravel.UpdateMultiple Method

Updates the specified paths of travel by recalculating each path using their original start and end points and provides creation result statuses.

## Syntax (C#)
```csharp
public static int UpdateMultiple(
	Document adoc,
	IList<ElementId> elementsToUpdate,
	out IList<PathOfTravelCalculationStatus> resultStatus
)
```

## Parameters
- **adoc** (`Autodesk.Revit.DB.Document`) - Document of elements to be updated.
- **elementsToUpdate** (`System.Collections.Generic.IList < ElementId >`) - The list of ElementId of the paths to update.
- **resultStatus** (`System.Collections.Generic.IList < PathOfTravelCalculationStatus > %`) - Result statuses of each path of travel creation.
 The order of statuses corresponds to the order of elements in the array passed to the function.

## Returns
number of successfully updated elements

## Remarks
For unsuccessfully updated elements, Revit will post warnings.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This functionality is not available in Revit LT.

