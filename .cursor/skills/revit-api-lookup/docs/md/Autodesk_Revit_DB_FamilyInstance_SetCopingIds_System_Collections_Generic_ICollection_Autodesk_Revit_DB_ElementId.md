---
kind: method
id: M:Autodesk.Revit.DB.FamilyInstance.SetCopingIds(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 族实例
source: html/751280c8-4507-4837-add9-f6a83a1997fe.htm
---
# Autodesk.Revit.DB.FamilyInstance.SetCopingIds Method

**中文**: 族实例

Specifies the set of coping cutters on this element.

## Syntax (C#)
```csharp
public bool SetCopingIds(
	ICollection<ElementId> cutters
)
```

## Parameters
- **cutters** (`System.Collections.Generic.ICollection < ElementId >`) - A set of coping cutters (steel beams and steel columns).

## Remarks
The set may be Nothing nullptr a null reference ( Nothing in Visual Basic) or empty, but may not contain the element being coped.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when 'cutters' contains this instance.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when regeneration fails or if a cutter element is not a FamilyInstance.

