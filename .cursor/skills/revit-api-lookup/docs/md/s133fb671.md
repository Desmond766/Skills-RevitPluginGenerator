---
kind: property
id: P:Autodesk.Revit.DB.STLExportOptions.GridAspectRatio
source: html/bf627a3c-6276-f85b-8aaf-4789a66bba02.htm
---
# Autodesk.Revit.DB.STLExportOptions.GridAspectRatio Property

The maximum aspect ratio allowed in the grid placed across the face.
 The minimum allowed value is 1.0. The maximum allowed value is 10.0. By default this property is ignored.

## Syntax (C#)
```csharp
public double GridAspectRatio { get; set; }
```

## Remarks
This property can be set by using export resolution type (by creation of STLExportOptions or using [!:Autodesk::Revit::DB::STLExportOptions::setTessellationSettings(ExportResolution::Enum)] method).
 In the case of Fine, Medium and Coarse resolutions, this property has the same value (10.0) and it is considered as explicitly set by the user.
 In the case of Custom resolution type, this property is only allowed to be obtained if it has been explicitly set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The value gridAspectRatio is outside the allowable range of values for GridAspectRatio tessellation parameter.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - GridAspectRatio tessellation parameter is default (hasn't been explicitly set by the user) and cannot be obtained now.

