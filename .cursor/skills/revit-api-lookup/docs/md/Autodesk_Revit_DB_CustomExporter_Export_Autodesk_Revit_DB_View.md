---
kind: method
id: M:Autodesk.Revit.DB.CustomExporter.Export(Autodesk.Revit.DB.View)
zh: 导出、输出
source: html/5a648f8c-62a0-d4c7-873c-8eab9f7abe7d.htm
---
# Autodesk.Revit.DB.CustomExporter.Export Method

**中文**: 导出、输出

Exports one 3D or 2D view

## Syntax (C#)
```csharp
public void Export(
	View view
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - An instance of the view to export

## Remarks
Note that the actual export process may differ
 depending on the type of export context used. For example, when the
 IModelExportContext is used,
 Revit is likely to perform several rounds of traversing each view, which
 may result in invoking the OnViewBegin/OnViewEnd method multiple times
 for every one view. It is because Revit draws objects in several layers
 (model layer, annotation layer, etc.) and will traverse each layer individually.
 In the most common scenario the user will receive two invocations of OnViewBegin/OnViewEnd:
 In the first round, all model entities will be received, while in the second round
 all text annotation elements will be received, if any present in the given view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The view is not exportable, such as a template view or wrong type view, for example.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The instance of IExportContext is not valid.
 -or-
 Rendering is currently not supported in the running instance of Revit.
 One reason for that to happen is that rendering and material libraries
 are not currently available.

