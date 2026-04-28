---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.MinimumThickness
source: html/8bff8d69-bc8d-b0ea-ed2f-6af1bed07e75.htm
---
# Autodesk.Revit.ApplicationServices.Application.MinimumThickness Property

The minimum thickness allowed in Revit for a variety of geometric constructs. These include blends, extrusions, and wall layers.

## Syntax (C#)
```csharp
public static double MinimumThickness { get; }
```

## Remarks
Do not use this value for any purpose other than its intended purpose.
 If you want to check for valid thickness value, use the function isValidThickness.

