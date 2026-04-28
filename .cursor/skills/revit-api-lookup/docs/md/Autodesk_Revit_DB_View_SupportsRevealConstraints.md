---
kind: method
id: M:Autodesk.Revit.DB.View.SupportsRevealConstraints
zh: 视图
source: html/74881ee1-2fac-716c-c4d1-7f0402285a89.htm
---
# Autodesk.Revit.DB.View.SupportsRevealConstraints Method

**中文**: 视图

Checks that the view can have the Reveal Constraints mode activated.

## Syntax (C#)
```csharp
public bool SupportsRevealConstraints()
```

## Returns
True if the view has a view type that allows Reveal Constraints mode to be activated.

## Remarks
Reveal Constraints mode can only be activated for the following viewtypes:
 3D Views Area Plans Ceiling Plans Detail Views Drafting Views Elevations Floor Plans Sections Structural Plans

