---
kind: method
id: M:Autodesk.Revit.DB.Element.ChangeTypeId(Autodesk.Revit.DB.ElementId)
zh: 构件、图元、元素
source: html/479b5d94-abd3-db42-27d7-6a3eda12f285.htm
---
# Autodesk.Revit.DB.Element.ChangeTypeId Method

**中文**: 构件、图元、元素

Changes the type of the element.

## Syntax (C#)
```csharp
public ElementId ChangeTypeId(
	ElementId typeId
)
```

## Parameters
- **typeId** (`Autodesk.Revit.DB.ElementId`) - Identifier of the type to assign to this element.

## Returns
The new element id if new element is created, or InvalidElementId if the element's type changed without creating a new element.

## Remarks
In rare cases, applying a change in type will result in a new element being created.
 The only active examples of this are when applying a normal wall type to a curtain panel, or
 converting such a wall back to a curtain panel.
 In this situation the new element id is returned.
 Also, this element becomes invalid.
 See also: IsModifiable .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The type typeId is not valid for this element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Element cannot have type assigned.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - This Element is an internal element, such as a component of a
 loaded family or a group type.
 -or-
 The document containing this Element is in Group Edit Mode,
 Sketch Edit Mode, or Paste Mode, and the element is not a
 member of the group, sketch, or clipboard.
 -or-
 This Element is a member of a group or sketch, and the document
 is not currently editing the group or sketch.

