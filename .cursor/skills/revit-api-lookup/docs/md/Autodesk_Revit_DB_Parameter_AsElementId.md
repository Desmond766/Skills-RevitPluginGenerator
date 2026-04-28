---
kind: method
id: M:Autodesk.Revit.DB.Parameter.AsElementId
zh: 参数、共享参数
source: html/3e05f5e6-72a2-f633-3740-93feecee8156.htm
---
# Autodesk.Revit.DB.Parameter.AsElementId Method

**中文**: 参数、共享参数

Provides access to the Autodesk::Revit::DB::ElementId^ stored within the parameter.

## Syntax (C#)
```csharp
public ElementId AsElementId()
```

## Returns
The Autodesk::Revit::DB::ElementId^ contained in the parameter.

## Remarks
The AsAutodesk::Revit::DB::ElementId^ method should only be used if the StorageType property returns that the
internal contents of the parameter is an ElementId.

