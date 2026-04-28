---
kind: method
id: M:Autodesk.Revit.DB.Element.GetChangeTypeAny
zh: 构件、图元、元素
source: html/e9a0bce4-b289-1ea1-05d0-c0fc2943f8dd.htm
---
# Autodesk.Revit.DB.Element.GetChangeTypeAny Method

**中文**: 构件、图元、元素

Returns ChangeType associated with any change in an element.

## Syntax (C#)
```csharp
public static ChangeType GetChangeTypeAny()
```

## Returns
ChangeType that can be used to define a trigger for an Updater,
 triggering on any change in an element.

## Remarks
Use this change type to trigger an Updater when elements change in any way.
 For maximum efficiency, we recommend the use of ChangeTypeParameter and
 ChangeTypeGeometry, if applicable, instead. Caution: Changes to an element by an Updater using this trigger will result
 in re-triggering of the Updater. For example, Updater1 triggers on
 ChangeTypeAny on Element X. A Revit user modifies parameter A of X.
 Updater1 is triggered and modifies X's parameter B. The change in parameter B,
 triggers another call to Updater1.Execute(). If Updater1 continues to
 modify X, it can run into an infinite loop. Infinite loops are detected by
 Revit and result in the Updater being disabled. Note: This change type will not trigger on newly created or deleted elements or on changes caused by Undo and Redo.

