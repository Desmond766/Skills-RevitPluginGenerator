---
kind: method
id: M:Autodesk.Revit.DB.CustomExporter.Export(System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId})
zh: 导出、输出
source: html/58d06458-fd6a-bdef-c457-2c52b50a70e8.htm
---
# Autodesk.Revit.DB.CustomExporter.Export Method

**中文**: 导出、输出

Exports a collection of 3D or 2D views

## Syntax (C#)
```csharp
public void Export(
	IList<ElementId> viewIds
)
```

## Parameters
- **viewIds** (`System.Collections.Generic.IList < ElementId >`) - An array of views to export

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
 all text annotation elements will be received, if any present in the given view. Note that all views in the collection must be either 3D or 2D views and they must match the exporter context. Note that currently the only 2D view types exported are IncludeGeometricObjects FloorPlan, CeilingPlan,Elevation, Section, Detail, EngineeringPlan, AreaPlan.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more elements in viewIds is not a valid exportable view.
 For example, templates are not considered valid views to export.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The instance of IExportContext is not valid.
 -or-
 Rendering is currently not supported in the running instance of Revit.
 One reason for that to happen is that rendering and material libraries
 are not currently available.

