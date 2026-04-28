---
kind: method
id: M:Autodesk.Revit.DB.View.ConvertTemporaryHideIsolateToPermanent
zh: 视图
source: html/02cfeb7e-de78-3ee6-4867-e8f1438d487a.htm
---
# Autodesk.Revit.DB.View.ConvertTemporaryHideIsolateToPermanent Method

**中文**: 视图

Convert all temporary hidden elements or categories to permanently hidden in view.

## Syntax (C#)
```csharp
public void ConvertTemporaryHideIsolateToPermanent()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this View" does not belong to a project document.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - This View is an internal element, such as a component of a
 loaded family or a group type.
 -or-
 The document containing this View is in Group Edit Mode,
 Sketch Edit Mode, or Paste Mode, and the element is not a
 member of the group, sketch, or clipboard.
 -or-
 This View is a member of a group or sketch, and the document
 is not currently editing the group or sketch.

