---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipeSettings.SetPipeSlopes(System.Collections.Generic.IList{System.Double})
source: html/7d44bf12-8f5d-731c-9e72-8ae76cae8be3.htm
---
# Autodesk.Revit.DB.Plumbing.PipeSettings.SetPipeSlopes Method

Set pipe slope values.

## Syntax (C#)
```csharp
public void SetPipeSlopes(
	IList<double> slopes
)
```

## Parameters
- **slopes** (`System.Collections.Generic.IList < Double >`) - Pipe slope values. Revit stores the slope value as a percentage (0-100).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Each value of the slopes must be between 0 and 100. Slope value is stored in percentage. e.g. 100 means 100%, and it is 45 degree.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation failed.

