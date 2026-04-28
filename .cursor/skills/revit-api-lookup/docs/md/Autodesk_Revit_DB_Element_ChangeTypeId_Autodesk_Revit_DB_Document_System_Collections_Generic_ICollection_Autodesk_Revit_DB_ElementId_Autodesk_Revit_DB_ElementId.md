---
kind: method
id: M:Autodesk.Revit.DB.Element.ChangeTypeId(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.ElementId)
zh: 构件、图元、元素
source: html/6026a054-5e1e-5cac-7283-aa102aa997e3.htm
---
# Autodesk.Revit.DB.Element.ChangeTypeId Method

**中文**: 构件、图元、元素

Changes the type of all elements in the given set.

## Syntax (C#)
```csharp
public static IDictionary<ElementId, ElementId> ChangeTypeId(
	Document document,
	ICollection<ElementId> elementIds,
	ElementId typeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - A collection of element IDs.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - Identifier of the type to assign to this element.

## Returns
The map of original element IDs to the new element IDs
 if some elements were replaced by new elements
 (the map is empty if no elements were replaced)

## Remarks
In some cases, applying a change in type will result in a new element being created.
 The only active examples of this are when applying a normal wall type to a curtain panel, or
 converting such a wall back to a curtain panel.
 Then return map would have (original element id, new element id) pair(s).
 Note: this function needs an open transaction.
 Note: this function calls regeneration.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - At least one of the elements in elementIds does not exist in the document
 -or-
 Not all elements elementIds can have a type assigned.
 -or-
 The type typeId is not valid for at least one of the elements in elementIds.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - One or more elements in elementIds is a member of a loaded family.
 -or-
 One or more elements in elementIds is a member of a group type that is
 not being edited.

