---
kind: method
id: M:Autodesk.Revit.UI.FilterDialog.Show
zh: 取消隐藏、显示
source: html/6e3c8785-ea81-8c9f-02ef-2a4cdb069fed.htm
---
# Autodesk.Revit.UI.FilterDialog.Show Method

**中文**: 取消隐藏、显示

Shows the FilterDialog editing dialog to the user.

## Syntax (C#)
```csharp
public void Show()
```

## Remarks
If an existing FilterElement id was set during construction of the object or through the FilterToSelect property,
 that FilterElement will be selected for editing. If a new filter name was set during construction of the object or through the NewFilterName property,
 a new ParameterFilterElement will be created and that new element will be selected for editing.
 If this option was chosen, the id of the explicitly create new filter will be stored in the NewFilterId property. Note that the user may opt to add, delete or edit any of the available filter elements (or make no changes at all).
 To monitor which filters have been changed, use other Revit API mechanisms such as Dynamic Update or the DocumentChanged event.

