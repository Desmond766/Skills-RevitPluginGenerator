---
kind: method
id: M:Autodesk.Revit.DB.StairsEditScope.Start(Autodesk.Revit.DB.ElementId)
source: html/2293899c-c7f5-d62f-61ff-1dc28f2ee76a.htm
---
# Autodesk.Revit.DB.StairsEditScope.Start Method

Starts an stairs edit mode for an existing Stairs element

## Syntax (C#)
```csharp
public ElementId Start(
	ElementId stairsId
)
```

## Parameters
- **stairsId** (`Autodesk.Revit.DB.ElementId`) - The stairs element to be edited.

## Returns
ElementId of the editing stairs. It should be the same as the input stairsId

## Remarks
User will need to start a transaction to actually make changes to the stairs element.
 StairsEditScope can only be started when there is no transaction active
 Thus it does not work for commands running in automatic transaction mode.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - It is not a Stair's id.
 -or-
 Stairs is not permitted to edit at this moment for the following reason:
 The Stairs is in an ElementGroup and it is not in Edit Group Mode.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This StairsEditScope is not permitted to start at this moment for one of the following possible reasons:
 The document is in read-only state, or the document is currently modifiable,
 or there already is another edit mode active in the document.

