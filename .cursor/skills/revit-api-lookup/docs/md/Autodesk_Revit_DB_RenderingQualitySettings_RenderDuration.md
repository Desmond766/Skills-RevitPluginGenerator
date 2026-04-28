---
kind: property
id: P:Autodesk.Revit.DB.RenderingQualitySettings.RenderDuration
source: html/eb0df241-d942-75b2-8512-049f68653040.htm
---
# Autodesk.Revit.DB.RenderingQualitySettings.RenderDuration Property

A value that controls render duration.

## Syntax (C#)
```csharp
public RenderDuration RenderDuration { get; set; }
```

## Remarks
The duration of rendering.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The value is not valid for RenderDuration.
 -or-
 When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The RenderingQualitySettings does not use custom quality currently.
 To use custom quality, set RenderingQuality property to RenderingQuality.Custom.

