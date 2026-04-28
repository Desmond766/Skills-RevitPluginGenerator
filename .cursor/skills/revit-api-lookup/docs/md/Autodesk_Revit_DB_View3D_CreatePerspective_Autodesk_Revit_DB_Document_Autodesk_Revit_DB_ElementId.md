---
kind: method
id: M:Autodesk.Revit.DB.View3D.CreatePerspective(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 三维视图、3d视图
source: html/67c282a5-7e20-7f93-ae98-9a1aa3f6e706.htm
---
# Autodesk.Revit.DB.View3D.CreatePerspective Method

**中文**: 三维视图、3d视图

Returns a new perspective View3D.

## Syntax (C#)
```csharp
public static View3D CreatePerspective(
	Document document,
	ElementId viewFamilyTypeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new View3D will be added.
- **viewFamilyTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the ViewFamilyType which will be used by the new View3D. The type needs to be a ThreeDimensional ViewType.

## Returns
The new perspective View3D.

## Remarks
The new View3D will receive a unique view name. The view will be oriented in the same position as the default 3D view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This View Family Type is not a ThreeDimensional view type.
 -or-
 3D view creation is not allowed in this family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

