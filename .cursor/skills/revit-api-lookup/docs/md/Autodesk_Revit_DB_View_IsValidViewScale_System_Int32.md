---
kind: method
id: M:Autodesk.Revit.DB.View.IsValidViewScale(System.Int32)
zh: 视图
source: html/107c728b-97c9-3193-8711-73650b0ca814.htm
---
# Autodesk.Revit.DB.View.IsValidViewScale Method

**中文**: 视图

This validator checks that the view scale is in the allowable range.

## Syntax (C#)
```csharp
public static bool IsValidViewScale(
	int viewScale
)
```

## Parameters
- **viewScale** (`System.Int32`) - The denominator X in the view scale 1/X.

## Returns
True if the view scale is within the allowable range, false otherwise.

## Remarks
The view scale is expressed as 1/X, where X is an integer the range 1 to 24,000.

