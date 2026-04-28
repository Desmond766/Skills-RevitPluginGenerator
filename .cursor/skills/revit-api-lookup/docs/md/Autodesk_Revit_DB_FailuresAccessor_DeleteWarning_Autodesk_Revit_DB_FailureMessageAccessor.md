---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.DeleteWarning(Autodesk.Revit.DB.FailureMessageAccessor)
source: html/610d703e-eff2-690e-e04c-46edac21caa9.htm
---
# Autodesk.Revit.DB.FailuresAccessor.DeleteWarning Method

Deletes one specific failure message of severity "Warning".

## Syntax (C#)
```csharp
public void DeleteWarning(
	FailureMessageAccessor failure
)
```

## Parameters
- **failure** (`Autodesk.Revit.DB.FailureMessageAccessor`) - The accessor to the warning to be deleted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - failure has not been properly initialized.
 -or-
 Severity of failure is not FailureSeverity::Warning.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

