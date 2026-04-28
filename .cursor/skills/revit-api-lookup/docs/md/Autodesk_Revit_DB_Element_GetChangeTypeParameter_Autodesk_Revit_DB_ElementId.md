---
kind: method
id: M:Autodesk.Revit.DB.Element.GetChangeTypeParameter(Autodesk.Revit.DB.ElementId)
zh: 构件、图元、元素
source: html/6b0460f6-8db3-970c-d2d9-a1b5e470eb1e.htm
---
# Autodesk.Revit.DB.Element.GetChangeTypeParameter Method

**中文**: 构件、图元、元素

Returns ChangeType associated with a change in a parameter's value

## Syntax (C#)
```csharp
public static ChangeType GetChangeTypeParameter(
	ElementId parameterId
)
```

## Parameters
- **parameterId** (`Autodesk.Revit.DB.ElementId`) - ElementId of parameter for the ChangeType to trigger on.

## Returns
ChangeType that can be used to define a trigger for an Updater,
 triggering on parameter value change.

## Remarks
remarks: Use this change type to trigger an Updater when the value of an element's
 parameter changes.
 Note: This change type will not trigger on newly created or deleted elements or on changes caused by Undo and Redo.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

