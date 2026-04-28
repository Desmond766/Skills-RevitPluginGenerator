---
kind: method
id: M:Autodesk.Revit.DB.StairsEditScope.Start(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/3cc137bd-4b9c-e0c8-f93a-14536a11bd18.htm
---
# Autodesk.Revit.DB.StairsEditScope.Start Method

Creates a new empty stairs element with a default stairs type in the specified levels
 and then starts stairs edit mode and editing the new stairs.

## Syntax (C#)
```csharp
public ElementId Start(
	ElementId baseLevelId,
	ElementId topLevelId
)
```

## Parameters
- **baseLevelId** (`Autodesk.Revit.DB.ElementId`) - The base level on which the stairs is to be placed.
- **topLevelId** (`Autodesk.Revit.DB.ElementId`) - The top level where the stairs is to reach.

## Returns
ElementId of the new stairs.

## Remarks
A new stairs will be created after this operation.
 User will need to start a transaction to actually make changes to the stairs element.
 StairsEditScope can only be started when there is no transaction active
 Thus it does not work for commands running in automatic transaction mode.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - It is not a Level's id.
 -or-
 Top level should be higher than base level.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This StairsEditScope is not permitted to start at this moment for one of the following possible reasons:
 The document is in read-only state, or the document is currently modifiable,
 or there already is another edit mode active in the document.

