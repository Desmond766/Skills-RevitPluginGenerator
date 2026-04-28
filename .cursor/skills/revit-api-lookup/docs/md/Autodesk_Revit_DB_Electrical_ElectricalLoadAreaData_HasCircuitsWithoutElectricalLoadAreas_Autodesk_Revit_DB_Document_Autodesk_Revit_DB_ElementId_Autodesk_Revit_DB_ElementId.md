---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalLoadAreaData.HasCircuitsWithoutElectricalLoadAreas(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/5a435471-42b2-880e-e189-9baba8b18b21.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalLoadAreaData.HasCircuitsWithoutElectricalLoadAreas Method

Checks whether there are any empty plan circuits in which there are no electrical load areas.

## Syntax (C#)
```csharp
public static bool HasCircuitsWithoutElectricalLoadAreas(
	Document doc,
	ElementId levelId,
	ElementId phaseId
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document to check.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The base level on which the empty plan circuits to check.
- **phaseId** (`Autodesk.Revit.DB.ElementId`) - The associated phase in which the empty plan circuits to check.

## Returns
True if there are empty plan circuits in which there are no electrical load areas, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - doc is not a project document.
 -or-
 The ElementId levelId is not a Level.
 -or-
 The id does not represent a valid phase.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).

