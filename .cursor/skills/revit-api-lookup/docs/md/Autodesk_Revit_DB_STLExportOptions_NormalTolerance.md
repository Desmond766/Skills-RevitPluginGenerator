---
kind: property
id: P:Autodesk.Revit.DB.STLExportOptions.NormalTolerance
source: html/bbb19a10-aa63-c502-b7ec-f5e85b0427a6.htm
---
# Autodesk.Revit.DB.STLExportOptions.NormalTolerance Property

The maximum change in the surface normal between adjacent nodes in the mesh. This property is defined in degrees.
 The minimum allowed value is 1.0 degrees. The maximum allowed value is 45.0 degrees. Default value is 15.0 degrees.

## Syntax (C#)
```csharp
public double NormalTolerance { get; set; }
```

## Remarks
This property can be set by using export resolution type (by creation of STLExportOptions or using [!:Autodesk::Revit::DB::STLExportOptions::setTessellationSettings(ExportResolution::Enum)] method).
 In the case of Fine (10.0 degrees), Medium (15.0 degrees) and Coarse (30.0 degrees) resolutions, this property is considered as explicitly set by the user.
 In the case of Custom resolution type, this property is only allowed to be obtained if it has been explicitly set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The value normalTolerance is outside the allowable range of values for NormalTolerance tessellation parameter.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - NormalTolerance tessellation parameter is default (hasn't been explicitly set by the user) and cannot be obtained now.

