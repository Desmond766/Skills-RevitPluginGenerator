---
kind: type
id: T:Autodesk.Revit.DB.FillGrid
source: html/6dfc3e2f-c869-d06e-876e-49c4007f7e59.htm
---
# Autodesk.Revit.DB.FillGrid

Represents a grid line in a fill pattern.

## Syntax (C#)
```csharp
public class FillGrid : IDisposable
```

## Remarks
A grid line is described in the two dimensions of a face as follows:
 angle, origin, shift, offset, segments
 Angle specifies the direction, in degrees, of the grid line relative to the x-axis. Parallel lines are drawn as specified by Offset and Shift to fill the entire face.
 Offset defines the distance between parallel lines. Zero Offset is not allowed.
 Shift moves the pattern of dashes and spaces along the length of each new parallel line.
 Shift is ignored if the line is solid. The segments defines a repeating pattern of dashes and spaces for the grid line. If it is
 omitted, the line is solid. Positive numbers define dashes, negative numbers define spaces, and
 zero specifies a dot. If you begin a pattern with a space, do not alternate dashes and spaces,
 or do not end with a space, Revit will introduce tiny dashes or spaces to compensate. Revit
 expands dots and very short dashes into dashes of a minimum size.

