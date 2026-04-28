---
kind: method
id: M:Autodesk.Revit.DB.Architecture.StairsRun.GetNumberSystemReference(Autodesk.Revit.DB.Architecture.StairsNumberSystemReferenceOption)
source: html/37d8b848-520b-47d1-5cad-f5c4e41c5979.htm
---
# Autodesk.Revit.DB.Architecture.StairsRun.GetNumberSystemReference Method

Gets the number system reference corresponding to the given reference options.

## Syntax (C#)
```csharp
public Reference GetNumberSystemReference(
	StairsNumberSystemReferenceOption referenceOption
)
```

## Parameters
- **referenceOption** (`Autodesk.Revit.DB.Architecture.StairsNumberSystemReferenceOption`) - The reference option.

## Returns
The reference.

## Remarks
The return value of this function is suitable for use in NumberSystem.Create()
 to associate a NumberSystem with the location on the StairsRun.
 Don't try to get geometry curve from the reference.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

