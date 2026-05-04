---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.GetAttemptedResolutionTypes(Autodesk.Revit.DB.FailureMessageAccessor)
source: html/442f5727-d827-033d-fd50-4daf1cf77d5d.htm
---
# Autodesk.Revit.DB.FailuresAccessor.GetAttemptedResolutionTypes Method

Returns list of the failure resolution types attempted for the failure in the current transaction.

## Syntax (C#)
```csharp
public IList<FailureResolutionType> GetAttemptedResolutionTypes(
	FailureMessageAccessor failure
)
```

## Parameters
- **failure** (`Autodesk.Revit.DB.FailureMessageAccessor`) - The failure.

## Returns
The list of the types of failure resolutions attempted for the failure.

## Remarks
In some cases attempt to resolve a failure has no impact or failure gets reposted during next round of the end of transaction checks
 after being resolved. Knowing if any failure resolutions were attempted for the failure allows failures processor
 to prevent infinite loop.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - failure has not been properly initialized.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

