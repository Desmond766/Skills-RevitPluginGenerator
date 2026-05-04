---
kind: property
id: P:Autodesk.Revit.DB.STLExportOptions.SurfaceTolerance
source: html/c87b91d0-9292-dd85-b2be-0999bc50fad8.htm
---
# Autodesk.Revit.DB.STLExportOptions.SurfaceTolerance Property

The maximum distance between mesh triangles and model geometry. This is a percentage value.
 By exporting, the real value of surface tolerance is calculated as a percent from the length of the diameter of the body bounding box.
 The minimum allowed value is 0.001%. The maximum allowed value is 1.0%. Default value is 0.1%.

## Syntax (C#)
```csharp
public double SurfaceTolerance { get; set; }
```

## Remarks
This property can be set by using export resolution type (by creation of STLExportOptions or using [!:Autodesk::Revit::DB::STLExportOptions::setTessellationSettings(ExportResolution::Enum)] method).
 In the case of Fine (0.005%), Medium (0.016%) and Coarse (0.04%) resolutions, this property is considered as explicitly set by the user.
 In the case of Custom resolution type, this property is only allowed to be obtained if it has been explicitly set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The value surfaceTolerance is outside the allowable range of values for SurfaceTolerance tessellation parameter.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - SurfaceTolerance tessellation parameter is default (hasn't been explicitly set by the user) and cannot be obtained now.

