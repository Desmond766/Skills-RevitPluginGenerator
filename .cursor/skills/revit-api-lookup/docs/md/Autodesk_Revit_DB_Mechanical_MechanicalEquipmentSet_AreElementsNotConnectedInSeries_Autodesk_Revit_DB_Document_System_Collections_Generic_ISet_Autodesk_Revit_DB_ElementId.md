---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalEquipmentSet.AreElementsNotConnectedInSeries(Autodesk.Revit.DB.Document,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
source: html/64ec4b3b-0342-4f0e-7d5d-cbc384c9b06a.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalEquipmentSet.AreElementsNotConnectedInSeries Method

Checks if the elements are not serially connected.

## Syntax (C#)
```csharp
public static bool AreElementsNotConnectedInSeries(
	Document document,
	ISet<ElementId> elemIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document of these elements.
- **elemIds** (`System.Collections.Generic.ISet < ElementId >`) - The element ids to be tested.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

