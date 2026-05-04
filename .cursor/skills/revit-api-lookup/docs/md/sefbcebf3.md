---
kind: method
id: M:Autodesk.Revit.DB.FailureDefinitionAccessor.GetDefaultResolutionType
source: html/c0e2677a-251b-8255-bb05-1af5670363cd.htm
---
# Autodesk.Revit.DB.FailureDefinitionAccessor.GetDefaultResolutionType Method

Retrieves the default resolution type for the failure.

## Syntax (C#)
```csharp
public FailureResolutionType GetDefaultResolutionType()
```

## Returns
The default resolution type for the failure.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The FailureDefinitionAccessor has not been properly initialized.
 -or-
 FailureDefinition does not have any resolutions.

