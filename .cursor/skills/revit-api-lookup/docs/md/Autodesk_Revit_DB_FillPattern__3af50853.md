---
kind: type
id: T:Autodesk.Revit.DB.FillPattern
source: html/cc546ee9-ba80-c13d-4b74-8c0e2517bc28.htm
---
# Autodesk.Revit.DB.FillPattern

Represents a fill pattern object.

## Syntax (C#)
```csharp
public class FillPattern : IDisposable
```

## Remarks
Fill patterns control the appearance of surfaces that are cut or shown in projection.
 A simple fill pattern consists of a series of parallel or orthogonal lines.
 Note - Dots are coded as zero-length dashes in the fill pattern definition.
 When the Revit graphic engine encounters a zero-length line it simply ignores it and doesn't draw anything.
 So call ExpandDots() for the patterns you construct to convert dots to small dashes, so that the rendering of the FillPattern is correct.

