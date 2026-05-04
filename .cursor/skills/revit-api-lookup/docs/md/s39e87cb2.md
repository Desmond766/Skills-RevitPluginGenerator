---
kind: property
id: P:Autodesk.Revit.DB.OBJExportOptions.MaxEdgeLength
source: html/a7e555ea-8873-79e8-8b89-fc36cfe9035a.htm
---
# Autodesk.Revit.DB.OBJExportOptions.MaxEdgeLength Property

The maximum length allowed for any chord on an edge or between any two adjacent grid lines. This is a percentage value.
 By exporting, the real value of maximum edge length is calculated as a percent from the length of the diameter of the body bounding box.
 The minimum allowed value is 0.1%. The maximum allowed value is 10.0%. By default this property is ignored.

## Syntax (C#)
```csharp
public double MaxEdgeLength { get; set; }
```

## Remarks
This property can be set by using export resolution type (by creation of OBJExportOptions or using [!:Autodesk::Revit::DB::OBJExportOptions::setTessellationSettings(ExportResolution::Enum)] method).
 In the case of Fine, Medium and Coarse resolutions, this property has the same value (10.0%) and it is considered as explicitly set by the user.
 In the case of Custom resolution type, this property is only allowed to be obtained if it has been explicitly set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The value maxEdgeLength is outside the allowable range of values for MaxEdgeLength tessellation parameter.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - MaxEdgeLength tessellation parameter is default (hasn't been explicitly set by the user) and cannot be obtained now.

