---
kind: method
id: M:Autodesk.Revit.DB.View.ConvertToIndependent
zh: 视图
source: html/fff3da7f-b885-f543-e12d-3f75e9b5bd94.htm
---
# Autodesk.Revit.DB.View.ConvertToIndependent Method

**中文**: 视图

Convert the dependent view to independent.

## Syntax (C#)
```csharp
public void ConvertToIndependent()
```

## Remarks
This method can be only applied to a dependent view.
 A dependent view can be created from another view using method View.Duplicate(ViewDuplicateOption.AsDependent).
 Dependent views have a valid primary view element ID that can be obtained via method View.GetPrimaryViewId();
 Independent views have InvalidElementId as their primary view ID.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This view is not dependent.

