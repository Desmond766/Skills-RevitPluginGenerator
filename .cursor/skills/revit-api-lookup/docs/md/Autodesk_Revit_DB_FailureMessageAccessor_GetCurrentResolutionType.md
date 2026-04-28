---
kind: method
id: M:Autodesk.Revit.DB.FailureMessageAccessor.GetCurrentResolutionType
source: html/b09b0b64-c5e5-0623-1145-4556f8926134.htm
---
# Autodesk.Revit.DB.FailureMessageAccessor.GetCurrentResolutionType Method

Retrieves the type of resolution to be used to resolve the failure.

## Syntax (C#)
```csharp
public FailureResolutionType GetCurrentResolutionType()
```

## Returns
The type of failure resolution to be used to resolve the failure.

## Remarks
If the current resolution type was never set for the failure, FailureResolutionType::Default is returned.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailureMessageAccessor has not been properly initialized.
 -or-
 This FailureMessageAccessor does not have any resolutions.

