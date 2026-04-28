---
kind: type
id: T:Autodesk.Revit.DB.IFailuresPreprocessor
source: html/053c6262-d958-b1b6-44b7-35d0d83b5a43.htm
---
# Autodesk.Revit.DB.IFailuresPreprocessor

An interface that may be used to perform a preprocessing step to either filter out anticipated transaction failures
 or to mark certain failures as non-continuable.

## Syntax (C#)
```csharp
public interface IFailuresPreprocessor
```

## Remarks
This interface, if provided, is invoked when there are failures found at the end of a transaction.
 An instance of this interface can be set in the failure handling options of transaction object.

