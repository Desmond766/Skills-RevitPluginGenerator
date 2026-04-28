---
kind: method
id: M:Autodesk.Revit.DB.FailureHandlingOptions.SetFailuresPreprocessor(Autodesk.Revit.DB.IFailuresPreprocessor)
source: html/0647c18e-c1ad-60b8-d993-cb464b7b676e.htm
---
# Autodesk.Revit.DB.FailureHandlingOptions.SetFailuresPreprocessor Method

Sets the callback to be invoked in the beginning of failure processing.

## Syntax (C#)
```csharp
public FailureHandlingOptions SetFailuresPreprocessor(
	IFailuresPreprocessor preprocessor
)
```

## Parameters
- **preprocessor** (`Autodesk.Revit.DB.IFailuresPreprocessor`) - The callback to be invoked in the beginning of failure processing.

## Returns
This FailureHandlingOptions object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

