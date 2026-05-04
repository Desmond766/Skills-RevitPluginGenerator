---
kind: method
id: M:Autodesk.Revit.DB.MEPSystem.Remove(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 删除、移除
source: html/712cb969-3aaf-d7f8-eece-ad121093784e.htm
---
# Autodesk.Revit.DB.MEPSystem.Remove Method

**中文**: 删除、移除

Remove elements from system.

## Syntax (C#)
```csharp
public virtual void Remove(
	ICollection<ElementId> elementIds
)
```

## Parameters
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - The elements to be removed from the system.

## Remarks
It is forbidden to remove all terminal elements from system.
Terminal elements will be removed from the system automatically after removing this system from document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument elements is Nothing nullptr a null reference ( Nothing in Visual Basic) , or any element in that collection is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when some of the elements can't be removed, or when trying to remove all elements from the system.
The element which connect to the base equipment can't be removed,
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the operation failed.

