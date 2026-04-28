---
kind: type
id: T:Autodesk.Revit.DB.Structure.AnalyticalSupportPriority
source: html/c35b3fe0-60a3-ba44-3fc8-e54e90237f66.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalSupportPriority

Defines how "highly" another Element is giving support for one Element.

## Syntax (C#)
```csharp
public enum AnalyticalSupportPriority
```

## Remarks
For instance, a Column may be a higher priority for a Beam than another Beam.
 This is useful to find the best supports for a given Element.

