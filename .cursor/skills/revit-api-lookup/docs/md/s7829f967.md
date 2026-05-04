---
kind: type
id: T:Autodesk.Revit.DB.LinePattern
source: html/a2de5c67-d9be-760b-638a-579500216874.htm
---
# Autodesk.Revit.DB.LinePattern

Represents a line pattern definition.

## Syntax (C#)
```csharp
public class LinePattern : IDisposable
```

## Remarks
A line pattern is a pattern of dashes and dots used to control the way the lines of an object are drawn in Revit.
 Line patterns are used in the definition of GraphicsStyle objects.
 A line pattern is defined by a repeating sequence segments.
 Each segment is a dash, a dot or a space.
 A line pattern definition must contain an even number of segments, starting with a visible segment (a dash or a dot) and alternating between visible segments and spaces.

