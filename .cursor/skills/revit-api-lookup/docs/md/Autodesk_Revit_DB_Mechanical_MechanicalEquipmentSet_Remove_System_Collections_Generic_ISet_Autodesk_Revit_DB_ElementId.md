---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalEquipmentSet.Remove(System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
zh: 删除、移除
source: html/d0d52f18-81ea-ed87-0e0a-35419d813a64.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalEquipmentSet.Remove Method

**中文**: 删除、移除

Removes member element ids from the mechanical equipment set.

## Syntax (C#)
```csharp
public void Remove(
	ISet<ElementId> elemIds
)
```

## Parameters
- **elemIds** (`System.Collections.Generic.ISet < ElementId >`) - Element ids to be removed from the mechanical equipment set.

## Remarks
If all the members are removed, the instance of the mechanical equipment set is automatically deleted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more element ids was not permitted to be removed from the mechanical equipment set.
 All elements should be a member of the mechanical equipment set.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

