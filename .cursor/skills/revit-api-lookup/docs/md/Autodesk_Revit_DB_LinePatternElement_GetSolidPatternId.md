---
kind: method
id: M:Autodesk.Revit.DB.LinePatternElement.GetSolidPatternId
source: html/e52c87b7-4544-372f-70a6-00188f6fd252.htm
---
# Autodesk.Revit.DB.LinePatternElement.GetSolidPatternId Method

Gets the solid line pattern element id.

## Syntax (C#)
```csharp
public static ElementId GetSolidPatternId()
```

## Returns
The element id of the solid line pattern.

## Remarks
Note that Solid is special. It isn't a line pattern at all -- it is a special code that tells drawing
 and export code to use solid lines rather than patterned lines. Solid is visible to the user when selecting
 line patterns.

