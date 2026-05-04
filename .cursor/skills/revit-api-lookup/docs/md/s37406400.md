---
kind: method
id: M:Autodesk.Revit.DB.Subelement.ChangeTypeId(Autodesk.Revit.DB.ElementId)
source: html/4d8ab108-1a74-c4c9-1d84-ef323d246fe1.htm
---
# Autodesk.Revit.DB.Subelement.ChangeTypeId Method

Changes the type of the subelement.

## Syntax (C#)
```csharp
public void ChangeTypeId(
	ElementId typeId
)
```

## Parameters
- **typeId** (`Autodesk.Revit.DB.ElementId`) - Identifier of the type to assign to this subelement.

## Remarks
In rare cases, applying a change in type will result in a new element being created.
 The only active examples of this are when:
 Applying a normal wall type to a curtain panel. Converting such a wall back to a curtain panel. Applying a new type to a railing subelement. 
 In this situation this subelement object will be redirected to the new element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The type typeId is not valid for this subelement.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Subelement cannot have type assigned.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - This Subelement is an internal element, such as a component of a
 loaded family or a group type.
 -or-
 The document containing this Subelement is in Group Edit Mode,
 Sketch Edit Mode, or Paste Mode, and the element is not a
 member of the group, sketch, or clipboard.
 -or-
 This Subelement is a member of a group or sketch, and the document
 is not currently editing the group or sketch.

