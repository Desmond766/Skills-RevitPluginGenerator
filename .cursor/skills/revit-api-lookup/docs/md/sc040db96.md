---
kind: method
id: M:Autodesk.Revit.DB.Element.GetChangeTypeElementAddition
zh: 构件、图元、元素
source: html/9f7a0758-21b5-bba6-5d26-9e1f40d29f7f.htm
---
# Autodesk.Revit.DB.Element.GetChangeTypeElementAddition Method

**中文**: 构件、图元、元素

Returns ChangeType associated with element addition

## Syntax (C#)
```csharp
public static ChangeType GetChangeTypeElementAddition()
```

## Returns
ChangeType that can be used to define a trigger for an Updater,
 triggering on element addition.

## Remarks
Use this change type to trigger an Updater on the addition of elements
 to a document.
 Note: This change type will not trigger on changes caused by Undo and Redo.

