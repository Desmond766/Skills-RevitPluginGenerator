---
kind: method
id: M:Autodesk.Revit.DB.Element.GetChangeTypeGeometry
zh: 构件、图元、元素
source: html/45751c5b-6d10-657a-a017-04219d1a5ac8.htm
---
# Autodesk.Revit.DB.Element.GetChangeTypeGeometry Method

**中文**: 构件、图元、元素

Returns ChangeType associated with a change in the geometry of an element

## Syntax (C#)
```csharp
public static ChangeType GetChangeTypeGeometry()
```

## Returns
ChangeType that can be used to define a trigger for an Updater,
 triggering on a geometry change in an element

## Remarks
Use this change type to trigger an Updater when the geometry of an element
 changes. For example, changes like cutting a hole in a wall or
 adjusting its height are considered to be geometric changes.
 Note: This change type will not trigger on newly created or deleted elements
 or on changes caused by Undo and Redo.

