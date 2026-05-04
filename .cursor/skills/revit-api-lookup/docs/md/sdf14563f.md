---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalEquipmentSet.Add(System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
source: html/2b911536-068c-3390-8309-2c4ac18cf133.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalEquipmentSet.Add Method

Adds member element ids to the mechanical equipment set.

## Syntax (C#)
```csharp
public void Add(
	ISet<ElementId> elemIds
)
```

## Parameters
- **elemIds** (`System.Collections.Generic.ISet < ElementId >`) - Element ids to be added to the mechanical equipment set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The valid members must have the same classification and system. They cannot be a member of existing set.
 -or-
 These elements are serially connected with each other, or with one of the set members.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

