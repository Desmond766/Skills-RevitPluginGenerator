---
kind: method
id: M:Autodesk.Revit.DB.ViewDisplayDepthCueing.SetStartEndPercentages(System.Int32,System.Int32)
source: html/031e725f-2572-ec64-b3dd-810dba3f5188.htm
---
# Autodesk.Revit.DB.ViewDisplayDepthCueing.SetStartEndPercentages Method

Sets start and end percentages.

## Syntax (C#)
```csharp
public void SetStartEndPercentages(
	int startPercentage,
	int endPercentage
)
```

## Parameters
- **startPercentage** (`System.Int32`) - The start percentage defines where depth cueing starts.
- **endPercentage** (`System.Int32`) - The end percentage defines where depth cueing ends.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The start and end percentages values are not valid. The valid range is 0 to 100 and start is smaller than end.

