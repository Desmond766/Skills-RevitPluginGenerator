---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalEquipmentSet.AreValidMembers(Autodesk.Revit.DB.Document,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
source: html/771618f2-c5b0-a48f-b98e-f3d5a8007473.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalEquipmentSet.AreValidMembers Method

Checks if these are valid members for mechanical equipment set.

## Syntax (C#)
```csharp
public static bool AreValidMembers(
	Document document,
	ISet<ElementId> memberIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document of the member elements.
- **memberIds** (`System.Collections.Generic.ISet < ElementId >`) - The member element ids.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

