---
kind: method
id: M:Autodesk.Revit.DB.IFailuresPreprocessor.PreprocessFailures(Autodesk.Revit.DB.FailuresAccessor)
source: html/56e273aa-7d84-4a95-f06c-8a12e34e8be0.htm
---
# Autodesk.Revit.DB.IFailuresPreprocessor.PreprocessFailures Method

This method is called when there have been failures found at the end of a transaction and Revit is about to start processing them.

## Syntax (C#)
```csharp
FailureProcessingResult PreprocessFailures(
	FailuresAccessor failuresAccessor
)
```

## Parameters
- **failuresAccessor** (`Autodesk.Revit.DB.FailuresAccessor`) - The Interface class that provides access to the failure information.

## Returns
Notifies end of transaction code about further actions required. Return values are interpreted as follows:
 Continue - the failure processing will continue. Failures will be shown to the user, even if they were addressed by this method. ProceedWithCommit - end of transaction checks and failure processing will restart from the beginning.
 If some failures were resolved here, they will be removed and not delivered to the user.
 ProceedWithCommit cannot be returned if transaction is being rolled back. ProceedWithRollBack - the failure processing will continue. Failures will be shown to the user, but user will have no option
 to resolve or ignore them - only cancel option will be available. If intent is to roll back transaction without showing failures to the user,
 it can be achieved by setting failure handling option to remove failures before returning ProceedWithRollBack. 
 Other return values are not allowed.

