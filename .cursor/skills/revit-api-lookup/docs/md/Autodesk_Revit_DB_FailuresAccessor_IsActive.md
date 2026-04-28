---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.IsActive
source: html/ea3282f1-d68c-813e-394a-2d98bfae66dd.htm
---
# Autodesk.Revit.DB.FailuresAccessor.IsActive Method

Method allows to check if this instance of the accessor is currently active.

## Syntax (C#)
```csharp
public bool IsActive()
```

## Returns
True if this instance is currently active and can be used.

## Remarks
Generally, this instance is active when it is passed to any of interfaces used in the process of failure resolution,
 and becomes inactive after returning control to Revit.
 The only special case is if failures processor returns WaitForUserInput,
 in which case document stays in the FailureMode and instance of failures accessor stays active till FailureMode is ended.

